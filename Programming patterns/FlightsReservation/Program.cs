using FlightsReservation.classes;
using Google.Cloud.Firestore;
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
            }
            else
            {
                Console.WriteLine("\nBłąd logowania — nieprawidłowy login lub hasło.");
            }

            Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu...");
            Console.ReadLine();
        }

        private static async Task UserRegister()
        {
            Console.Clear();
            Console.WriteLine("=== REJESTRACJA ===");

            Console.Write("Wybierz nazwę użytkownika: ");
            string username = Console.ReadLine();

            Console.Write("Wybierz hasło: ");
            string password = Console.ReadLine();

            // Połączenie z Firestore
            FirestoreDb db = LoginManager.GetInstance().DbConnect();

            // Sprawdzenie, czy użytkownik już istnieje
            CollectionReference usersRef = db.Collection("users");
            Query query = usersRef.WhereEqualTo("username", username);
            QuerySnapshot result = await query.GetSnapshotAsync();

            if (result.Documents.Count > 0)
            {
                Console.WriteLine("\nUżytkownik o tej nazwie już istnieje.");
            }
            else
            {
                // Dodanie nowego użytkownika
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
    }
}
