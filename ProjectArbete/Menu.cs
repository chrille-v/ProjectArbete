using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Menu
    {
        private static bool loop;

        static Garage garage = new();
        static Car newCar = new("car", 4);

        public static void Run()
        {
            loop = true;

            do
            {
                PrintOutMenu();
                int choice = ReadInt();

                switch (choice)
                {
                    case 1:
                        AddVehicleToList();
                        break;
                    case 3:
                        SubMenu();
                        break;
                    case 4:
                        Console.WriteLine("Thank you, now exiting the program!");
                        loop = false;
                        break;
                    default:
                        break;
                }
            } while (loop);
        }

        private static void PrintOutMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Park a new car " +
                "\n2. Remove car from garage." +
                "\n3. Search for vehicle " +
                "\n4. Show all vehicles in garage" +
                "\n0. Exit");
        }
        private static void SubMenu()
        {

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

        public static void AddVehicleToList()
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


                    break;
                default:
                    break;
            }
        }
    }
}