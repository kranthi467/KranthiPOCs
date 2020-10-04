using System;
using Factory.Abstract;
//using Factory.Method;

namespace Client
{
    /// <summary>
    /// MainApp startup class for Structural 
    /// Factory Method Design Pattern.
    /// </summary>
    #region FactoryMethod
    //class MainApp
    //{
    //    /// <summary>
    //    /// Entry point into console application.
    //    /// </summary>
    //    static void Main()
    //    {
    //        // An array of creators
    //        Creator[] creators = new Creator[2];

    //        creators[0] = new ConcreteCreatorA(); //To create concrete product A
    //        creators[1] = new ConcreteCreatorB(); //To create concrete product B

    //        // Iterate over creators and create products
    //        foreach (Creator creator in creators)
    //        {
    //            Product product = creator.FactoryMethod(); // To Do operation
    //            product.printProduct();
    //        }

    //        // Wait for user
    //        Console.ReadKey();
    //    }
    //}
    #endregion
    #region AbstractFactory
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            Creator creator = new ConcreteCreator();

            Product A = creator.FactoryMethodA();
            Product B = creator.FactoryMethodB();

            A.printProduct();
            B.printProduct();

            // Wait for user
            Console.ReadKey();
        }
    }
    #endregion
}
