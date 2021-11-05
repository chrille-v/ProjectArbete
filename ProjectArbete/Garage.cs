using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Garage : IEnumerable<Vehicle>
    {
        bool loop;

        public Car newCar = new();
        public Moped newMoped = new();

        public IEnumerator<Vehicle> GetEnumerator()
        {
            return ((IEnumerable<Vehicle>)listOfVehicle).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)listOfVehicle).GetEnumerator();
        }

        public List<Vehicle> listOfVehicle = new();
        public void ListVehicle()
        {
            Console.WriteLine("These are the vehicles currently in the garage: ");
            
            foreach (var item in listOfVehicle)
            {
                //Console.WriteLine("Number of seats: {0}", item.NumberOfSeats);
                //Console.WriteLine("Is it combi: \t{0}", item.Combi);
                Console.WriteLine("Registration number: {0}", item.RegNumber);
                Console.WriteLine("Color: \t \t{0}", item.Color);
                Console.WriteLine("Brand: \t \t{0}", item.Brand);
                Console.WriteLine("Type: {0}", item.Type);

                Console.WriteLine();
            }
        }
        /// <summary>
        /// List the different types of vehicles currently in 
        /// the garage, and how many of each.
        /// </summary>
        public void ListTypeVehicle()
        {

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
        public bool SearchVehicle()
        {
            Console.WriteLine("Search for registration number to see if that vehicle is parked in the garage ");
            string searchRegNumber = Console.ReadLine();

            //var result = listOfVehicle.Where(x => x.RegNumber == searchRegNumber).ToList();
            bool result = listOfVehicle.Any(x => x.RegNumber == searchRegNumber);

            if (result)
            {
                Console.WriteLine("{0} There is one vehicle with that registration number.", result.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("{0} No such vehicle in the garage. ", result.ToString());
                return false;
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

        public void ReadMotorCycle()
        {

        }

        public void ReadTruck()
        {

        }

        public void ReadBuss()
        {

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

            Console.WriteLine("Class1 or class2 moped: ");
            newMoped.MopedClass = Console.ReadLine().ToLower();

            Console.WriteLine("How many seats?");
            newMoped.Seats = ReadInt();

            Console.WriteLine("What color? ");
            newMoped.Color = Console.ReadLine().ToLower();

            Console.WriteLine("Enter brand:");
            newMoped.Brand = Console.ReadLine().ToLower();

            listOfVehicle.Add(new Moped(newMoped.MopedClass, newMoped.Seats, newMoped.RegNumber, newMoped.Color, newMoped.Brand, "moped", 2));
        }
    }
}