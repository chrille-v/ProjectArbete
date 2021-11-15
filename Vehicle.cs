using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Vehicle : IVehicle
    {
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int NumberOfTires { get; set; }

        public Vehicle()
        {

        }
        public Vehicle(string _type, int _nrTires)
        {
            Type = _type;
            NumberOfTires = _nrTires;
        }

        public Vehicle(string _regnumber, string _color, string _brand, string _type, int _nrTires) : this(_type, _nrTires)
        {
            RegNumber = _regnumber;
            Color = _color;
            Brand = _brand;
        }
    }
}