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
        private static int choice;

        readonly static Garage garage = new();
        //readonly static Vehicle newVehicle = new();

        public static void Run()
        {
            loop = true;

            do
            {
                PrintOutMenu();
                choice = ReadInt();

                switch (choice)
                {
                    case 1:
                        AddVehicle();
                        break;

                    case 2:
                        garage.RemoveVehicle();
                        break;

                    case 3:
                        PrintSubMenu();
                        break;

                    case 4:
                        garage.ListVehicle();
                        Console.ReadKey();
                        break;

                    case 5:
                        garage.ListTypeVehicle();
                        Console.ReadKey();
                        break;

                    case 0:
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
            Console.WriteLine("============= The Garage ===============");
            Console.WriteLine("1. Park a new vehicle " +
                "\n2. Remove vehicle from garage." +
                "\n3. Search for vehicle " +
                "\n4. Show all vehicles in garage" +
                "\n5. List types of vehicles." +
                "\n0. Exit");
            Console.WriteLine("=======================================");
        }
        private static void PrintSubMenu()
        {
            Console.Clear();
            Console.WriteLine("========= Search Garage ==========");
            Console.WriteLine("Find a vehicle in the garage by adding a parameter." + 
                "\n1. To find with a registration number." +
                "\n2. To find all with colour." +
                "\n3. To find all with a specified number of wheels." + 
                "\n4. To find all with a max number of passengers."+ 
                "\n5. To find all with combi" +
                "\n0. Exit");
            
            SubMenu();
            Console.WriteLine("=======================================");
        }

        private static void SubMenu()
        {
            choice = ReadInt();

            switch (choice)
            {
                // registration number
                case 1:
                    Console.WriteLine(garage.SearchVehicle());
                    Console.ReadKey();
                    break;
                // Color
                case 2:
                    Console.WriteLine("Enter color: ");
                    string color = Console.ReadLine();
                    var byColor = garage.listOfVehicle.Where(x => x.Color == color);

                    foreach (var item in byColor)
                    {
                        Console.WriteLine("Reg. number: {0} \n Type: {1}", item.RegNumber, item.Type);
                    }
                    Console.ReadKey();
                    break;
                    
                // number of wheels
                case 3:
                    Console.WriteLine("Enter number of wheels: ");
                    int wheels = ReadInt();
                    var byWheels = garage.listOfVehicle.Where(x => x.NumberOfTires == wheels);

                    foreach (var item in byWheels)
                    {
                        Console.WriteLine("Reg. number: {0} \n Type: {1}", item.RegNumber, item.Type);
                    }
                    Console.ReadKey();
                    break;
                // search brand
                case 4:
                    Console.WriteLine("Brand: ");
                    string brand = Console.ReadLine();
                    var byBrand = garage.listOfVehicle.Where(x => x.Brand == brand);

                    foreach (var item in byBrand)
                    {
                        Console.WriteLine("Reg. number: {0} \n Type: {1}", item.Brand, item.Type);
                    }
                    Console.ReadKey();
                    break;
                // Search by feature
                case 5:
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

        public static void AddVehicle()
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
                    garage.ReadMoped();
                    break;

                case 2:
                    garage.ReadMotorCycle();
                    break;
                case 3:
                    garage.ReadCar();
                    break;

                case 4:
                    garage.ReadBuss();
                    break;

                case 5:
                    garage.ReadTruck();
                    break;

                case 0:
                    break;

                default:
                    break;
            }
        }
    }
}