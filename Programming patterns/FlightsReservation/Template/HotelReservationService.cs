using System;

namespace ReservationSystem
{
    public class HotelReservationService : IReservationService
    {
        public void MakeReservation()
        {
            Logger.Instance.Log("Rezerwacja hotelu została utworzona!");
        }
    }
}