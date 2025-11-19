using FlightsReservation.Classes.Builder;
using FlightsReservation.Classes.Models;
using System;

namespace ReservationSystem
{
    public class DomesticFlightReservationBuilder : IReservationBuilder
    {
        private FlightReservation reservation = new FlightReservation();

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
            reservation.IsInternational = false;
        }
        public void setPassportNumber(string passportNumber)
        {
            reservation.PassportNumber = null;
        }
        public void setIsVisaRequired(bool isVisaRequired)
        {
            reservation.IsVisaRequired = false;
        }

        public FlightReservation Build()
        {
            return reservation;
        }
    }
}