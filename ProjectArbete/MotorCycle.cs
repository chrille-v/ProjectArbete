using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class MotorCycle : Vehicle
    {
        private string weightClass;
        private int seats;
        
        public string WeightClass
        {
            get { return weightClass; }
            set
            {
                if (value == "light" || value == "middle" || value == "heavy")
                {
                    weightClass = value;
                }
                else
                {
                    weightClass = "N/A";
                }
            }
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

        public MotorCycle()
        {

        }

        public MotorCycle(string _weight, int _seats, string _regnumber, string _color, string _brand, string _type, int _nrTires)
            : base(_regnumber, _color, _brand, _type, _nrTires)
        {
            WeightClass = _weight;
            Seats = _seats;
        }
    }
}