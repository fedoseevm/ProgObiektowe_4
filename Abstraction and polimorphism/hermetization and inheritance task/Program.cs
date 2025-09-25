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

        public virtual string Description()
        {
            return "To jest ogólny opis pokoju.";
        }

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

        public string ifHasView()
        {
            if (hasView) return "Tak";
            return "Nie";
        }

        public override string Description()
        {
            return $"okój standardowy numer: {getRoomNumber()} ma {getNumberOfBeds()} miejsc. Widok: {ifHasView()}.";
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

        public override string Description()
        {
            return $"Apartament numer: {apartmentNumber} na piętrze {floor}, ma {getNumberOfBeds()} miejsc.";
        }
    }

    class FamilyRoom : Room
    {
        private int numberOfChildren;
        private bool hasCrib;

        public FamilyRoom(int roomNumber, int numberOfBeds, int numberOfChildren, bool hasCrib) : base(roomNumber, numberOfBeds)
        {
            this.numberOfChildren = numberOfChildren;
            this.hasCrib = hasCrib;
        }

        public int getNumberOfChildren() { return numberOfChildren; }
        public void changeNumberOfChildren(int numberOfChildren)
        {
            this.numberOfChildren = numberOfChildren;
            Console.WriteLine($"Teraz liczba dzieci w pokoju {getRoomNumber()} wynosi {numberOfChildren}");
        }

        public string ifHasCrib()
        {
            if (hasCrib) return "Tak";
            return "Nie";
        }
        public void ChangeIfHasCrib()
        {
            hasCrib = !hasCrib;
            Console.WriteLine("Obecność łóżeczka: {0}", hasCrib);
        }

        public override string Description()
        {
            return $"Pokój rodzinny numer: {getRoomNumber()}, dla {getNumberOfBeds()} osób. Możliwe noclegi dla {getNumberOfChildren()} dzieci. Łóżeczko: {ifHasCrib()}.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Room room1 = new Room(1, 2);
            Room room2 = new Room(2, 1);
            Room room3 = new Room(3, 3);
            List<Room> rooms = new List<Room>();
            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);

            StandardRoom standardRoom1 = new StandardRoom(4, 2, true);
            Apartment a1 = new Apartment(5, 2, 3, 23);
            FamilyRoom familyRoom1 = new FamilyRoom(6, 4, 2, true);

            rooms.Add(standardRoom1);
            rooms.Add(a1);
            rooms.Add(familyRoom1);

            foreach (var room in rooms)
            {
                Console.WriteLine(room.Description()); 
            }
        }
    }
}
