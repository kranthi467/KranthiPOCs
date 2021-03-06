﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstructFactoryPattern
{
    /// <summary>
    /// The 'AbstractFactory' interface. 
    /// </summary>
    interface IComputer
    {
        ICpu GetCpu();
        IRam GetRam();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class.
    /// </summary>
    class HpFactory : IComputer
    {
        public ICpu GetCpu()
        {
            return new HpCpu();
        }

        public IRam GetRam()
        {
            return new HpRam();

        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class.
    /// </summary>
    class LenovoFactory : IComputer
    {
        public ICpu GetCpu()
        {
            return new LenovoCpu();
        }

        public IRam GetRam()
        {
            return new LenovoRam();
        }
    }

    /// <summary>
    /// The 'AbstractProductA' interface
    /// </summary>
    interface ICpu
    {
        string GetConfiguration();
    }

    /// <summary>
    /// The 'AbstractProductB' interface
    /// </summary>
    interface IRam
    {
        string GetConfiguration();
    }


    class LenovoCpu : ICpu
    {
        public string GetConfiguration()
        {
            throw new NotImplementedException();
        }
    }

    class HpCpu : ICpu
    {
        public string GetConfiguration()
        {
            throw new NotImplementedException();
        }
    }


    class LenovoRam : IRam
    {
        public string GetConfiguration()
        {
            throw new NotImplementedException();
        }
    }

    class HpRam : IRam
    {
        public string GetConfiguration()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>
    class ComputerClient
    {
        ICpu cpu;
        IRam ram;

        public ComputerClient(IComputer factory)
        {
            cpu = factory.GetCpu();
            ram = factory.GetRam();
        }

        public string GetCpuConfiguration()
        {
            return cpu.GetConfiguration();
        }

        public string GetRamConfiguration()
        {
            return ram.GetConfiguration();
        }
    }

    /// <summary>
    /// Abstract Factory Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IComputer lenovo = new LenovoFactory();
            ComputerClient lenovoclient = new ComputerClient(lenovo);

            Console.WriteLine("******* Lenovo **********");
            Console.WriteLine(lenovoclient.GetCpuConfiguration());
            Console.WriteLine(lenovoclient.GetRamConfiguration());



            Console.ReadKey();
        }
    }
}


