using System;
using Behavioral.Strategy;

namespace Client
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Strategy Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        #region WithoutFactory
        //static void Main()
        //{
        //    Context context;

        //    //Three contexts following different strategies
        //   context = new Context(new ConcreteStrategyA());
        //    context.ContextInterface();

        //    context = new Context(new ConcreteStrategyB());
        //    context.ContextInterface();

        //    context = new Context(new ConcreteStrategyC());
        //    context.ContextInterface();

        //    //Wait for user

        //   Console.ReadKey();
        //}
        #endregion
        #region WithFactory
        static void Main()
        {
            Context context;

            Factory factory = new ConcreteFactory();
            // Three contexts following different strategies
            context = new Context(factory.FactoryMethodA());
            context.ContextInterface();

            context = new Context(factory.FactoryMethodB());
            context.ContextInterface();

            context = new Context(factory.FactoryMethodC());
            context.ContextInterface();

            // Wait for user
            Console.ReadKey();
        }
        #endregion
    }
}
