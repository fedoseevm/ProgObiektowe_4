using System;

namespace ReservationSystem
{
    public static class ReservationFactory
    {
        public static IReservationService Create(string type)
        {
            switch (type.ToLower())
            {
                case "hotel":
                    return new HotelReservationService();
                case "flight":
                    return new FlightReservationService();
                case "doctor":
                    return new DoctorAppointmentService();
                default:
                    throw new ArgumentException("Nieznany typ rezerwacji.");
            }
        }
    }
}