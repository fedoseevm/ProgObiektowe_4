using FlightsReservation.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.Classes.Builder
{
    internal class InternationalFlightReservationBuilder : IReservationBuilder
    {

        FlightReservation reservation = new FlightReservation();
        public void setFlightNumber(string flightNumber)
        {
            reservation.FlightNumber = flightNumber;
        }

        public void setFrom(string from)
        {
            reservation.From = from;
        }

        public void setTo(string to)
        {
            reservation.To = to;
        }

        public void setDepartureDate(DateTime departureDate)
        {
            reservation.DepartureDate = departureDate;
        }

        public void setArrivalDate(DateTime arrivalDate)
        {
            reservation.ArrivalDate = arrivalDate;
        }

        public void setPrice(double price)
        {
            reservation.Price = price;
        }

        public void setIsInternational()
        {
            reservation.IsInternational = true;
        }

        public void setPassportNumber(string passportNumber)
        {
            reservation.PassportNumber = passportNumber;
        }
        
        public void setIsVisaRequired(bool isVisaRequired)
        {
            reservation.IsVisaRequired = isVisaRequired;
        }

        public FlightReservation Build()
        {
            return reservation;
        }
    }
}
