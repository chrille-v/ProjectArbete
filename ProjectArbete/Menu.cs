using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ProjectArbete
{
    public class Menu
    {
        private static bool loop;
        private static int choice;

        readonly static Garage garage = new Garage(30);

        public static void Run()
        {
            loop = true;
            ReadFileToGarage();
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
                        ListVehicle();
                        Console.ReadKey();
                        break;

                    case 5:
                        ListTypeVehicle();
                        Console.ReadKey();
                        break;

                    case 0:
                        Save();
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
                "\n1. Search registration number." +
                "\n2. Search by color." +
                "\n3. Find all with a specified number of wheels." +
                "\n4. Search by brand." +
                "\n5. Find all station wagons." +
                "\n6. Find trucks." +
                "\n0. Exit");
            Console.WriteLine("=======================================");

            SubMenu();
        }

        private static void SubMenu()
        {
            choice = ReadInt();
            // Hurray for lambda! :)
            switch (choice)
            {
                // registration number
                case 1:
                    SearchVehicle();
                    Console.ReadKey();
                    break;
                // Color
                case 2:
                    Console.WriteLine("Enter color: ");
                    string color = Console.ReadLine();

                    var byColor = garage.Where(x => x.Color == color);

                    foreach (var item in byColor)
                    {
                        Console.WriteLine("Reg. number: {0} \nType: {1}", item.RegNumber.ToUpper(), item.Type);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    break;

                // number of wheels
                case 3:
                    Console.WriteLine("Enter number of wheels: ");
                    int wheels = ReadInt();
                    var byWheels = garage.Where(x => x.NumberOfTires == wheels);

                    foreach (var item in byWheels)
                    {
                        Console.WriteLine("Reg. number: {0} \nType: {1}", item.RegNumber.ToUpper(), item.Type);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    break;
                // search brand
                case 4:
                    Console.WriteLine("Brand: ");
                    string brand = Console.ReadLine();

                    var byBrand = garage.Where(x => x.Brand == brand);

                    foreach (var item in byBrand)
                    {
                        Console.WriteLine("Reg. number: {0} \nType: {1}", item.RegNumber.ToUpper(), item.Type);
                        Console.WriteLine();
                    }
                    Console.ReadKey();
                    break;
                // Search by feature
                case 5:
                    Console.WriteLine("Station wagons: ");

                    foreach (var item in garage)
                    {
                        //Car car2 = item as Car;
                        if (item is Car car2)
                        {
                            Console.WriteLine("Reg. number: {0} \nType: {1} \nBrand:{2}", item.RegNumber.ToUpper(), item.Type, item.Brand);
                            Console.WriteLine();
                        }
                    }
                    Console.ReadKey();
                    break;

                case 6:
                    Console.WriteLine("Trucks: ");

                    foreach (var item in garage)
                    {
                        //Truck truck2 = item as Truck;
                        if (item is Truck truck2)
                        {
                            Console.WriteLine("Reg. number: {0} \nType: {1} \nBrand:{2}", item.RegNumber.ToUpper(), item.Type, item.Brand);
                            Console.WriteLine();
                        }
                    }
                    Console.ReadKey();
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// Parse string input to an int.
        /// </summary>
        /// <returns></returns>
        public static int ReadInt()
        {
            int number;
            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Not a valid option, please try again!");
            }
            return number;
        }
        /// <summary>
        /// Adds a vehicle to garage
        /// </summary>
        public static void AddVehicle()
        {
            if (garage.Count() >= garage.MaxLimit)
            {
                Console.WriteLine("Garage limit reached.");
                Console.ReadKey();
                return;
            }
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
        /// <summary>
        /// Searches for registration number.
        /// </summary>
        public static void SearchVehicle()
        {
            Console.WriteLine("Search for registration number to see if that vehicle is parked in the garage ");
            string searchRegNumber = Console.ReadLine();

            var result = garage.Where(x => x.RegNumber == searchRegNumber).ToList();

            foreach (var item in result)
            {
                Console.WriteLine("Color: \t \t{0}", item.Color);
                Console.WriteLine("Brand: \t \t{0}", item.Brand);
                Console.WriteLine("Type: \t \t{0}", item.Type);
            }
        }
        /// <summary>
        /// Prints out all vehicles in garage
        /// </summary>
        public static void ListVehicle()
        {
            Console.WriteLine("These are the vehicles currently in the garage: ");

            foreach (Vehicle item in garage)
            {
                // Pattern matching or 'as' with null check? First one.
                // Car car2 = item as Car;
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
                    Console.WriteLine("Weight class:   {0}", motorCycle2.WeightClass);
                    Console.WriteLine("Seats: \t \t{0}", motorCycle2.Seats);
                }

                if (item is Truck truck2)
                {
                    Console.WriteLine("Weight class:   {0}", truck2.WeightClass);
                    Console.WriteLine("Truck bed: \t{0}", truck2.TruckBed.ToString());
                }

                if (item is Buss buss2)
                {
                    Console.WriteLine("Dubbel decker: {0}", buss2.DubbelDecker);
                    Console.WriteLine("Seats: \t \t{0}", buss2.Seats);
                }

                Console.WriteLine("Reg number: \t{0}", item.RegNumber.ToUpper());
                Console.WriteLine("Color: \t \t{0}", item.Color);
                Console.WriteLine("Brand: \t \t{0}", item.Brand);
                Console.WriteLine("Type: \t \t{0}", item.Type);

                Console.WriteLine();
            }
        }

        public static void ListTypeVehicle()
        {
            // Lambda lambda lambda :D
            int totalVehicles = garage.Count();

            int mopeds = garage.Count(x => x.Type == "moped");
            int motorcycles = garage.Count(x => x.Type == "motorcycle");

            int cars = garage.Count(x => x.Type == "car");
            int trucks = garage.Count(x => x.Type == "truck");
            int busses = garage.Count(x => x.Type == "buss");

            Console.WriteLine("Vehicles currently in the garage: {0}", totalVehicles);

            Console.WriteLine("Mopeds: {0} \nMotorcycles: {1}\nCars: {2}", mopeds, motorcycles, cars);

            Console.WriteLine("Trucks: {0}\nBusses: {1}", trucks, busses);
        }
        //****************//
        //Save method to save garage in to txt.file
        public static void Save()
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(@"c:\file.txt", false, Encoding.UTF8);
                foreach (Vehicle item in garage)
                {
                    if (item is Car car2)
                    {
                        streamWriter.Write(car2.Combi.ToString()+" "+ car2.NumberOfSeats);
                    }

                    if (item is Moped moped2)
                    {
                        streamWriter.Write(moped2.MopedClass + " " + moped2.Seats);
                    }

                    if (item is MotorCycle motorCycle2)
                    {
                        streamWriter.Write(motorCycle2.WeightClass+" "+ motorCycle2.Seats);
                    }

                    if (item is Truck truck2)
                    {
                        streamWriter.Write(truck2.WeightClass+" "+ truck2.TruckBed.ToString());
                    }

                    if (item is Buss buss2)
                    {
                        streamWriter.Write(buss2.DubbelDecker+" "+ buss2.Seats);
                    }

                    streamWriter.WriteLine(" "+item.RegNumber.ToUpper()+" "+ item.Color+" "+ item.Brand+" "+ item.Type);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                if (streamWriter != null)
                {
                    Console.WriteLine("data is saved...");
                }
                streamWriter.Close();
            }
        }
        //**************************
        //ead method to load save file
        public static void ReadFileToGarage()
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(@"c:\file.txt");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(' ');
                    switch (fields[5])
                    {
                        case "car":
                            garage.listOfVehicle.Add(new Car(Convert.ToInt32(fields[1]),Convert.ToBoolean(fields[0]), fields[2], fields[3], fields[4], fields[5],0));
                            break;
                        case "buss":
                            garage.listOfVehicle.Add(new Buss(Convert.ToBoolean(fields[0]),Convert.ToInt32(fields[1]), fields[2], fields[3], fields[4], fields[5], 0));
                            break;
                        
                   }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                reader.Close();
            }
        }



    }
}