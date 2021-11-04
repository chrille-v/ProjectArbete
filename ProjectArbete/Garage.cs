using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Garage : IEnumerable
    {
        bool loop;

        public Car newCar = new();
        public Moped newMoped = new();

        public List<Vehicle> listOfVehicle = new();
        public IEnumerator GetEnumerator()
        {
            return listOfVehicle.GetEnumerator();
            throw new NotImplementedException();
        }

        public void ListVehicle()
        {
            Console.WriteLine("These are the vehicles currently in the garage: ");
            
            foreach (Car item in listOfVehicle)
            {
                Console.WriteLine("Number of seats: {0}", item.NumberOfSeats);
                Console.WriteLine("Is it combi: \t{0}", item.Combi);
                Console.WriteLine("Registration number: {0}", item.RegNumber);
                Console.WriteLine("Color: \t \t{0}", item.Color);
                Console.WriteLine("Brand: \t \t{0}", item.Brand);

                Console.WriteLine();
            }

            foreach (Moped item in listOfVehicle)
            {
                Console.WriteLine("Class of moped: {0}", item.MopedClass);
                Console.WriteLine("Number of seats: \t{0}", item.Seats);
                Console.WriteLine("Registration number: {0}", item.RegNumber);
                Console.WriteLine("Color: \t \t{0}", item.Color);
                Console.WriteLine("Brand: \t \t{0}", item.Brand);

                Console.WriteLine();
            }
        }

        public void ListTypeVehicle()
        {

        }

        public void AddVehicle()
        {
            Console.WriteLine("What kind of vehicle would you like to add?" +
                "\n1. Moped " +
                "\n2. Motorcycle " +
                "\n3. Car " +
                "\n4. Buss " +
                "\n5. Truck " +
                "\n0. Go back");

            int choice = ReadInt();
            switch (choice)
            {
                case 1:
                    ReadMoped();
                    break;
                case 3:
                    ReadCar();
                    break;

                case 0:
                    break;

                default:
                    break;
            }
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Please enter the space(index) you would like to empty.");

            loop = true;
            while (loop)
            {
                int index = ReadInt();
                if (index - 1 < 0 || listOfVehicle == null)
                {
                    Console.WriteLine("There is no vehicle at that spot");
                }
                else
                {
                    listOfVehicle.RemoveAt(index - 1);
                    loop = false;
                }
            }
        }
        /// <summary>
        /// Searches Vehicles for reg.nr, and gives true or false.
        /// </summary>
        public void SearchVehicle()
        {
            Console.WriteLine("Search for registration number: ");
            string searchRegNumber = Console.ReadLine();

            var result = listOfVehicle.Where(x => x.RegNumber == searchRegNumber).ToList();

            if (result != null)
            {
                Console.WriteLine("There is one vehicle with that registration number.");
            }
            else
            {
                Console.WriteLine("No vehicle with that registration number.");
            }
        }
        
        public int ReadInt()
        {
            int number;
            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Not a valid option, please try again!");
            }
            return number;
        }

        public void ReadCar()
        {
            Console.WriteLine("Write registration number: ");
            newCar.RegNumber = Console.ReadLine();

            Console.WriteLine("What color? ");
            newCar.Color = Console.ReadLine();

            Console.WriteLine("Enter car brand:");
            newCar.Brand = Console.ReadLine();

            Console.WriteLine("Please enter number of seats: ");
            newCar.NumberOfSeats = ReadInt();

            Console.WriteLine("Is it a combi? y/n");
            string combi = Console.ReadLine();

            switch (combi)
            {
                case "y":
                    newCar.Combi = true;
                    break;

                case "n":
                    newCar.Combi = false;
                    break;
                default:
                    Console.WriteLine("Please answer yes or no.");
                    break;
            }

            listOfVehicle.Add(new Car(newCar.NumberOfSeats, newCar.Combi, newCar.RegNumber, newCar.Color, newCar.Brand, "car", 4));
        }

        public void ReadMoped()
        {
            Console.WriteLine("Write registration number: ");
            newMoped.RegNumber = Console.ReadLine().ToLower();

            Console.WriteLine("Enter class1 or class2 moped: ");
            newMoped.MopedClass = Console.ReadLine().ToLower();

            Console.WriteLine("How many seats?");
            newMoped.Seats = ReadInt();

            Console.WriteLine("What color? ");
            newMoped.Color = Console.ReadLine().ToLower();

            Console.WriteLine("Enter car brand:");
            newMoped.Brand = Console.ReadLine().ToLower();

            listOfVehicle.Add(new Moped(newMoped.MopedClass, newMoped.Seats, newMoped.RegNumber, newMoped.Color, newMoped.Brand, "moped", 2));
        }
    }
}