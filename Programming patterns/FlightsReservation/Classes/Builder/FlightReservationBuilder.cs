namespace ReservationSystem
{
    public class FlightReservationBuilder
    {
        private Reservation reservation = new Reservation();

        public FlightReservationBuilder SetName(string name)
        {
            reservation.Name = name;
            return this;
        }

        public FlightReservationBuilder SetDate(string date)
        {
            reservation.Date = date;
            return this;
        }

        public FlightReservationBuilder SetLocation(string location)
        {
            reservation.Location = location;
            return this;
        }

        public Reservation Build()
        {
            return reservation;
        }
    }
}