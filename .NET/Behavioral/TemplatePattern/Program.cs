using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Behavioral.Template
{
    /// <summary>
    /// MainApp startup class for Real-World 
    /// Template Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            DataAccessObject daoCategories = new Categories();
            daoCategories.Run();

            DataAccessObject daoProducts = new Products();
            daoProducts.Run();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'AbstractClass' abstract class
    /// </summary>
    abstract class DataAccessObject
    {
        protected List<string> dataSet=new List<string>();

        public virtual void Connect()
        {
            Console.WriteLine("Connected..........");
        }

        public abstract void Select();
        public abstract void Process();

        public virtual void Disconnect()
        {
            Console.WriteLine("disconnected..........");
            Console.WriteLine();
        }

        // The 'Template Method' 
        public void Run()
        {
            Connect();
            Select();
            Process();
            Disconnect();
        }
    }

    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    class Categories : DataAccessObject
    {
        public override void Select()
        {
            dataSet.Add("Mobile");
            dataSet.Add("TV");
            dataSet.Add("Veicle");
        }

        public override void Process()
        {
            Console.WriteLine("Categories ---- ");
            
            foreach (string row in dataSet)
            {
                Console.WriteLine(row);
            }
        }
    }

    /// <summary>
    /// A 'ConcreteClass' class
    /// </summary>
    class Products : DataAccessObject
    {
        public override void Select()
        {
            dataSet.Add("Samsung");
            dataSet.Add("Nokia");
            dataSet.Add("Celcon");
        }

        public override void Process()
        {
            Console.WriteLine("Products ---- ");
            foreach (string row in dataSet)
            {
                Console.WriteLine(row);
            }
        }
    }
}
