using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod.Example1
{
    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class IVehicleFactory
    {
        public abstract IVehicle GetVehicle(string Vehicle);

    }
}
