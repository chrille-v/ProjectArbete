using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Buss : Vehicle
    {
        public bool DubbelDecker { get; set; }
        public int Seats { get; set; }

        public Buss()
        {

        }

        public Buss(bool dubbelDecker, int _seats, string _regnumber, string _color, string _brand, string _type, int _nrTires)
            : base(_regnumber, _color, _brand, _type, _nrTires)
        {
            DubbelDecker = dubbelDecker;
            Seats = _seats;
        }
    }
}