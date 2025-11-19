using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.Classes.Builder
{
    internal class UserInput
    {
        public string FlightNumber { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double Price { get; set; }
        public string PassportNumber { get; set; }
        public bool IsVisaRequired { get; set; }

        public UserInput(string flightNumber, string from, string to, DateTime departureDate, DateTime arrivalDate, double price)
        {
            FlightNumber = flightNumber;
            From = from;
            To = to;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Price = price;
        }

        public UserInput(string flightNumber, string from, string to, DateTime departureDate, DateTime arrivalDate, double price, string passportNumber, bool isVisaRequired)
        {
            FlightNumber = flightNumber;
            From = from;
            To = to;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            Price = price;
            PassportNumber = passportNumber;
            IsVisaRequired = isVisaRequired;
        }
    }
}
