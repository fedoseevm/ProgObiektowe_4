using FlightsReservation.Classes.Builder;
using FlightsReservation.Classes.Models;
using ReservationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.Classes.Factory
{
    internal class DomesticFlightReservationService : IReservationService
    {
        private UserInput userInput;
        public FlightReservation MakeReservation()
        {
            DomesticFlightReservationBuilder builder = new DomesticFlightReservationBuilder();
            ReservationDirector reservationDirector = new ReservationDirector();
            getUserInput();

            return reservationDirector.BuildReservation(builder, userInput);
        }

        public void getUserInput()
        {
            Console.Clear();
            Console.WriteLine("=== Rezerwacja lotu krajowego ===\n");

            // FLIGHT NUMBER
            string flightNumber;
            while (true)
            {
                Console.Write("Podaj numer lotu: ");
                flightNumber = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(flightNumber))
                    break;

                Console.WriteLine("Numer lotu nie może być pusty.");
            }

            // FROM
            string from;
            while (true)
            {
                Console.Write("Miejsce wylotu: ");
                from = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(from))
                    break;

                Console.WriteLine("Pole nie może być puste.");
            }

            // TO
            string to;
            while (true)
            {
                Console.Write("Miejsce przylotu: ");
                to = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(to))
                    break;

                Console.WriteLine("Pole nie może być puste.");
            }

            // DEPARTURE DATE TIME
            DateTime departureDate;
            while (true)
            {
                Console.Write("Data wylotu (DD.MM.RRRR): ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParseExact(dateInput, "dd.MM.yyyy", null,
                    System.Globalization.DateTimeStyles.None, out departureDate))
                {
                    break;
                }

                Console.WriteLine("Niepoprawny format daty. Użyj DD.MM.RRRR");
            }

            TimeSpan departureTime;
            while (true)
            {
                Console.Write("Godzina wylotu (HH:MM): ");
                string timeInput = Console.ReadLine();

                if (TimeSpan.TryParseExact(timeInput, "hh\\:mm", null, out departureTime))
                    break;

                Console.WriteLine("Niepoprawny format godziny. Użyj HH:MM");
            }

            departureDate = departureDate.Date + departureTime;

            // ARRIVAL DATE TIME
            DateTime arrivalDate;
            while (true)
            {
                Console.Write("Data przylotu (DD.MM.RRRR): ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParseExact(dateInput, "dd.MM.yyyy", null,
                    System.Globalization.DateTimeStyles.None, out arrivalDate))
                {
                    break;
                }

                Console.WriteLine("Niepoprawny format daty. Użyj DD.MM.RRRR");
            }

            TimeSpan arrivalTime;
            while (true)
            {
                Console.Write("Godzina przylotu (HH:MM): ");
                string timeInput = Console.ReadLine();

                if (TimeSpan.TryParseExact(timeInput, "hh\\:mm", null, out arrivalTime))
                    break;

                Console.WriteLine("Niepoprawny format godziny. Użyj HH:MM");
            }

            arrivalDate = arrivalDate.Date + arrivalTime;

            // PRICE
            double price;
            while (true)
            {
                Console.Write("Cena biletu: ");
                string priceInput = Console.ReadLine();

                if (double.TryParse(priceInput, out price) && price > 0)
                    break;

                Console.WriteLine("Cena musi być dodatnią liczbą.");
            }

            userInput = new UserInput(flightNumber, from, to, departureDate, arrivalDate, price);

            Console.WriteLine("\nDane zostały poprawnie zebrane.");
            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
    }
}
