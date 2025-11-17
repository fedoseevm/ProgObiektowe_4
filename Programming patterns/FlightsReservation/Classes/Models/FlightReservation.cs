using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.Classes.Models
{
    internal class FlightReservation
    {
        private string flightNumber;
        private string from;
        private string to;
        private DateTime departureDate;
        private DateTime arrivalDate;
        private double price;
        private bool isInternational;
    }
}
