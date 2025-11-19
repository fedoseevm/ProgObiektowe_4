using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;


namespace FlightsReservation.Classes.Models
{
    public class FlightReservation
    {
        public string FlightNumber { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double Price { get; set; }
        public bool IsInternational { get; set; }
        public string PassportNumber { get; set; }
        public bool IsVisaRequired { get; set; }
    }
}
