using System;

namespace ReservationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Log("=== SYSTEM REZERWACJI USŁUG ONLINE ===");

            Console.WriteLine("Podaj typ rezerwacji (hotel/flight/doctor): ");
            string type = Console.ReadLine();

            IReservationService service = ReservationFactory.Create(type);
            service.MakeReservation();

            var reservation = new ReservationBuilder()
                .SetName("Jan Kowalski")
                .SetDate("2025-11-10")
                .SetLocation("Warszawa")
                .Build();

            Logger.Instance.Log($"Utworzono rezerwację dla: {reservation.Name}");
            Logger.Instance.Log("=== KONIEC DZIAŁANIA SYSTEMU ===");
        }
    }
}