using FlightsReservation.Classes.Factory;
using System;

namespace ReservationSystem
{
    public static class ReservationFactory
    {
        public static IReservationService Create(string type)
        {
            switch (type.ToLower())
            {
                case "domesticFlight":
                    return new DomesticFlightReservationService();
                case "internationalFlight":
                    return new InternationalFlightReservationService();
                default:
                    throw new ArgumentException("Nieznany typ rezerwacji.");
            }
        }
    }
}