using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstructFactory
{
    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class RegularBike : IBike
    {
        public string Name()
        {
            return "Regular Bike- Name";
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class SportsBike : IBike
    {
        public string Name()
        {
            return "Sports Bike- Name";
        }
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class RegularScooter : IScooter
    {
        public string Name()
        {
            return "Regular Scooter- Name";
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Scooty : IScooter
    {
        public string Name()
        {
            return "Scooty- Name";
        }
    }

}
