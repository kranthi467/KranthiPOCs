using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod.Example1
{
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class HondaVehicleFactory : IVehicleFactory
    {
        public override IVehicle GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new HondaScooter();
                case "Bike":
                    return new HondaBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }
}
