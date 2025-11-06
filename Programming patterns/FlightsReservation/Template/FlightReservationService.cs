using System;

namespace ReservationSystem
{
    public class FlightReservationService : IReservationService
    {
        public void MakeReservation()
        {
            Logger.Instance.Log("Rezerwacja lotu została utworzona!");
        }
    }
}