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
        // It works!! It's alive!
        public IEnumerator<Vehicle> GetEnumerator()
        {
            return ((IEnumerable<Vehicle>)listOfVehicle).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)listOfVehicle).GetEnumerator();
        }

        public List<Vehicle> listOfVehicle = new();

        /// <summary>
        /// Removes a vehicles at index.
        /// </summary>
        public void RemoveVehicle()
        {
            Console.WriteLine("Please enter the space(index) you would like to remove.");

            int index = Menu.ReadInt();

            bool isEmpty = !listOfVehicle.Any();
            if (index <= 0 || isEmpty)
            {
                Console.WriteLine("No such space");
                Console.ReadLine();
            }
            else
            {
                listOfVehicle.RemoveAt(index - 1);
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
            truck.WeightClass = Console.ReadLine().ToLower();

            Console.WriteLine("Does it have a truckbed? y/n");
            string truckBed = Console.ReadLine().ToLower();

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
                    Console.WriteLine("Please answer y/n.");
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
            string combi = Console.ReadLine().ToLower();

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