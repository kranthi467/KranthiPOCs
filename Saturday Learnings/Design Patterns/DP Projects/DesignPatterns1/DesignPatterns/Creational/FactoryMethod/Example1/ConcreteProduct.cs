using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod.Example1
{
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class HondaScooter : IVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class HondaBike : IVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }
    }

}
