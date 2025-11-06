using System;

namespace ReservationSystem
{
    public class DoctorAppointmentService : IReservationService
    {
        public void MakeReservation()
        {
            Logger.Instance.Log("Wizyta lekarska została zarezerwowana!");
        }
    }
}