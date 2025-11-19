using FlightsReservation.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.Classes.Builder
{
    internal interface IReservationBuilder
    {
        void setFlightNumber(string flightNumber);

        void setFrom(string from);
        void setTo(string to);
        void setDepartureDate(DateTime departureDate);
        void setArrivalDate(DateTime arrivalDate);
        void setPrice(double price);
        void setIsInternational();
        void setPassportNumber(string passportNumber);
        void setIsVisaRequired(bool isVisaRequired);

        FlightReservation Build();
    }
}
