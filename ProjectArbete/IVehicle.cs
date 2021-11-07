using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public interface IVehicle
    {
        public string Brand { get; set; }
        public string Color { get; set; }
        public int NumberOfTires { get; set; }
        public string RegNumber { get; set; }
        public string Type { get; set; }
    }
}