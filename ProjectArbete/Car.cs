using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Car : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public bool Combi { get; set; }

        public Car()
        {

        }
        public Car(string _type, int _nrTires) : base(_type, _nrTires)
        {

        }

        public Car(int _numberOfSeats, bool _combi, string _regnumber, string _color, string _brand)
        {
            NumberOfSeats = _numberOfSeats;
            Combi = _combi;
            RegNumber = _regnumber;
            Color = _color;
            Brand = _brand;
        }
        public Car(int _numberOfSeats, bool _combi, string _regnumber, string _color, string _brand, string _type, int _nrTires) 
            : base(_regnumber, _color, _brand, _type, _nrTires)
        {
            NumberOfSeats = _numberOfSeats;
            Combi = _combi;
        }
    }
}