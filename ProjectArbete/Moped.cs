using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Moped : Vehicle
    {
        public string WeightClass { get; set; }
        private int seats;

        public Moped()
        {

        }

        public Moped(string _weight, int _seats, string _regnumber, string _color, string _brand, string _type, int _nrTires) 
            : base(_regnumber, _color, _brand, _type, _nrTires)
        {
            WeightClass = _weight;
            Seats = _seats;
        }

        public int Seats
        {
            get { return seats; }
            set
            {
                if (value == 1 || value == 2)
                {
                    seats = value;
                }
                else
                {
                    seats = 1;
                }
            }
        }
    }
}