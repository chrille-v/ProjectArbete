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
                        garage.AddVehicleToList();
                        break;

                    case 3:
                        SubMenu();
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

        
    }
}