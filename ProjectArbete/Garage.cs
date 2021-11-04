using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Garage : IEnumerable
    {
        public Car newCar = new("car", 4);

        public List<Vehicle> listOfVehicle = new();
        public IEnumerator GetEnumerator()
        {
            return listOfVehicle.GetEnumerator();
            throw new NotImplementedException();
        }

        public void AddVehicleToList()
        {
            Console.WriteLine("What kind of vehicle would you like to add?" +
                "\n1. Moped " +
                "\n2. Motorcycle " +
                "\n3. Car " +
                "\n4. Buss " +
                "\n5. Truck");

            int choice = ReadInt();
            switch (choice)
            {
                case 3:
                    // listOfVehicle
                    Console.WriteLine("Add registrationnumber: ");
                    newCar.RegNumber = Console.ReadLine();

                    Console.WriteLine("Write car color: ");
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
                    break;
                default:
                    break;
            }
        }

        static int ReadInt()
        {
            int number;
            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Not a valid option, please try again!");
            }
            return number;
        }
    }
}