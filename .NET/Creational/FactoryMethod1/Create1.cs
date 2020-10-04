using System;

namespace Factory.Abstract
{
    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    public abstract class Creator
    {
        public abstract Product FactoryMethodA();
        public abstract Product FactoryMethodB();
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethodA()
        {
            return new ConcreteProductA();
        }
        public override Product FactoryMethodB()
        {
            return new ConcreteProductB();
        }
    }

    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    public abstract class Product
    {
        public abstract void printProduct();
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductA : Product
    {
        public override void printProduct()
        {
            Console.WriteLine("Created {0}", this.GetType().Name);
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class ConcreteProductB : Product
    {
        public override void printProduct()
        {
            Console.WriteLine("Created {0}", this.GetType().Name);
        }
    }
}
