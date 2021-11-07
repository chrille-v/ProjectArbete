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

        public int MaxLimit { get; set; }
        public Garage(int maxLimit)
        {
            MaxLimit = maxLimit;
        }

        public IEnumerator<Vehicle> GetEnumerator()
        {
            return ((IEnumerable<Vehicle>)listOfVehicle).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)listOfVehicle).GetEnumerator();
        }

        public List<IVehicle> listOfVehicle = new();
        /// <summary>
        /// Writes out all vehicles in garage.
        /// </summary>
        public void ListVehicle()
        {
            Console.WriteLine("These are the vehicles currently in the garage: ");
            
            foreach (IVehicle item in listOfVehicle)
            {
                // Pattern matching or 'as' with null check? 
                //Car car2 = item as Car;
                if (item is Car car2)
                {
                    Console.WriteLine("Station wagon: {0}", car2.Combi.ToString());
                    Console.WriteLine("Seats: \t \t{0}", car2.NumberOfSeats);
                }

                if (item is Moped moped2)
                {
                    Console.WriteLine("Moped class: {0}", moped2.MopedClass);
                    Console.WriteLine("Seats: \t \t{0}", moped2.Seats);
                }

                if (item is MotorCycle motorCycle2)
                {
                    Console.WriteLine("Seats: {0}", motorCycle2.Seats);
                    Console.WriteLine("Weight class: {0}", motorCycle2.WeightClass);
                }

                if (item is Truck truck2)
                {
                    Console.WriteLine("Weight class: {0}", truck2.WeightClass);
                    Console.WriteLine("Truck bed: {0}", truck2.TruckBed.ToString());
                }

                if (item is Buss buss2)
                {
                    Console.WriteLine("Dubbel decker: {0}", buss2.DubbelDecker);
                    Console.WriteLine("Seats: {0}", buss2.Seats);
                }

                Console.WriteLine("Reg number: \t{0}", item.RegNumber);
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

            Console.WriteLine("Mopeds: {0} \nMotorcycles: {1}\nCars: {2}", mopeds, motorcycles, cars);

            Console.WriteLine("Trucks: {0}\nBusses: {1}", trucks, busses);
        }
        /// <summary>
        /// Removes a vehicles at index.
        /// </summary>
        public void RemoveVehicle()
        {
            Console.WriteLine("Please enter the space(index) you would like to empty.");

            int index = Menu.ReadInt();

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
        /// Searches Vehicles for reg.nr.
        /// </summary>
        public void SearchVehicle()
        {
            Console.WriteLine("Search for registration number to see if that vehicle is parked in the garage ");
            string searchRegNumber = Console.ReadLine();

            var result = listOfVehicle.Where(x => x.RegNumber == searchRegNumber).ToList();

            foreach (var item in result)
            {
                Console.WriteLine("Color: \t \t{0}", item.Color);
                Console.WriteLine("Brand: \t \t{0}", item.Brand);
                Console.WriteLine("Type: \t \t{0}", item.Type);
            }
        }

        public void ReadMotorCycle()
        {
            Console.WriteLine("Write registration number: ");
            motorBike.RegNumber = Console.ReadLine().ToLower();

            Console.WriteLine("Light, middle or heavy motorcyle? ");
            motorBike.WeightClass = Console.ReadLine().ToLower();

            Console.WriteLine("How many seats?");
            motorBike.Seats = Menu.ReadInt();

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

            Console.WriteLine("Is it a dubbeldecker? y/n");
            string dubbelDecker = Console.ReadLine().ToLower();

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
            buss.Seats = Menu.ReadInt();

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
            newCar.NumberOfSeats = Menu.ReadInt();

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
            newMoped.Seats = Menu.ReadInt();

            Console.WriteLine("What color? ");
            newMoped.Color = Console.ReadLine().ToLower();

            Console.WriteLine("Enter brand:");
            newMoped.Brand = Console.ReadLine().ToLower();

            listOfVehicle.Add(new Moped(newMoped.MopedClass, newMoped.Seats, newMoped.RegNumber, newMoped.Color, newMoped.Brand, "moped", 2));
        }
    }
}