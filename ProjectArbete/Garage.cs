using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Garage : IEnumerable<Vehicle>
    {
        public Car newCar = new();
        public Moped newMoped = new();
        public MotorCycle motorBike = new();
        public Truck truck = new();
        public Buss buss = new();

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
                Console.WriteLine("Reg number: \t{0}\n", item.RegNumber.ToUpper());
                Console.WriteLine("Color: \t \t{0}", item.Color);
                Console.WriteLine("Brand: \t \t{0}", item.Brand);
                Console.WriteLine("Type: \t \t{0}", item.Type);

                Console.WriteLine();
            }
        }
        /// <summary>
        /// List the different types of vehicles currently in 
        /// the garage, and how many of each.
        /// </summary>
        public void ListTypeVehicle()
        {
            int totalVehicles = listOfVehicle.Count;

            Console.WriteLine("Vehicles currently in the garage: {0}", totalVehicles);

            int mopeds = listOfVehicle.Count(x => x.Type == "moped");
            int motorcycles = listOfVehicle.Count(x => x.Type == "motorcycle");

            int cars = listOfVehicle.Count(x => x.Type == "car");
            int trucks = listOfVehicle.Count(x => x.Type == "truck");
            int busses = listOfVehicle.Count(x => x.Type == "buss");

            Console.WriteLine("Mopeds: {0}", mopeds);
            Console.WriteLine("Motorcycles: {0}", motorcycles);

            Console.WriteLine("Cars: {0}", cars);
            Console.WriteLine("Trucks: {0}", trucks);
            Console.WriteLine("Busses: {0}", busses);
        }

        public void RemoveVehicle()
        {
            Console.WriteLine("Please enter the space(index) you would like to empty.");

            int index = ReadInt();

            if (index <= 0)
            {
                Console.WriteLine("No such space");
                Console.ReadLine();
            }
            else
            {
                listOfVehicle.RemoveAt(index - 1);
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

        public static int ReadInt()
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
            Console.WriteLine("Write registration number: ");
            motorBike.RegNumber = Console.ReadLine().ToLower();

            Console.WriteLine("Light, middle or heavy motorcyle? ");
            motorBike.WeightClass = Console.ReadLine().ToLower();

            Console.WriteLine("How many seats?");
            motorBike.Seats = ReadInt();

            Console.WriteLine("What color? ");
            motorBike.Color = Console.ReadLine().ToLower();

            Console.WriteLine("Enter brand:");
            motorBike.Brand = Console.ReadLine().ToLower();

            listOfVehicle.Add(new MotorCycle(motorBike.WeightClass, motorBike.Seats, motorBike.RegNumber, motorBike.Color, motorBike.Brand, "motorcycle", 2));
        }

        public void ReadTruck()
        {
            Console.WriteLine("Write registration number: ");
            truck.RegNumber = Console.ReadLine();

            Console.WriteLine("What color? ");
            truck.Color = Console.ReadLine();

            Console.WriteLine("Enter brand:");
            truck.Brand = Console.ReadLine();

            Console.WriteLine("Please enter weightclass: light/middle/heavy");
            truck.WeightClass = Console.ReadLine();

            Console.WriteLine("Does it have a truckbed? y/n");
            string truckBed = Console.ReadLine();

            switch (truckBed)
            {
                case "y":
                    truck.TruckBed = true;
                    break;

                case "n":
                    truck.TruckBed = false;
                    break;
                default:
                    Console.WriteLine("Please answer yes or no.");
                    break;
            }

            listOfVehicle.Add(new Truck(truck.WeightClass, truck.TruckBed, truck.RegNumber, truck.Color, truck.Brand, "truck", 4));
        }

        public void ReadBuss()
        {
            Console.WriteLine("Write registration number: ");
            buss.RegNumber = Console.ReadLine();

            Console.WriteLine("What color? ");
            buss.Color = Console.ReadLine();

            Console.WriteLine("Enter brand:");
            buss.Brand = Console.ReadLine();

            Console.WriteLine("Is it a dubbeldecker?");
            string dubbelDecker = Console.ReadLine();

            switch (dubbelDecker)
            {
                case "y":
                    buss.DubbelDecker = true;
                    break;

                case "n":
                    buss.DubbelDecker = false;
                    break;
                default:
                    Console.WriteLine("Please answer yes or no.");
                    break;
            }

            Console.WriteLine("Number of seats: ");
            buss.Seats = ReadInt();

            listOfVehicle.Add(new Buss(buss.DubbelDecker, buss.Seats, buss.RegNumber, buss.Color, buss.Brand, "buss", 8));
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

            Console.WriteLine("Is it a station wagon? y/n");
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