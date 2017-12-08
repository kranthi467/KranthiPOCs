using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstructFactory
{
    /// <summary>
    /// The 'AbstractProductA' interface
    /// </summary>
    interface IBike
    {
        string Name();
    }

    /// <summary>
    /// The 'AbstractProductB' interface
    /// </summary>
    interface IScooter
    {
        string Name();
    }
}
