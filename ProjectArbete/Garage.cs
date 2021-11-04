using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectArbete
{
    public class Garage : IEnumerable
    {
        List<Vehicle> listOfVehicle = new();
        public IEnumerator GetEnumerator()
        {
            return listOfVehicle.GetEnumerator();
            throw new NotImplementedException();
        }
    }
}