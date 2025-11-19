using FlightsReservation.classes;
using FlightsReservation.Classes.Builder;
using FlightsReservation.Classes.Factory;
using FlightsReservation.Classes.Models;
using Google.Cloud.Firestore;
using ReservationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            LoginManager loginManager = LoginManager.GetInstance();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SYSTEM REZERWACJI LOTÓW ===");
                Console.WriteLine("1. Zaloguj się");
                Console.WriteLine("2. Zarejestruj się");
                Console.WriteLine("3. Wyjdź");
                Console.Write("\nWybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await UserLogin(loginManager);
                        break;

                    case "2":
                        await UserRegister();
                        break;

                    case "3":
                        Console.WriteLine("Zamykanie programu...");
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Naciśnij Enter, aby spróbować ponownie.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static async Task UserLogin(LoginManager loginManager)
        {
            Console.Clear();
            Console.WriteLine("=== LOGOWANIE ===");
            Console.Write("Nazwa użytkownika: ");
            string username = Console.ReadLine();
            Console.Write("Hasło: ");
            string password = Console.ReadLine();

            bool success = await loginManager.Login(username, password);

            if (success)
            {
                Console.WriteLine($"\nZalogowano pomyślnie! Witaj, {loginManager.CurrentUser.Username}.");
                
                await UserMenu(loginManager);
            }
            else
            {
                Console.WriteLine("\nBłąd logowania — nieprawidłowy login lub hasło.");
                Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu...");
                Console.ReadLine();
            }
        }

        private static async Task UserRegister()
        {
            Console.Clear();
            Console.WriteLine("=== REJESTRACJA ===");

            Console.Write("Wybierz nazwę użytkownika: ");
            string username = Console.ReadLine();

            Console.Write("Wybierz hasło: ");
            string password = Console.ReadLine();

            // Firestore
            FirestoreDb db = LoginManager.GetInstance().DbConnect();

            CollectionReference usersRef = db.Collection("users");
            Query query = usersRef.WhereEqualTo("username", username);
            QuerySnapshot queryResult = await query.GetSnapshotAsync();

            if (queryResult.Documents.Count > 0)
            {
                Console.WriteLine("\nUżytkownik o tej nazwie już istnieje.");
            }
            else
            {
                var newUser = new 
                { 
                    username = username, 
                    password = password 
                };

                await usersRef.AddAsync(newUser);
                Console.WriteLine("\nRejestracja zakończona pomyślnie!");
            }

            Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu...");
            Console.ReadLine();
        }

        private static async Task UserMenu(LoginManager loginManager)
        {
            FirestoreDb db = loginManager.DbConnect();

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== MENU UŻYTKOWNIKA ({loginManager.CurrentUser.Username}) ===");
                Console.WriteLine("1. Stwórz rezerwację");
                Console.WriteLine("2. Zobacz moje rezerwacje");
                Console.WriteLine("3. Wyloguj się");
                Console.Write("\nWybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await CreateReservation(loginManager, db);
                        break;

                    case "2":
                        await ShowUserReservations(loginManager, db);
                        break;

                    case "3":
                        Console.WriteLine("Wylogowywanie...");
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Naciśnij Enter, aby spróbować ponownie.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static async Task CreateReservation(LoginManager loginManager, FirestoreDb db)
        {
            Console.Clear();
            Console.WriteLine("=== TWORZENIE REZERWACJI ===");

            Console.WriteLine("Wybierz typ lotu:");
            Console.WriteLine("1. Krajowy");
            Console.WriteLine("2. Międzynarodowy");
            Console.Write("\nWybierz opcję: ");
            string flightReservationType = Console.ReadLine();

            IReservationService reservationService;

            switch (flightReservationType)
            {
                case "1":
                    reservationService = new DomesticFlightReservationService();
                    break;
                case "2":
                    reservationService = new InternationalFlightReservationService();
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Naciśnij Enter...");
                    Console.ReadLine();
                    return;
            }

            FlightReservation reservation = reservationService.MakeReservation();

            // Firestore
            string docId = $"flight_{reservation.FlightNumber}";
            DocumentReference flightDocRef = db.Collection("users")
                                               .Document(loginManager.CurrentUser.Username)
                                               .Collection("flights")
                                               .Document(docId);
            Dictionary<string, object> flightData = new Dictionary<string, object>
            {
                { "FlightNumber", reservation.FlightNumber },
                { "From", reservation.From },
                { "To", reservation.To },
                { "DepartureDate", reservation.DepartureDate.ToUniversalTime() },
                { "ArrivalDate", reservation.ArrivalDate.ToUniversalTime() },
                { "Price", reservation.Price },
                { "IsInternational", reservation.IsInternational }
            };

            // If International flight
            if (reservation.IsInternational)
            {
                flightData["PassportNumber"] = reservation.PassportNumber;
                flightData["IsVisaRequired"] = reservation.IsVisaRequired;
            }

            await flightDocRef.SetAsync(flightData);
            Console.WriteLine("\nRezerwacja została zapisana pomyślnie!");

            Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu...");
            Console.ReadLine();
        }

        private static async Task ShowUserReservations(LoginManager loginManager, FirestoreDb db)
        {
            Console.Clear();
            Console.WriteLine("=== TWOJE REZERWACJE ===\n");

            // Firestore
            CollectionReference flightsRef = db.Collection("users")
                                               .Document(loginManager.CurrentUser.Username)
                                               .Collection("flights");

            QuerySnapshot queryResult = await flightsRef.GetSnapshotAsync();

            if (queryResult.Documents.Count == 0)
            {
                Console.WriteLine("Nie masz jeszcze żadnych rezerwacji.");
            }
            else
            {
                foreach (var document in queryResult.Documents)
                {
                    var data = document.ToDictionary();

                    string flightNumber = data["FlightNumber"].ToString();
                    string from = data["From"].ToString();
                    string to = data["To"].ToString();

                    DateTime departureDate = ((Timestamp)data["DepartureDate"]).ToDateTime().ToLocalTime();

                    DateTime arrivalDate = ((Timestamp)data["ArrivalDate"]).ToDateTime().ToLocalTime();

                    double price = Convert.ToDouble(data["Price"]);
                    bool isInternational = Convert.ToBoolean(data["IsInternational"]);

                    Console.WriteLine($"Lot: {flightNumber} | Z: {from} -> Do: {to} | Wylot: {departureDate} | Przylot: {arrivalDate} | Cena: {price} zł");

                    if (isInternational)
                    {
                        string passportNumber = data["PassportNumber"].ToString();
                        bool isVisaRequired = Convert.ToBoolean(data["IsVisaRequired"]);
                        Console.WriteLine($"Paszport: {passportNumber} | Wiza: {(isVisaRequired ? "Tak" : "Nie")}");
                    }

                    Console.WriteLine("----------------------------------------");
                }
            }

            Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu...");
            Console.ReadLine();
        }
    }
}
