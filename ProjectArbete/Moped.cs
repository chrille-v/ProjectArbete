using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Moped : Vehicle
    {
        private string mopedClass;
        private int seats;

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

        public string MopedClass
        {
            get { return mopedClass; }
            set
            {
                if (value == "class1" || value == "class2")
                {
                    mopedClass = value;
                }
                else
                {
                    mopedClass = "N/A";
                }
            }
        }
        public Moped()
        {

        }

        public Moped(string _weight, int _seats, string _regnumber, string _color, string _brand, string _type, int _nrTires) 
            : base(_regnumber, _color, _brand, _type, _nrTires)
        {
            MopedClass = _weight;
            Seats = _seats;
        }
    }
}