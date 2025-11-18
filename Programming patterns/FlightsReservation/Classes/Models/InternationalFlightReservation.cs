using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.Classes.Models
{
    internal class InternationalFlightReservation : FlightReservation
    {
        public string PassportNumber { get; set; }
        public bool IsVisaRequired { get; set; }
    }
}
