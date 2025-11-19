using FlightsReservation.Classes.Models;

namespace ReservationSystem
{
    public interface IReservationService
    {
        FlightReservation MakeReservation();
        void getUserInput();
    }
}