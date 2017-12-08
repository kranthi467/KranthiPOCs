using DesignPatterns.Creational.FactoryMethod.Example1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod.Example1
{
    class FactoryMethodStart
    {
        public void start()
        {
            IVehicleFactory factory = new HondaVehicleFactory();

            IVehicle scooter = factory.GetVehicle("Scooter");
            scooter.Drive(10);

            IVehicle bike = factory.GetVehicle("Bike");
            bike.Drive(20);
        }

    }
}
