using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Truck : Vehicle
    {
        private string weightClass;
        public bool TruckBed { get; set; }

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

        public Truck()
        {

        }

        public Truck(string _weightClass, bool _truckBed, string _regnumber, string _color, string _brand, string _type, int _nrTires)
            : base(_regnumber, _color, _brand, _type, _nrTires)
        {
            WeightClass = _weightClass;
            TruckBed = _truckBed;
        }
    }
}