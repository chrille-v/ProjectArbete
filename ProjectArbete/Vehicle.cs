using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Vehicle
    {
        public string RegNumber{ get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int NumberOfTires { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(int _regnumber, string _color, string _brand, string _type, int _nrTires)
        {
            RegNumber = _regnumber;
            Color = _color;
            Brand = _brand;
            Type = _type;
            NumberOfTires = _nrTires;
        }
    }
}