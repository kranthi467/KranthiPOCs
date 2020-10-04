using System;

namespace Factory.Method
{
    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    public abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
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