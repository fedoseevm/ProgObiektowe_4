using FlightsReservation.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.Classes.Builder
{
    internal class ReservationDirector
    {
        public FlightReservation BuildReservation(IReservationBuilder builder, UserInput userInput)
        {
            builder.setFlightNumber(userInput.FlightNumber);
            builder.setFrom(userInput.From);
            builder.setTo(userInput.To);
            builder.setDepartureDate(userInput.DepartureDate);
            builder.setArrivalDate(userInput.ArrivalDate);
            builder.setPrice(userInput.Price);
            builder.setIsInternational();
            builder.setPassportNumber(userInput.PassportNumber);
            builder.setIsVisaRequired(userInput.IsVisaRequired);
            return builder.Build();
        }
    }
}
