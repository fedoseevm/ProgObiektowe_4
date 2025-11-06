namespace ReservationSystem
{
    public class ReservationBuilder
    {
        private Reservation reservation = new Reservation();

        public ReservationBuilder SetName(string name)
        {
            reservation.Name = name;
            return this;
        }

        public ReservationBuilder SetDate(string date)
        {
            reservation.Date = date;
            return this;
        }

        public ReservationBuilder SetLocation(string location)
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