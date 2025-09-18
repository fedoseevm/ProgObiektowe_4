using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    class Room
    {
        private int roomNumber;
        private int numberOfBeds;

        public Room(int roomNumber, int numberOfBeds)
        {
            this.roomNumber = roomNumber;
            this.numberOfBeds = numberOfBeds;
        }

        public int getRoomNumber() { return roomNumber; }
        public int getNumberOfBeds() { return numberOfBeds; }
    }

    class StandardRoom : Room
    {
        private bool hasView = false;

        public StandardRoom(int roomNumber, int numberOfBeds, bool hasView) : base(roomNumber, numberOfBeds)
        {
            this.hasView = hasView;
        }
    }

    class Apartment : Room
    {
        private int apartmentNumber;
        private int floor;

        public Apartment(int roomNumber, int numberOfBeds, int apartmentNumber, int floor) : base(apartmentNumber, floor)
        {
            this.apartmentNumber = apartmentNumber;
            this.floor = floor;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Apartment a = new Apartment(73, 2, 3, 23);
        }
    }
}
