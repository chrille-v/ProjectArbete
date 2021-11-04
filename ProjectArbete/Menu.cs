using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Menu
    {
        private static bool loop;
        public static void Run()
        {
            loop = true;

            do
            {
                PrintOutMenu();
            } while (loop);
        }

        public static void PrintOutMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Park a new car " +
                "\n2. Remove car from garage." +
                "\n3. Search for vehicle " +
                "\n4. Exit");
        }
        public void SubMenu()
        {

        }
    }
}