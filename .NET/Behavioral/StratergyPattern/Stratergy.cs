using System;

namespace Behavioral.Strategy
{
    /// <summary>
    /// The 'Context' class
    /// </summary>
    public class Context
    {
        private Strategy _strategy;

        // Constructor
        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    public abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    #region ConcreteStrategy
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
              "Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
              "Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine(
              "Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }
    #endregion
    #region Factory
    public abstract class Factory
    {
        public abstract Strategy FactoryMethodA();
        public abstract Strategy FactoryMethodB();
        public abstract Strategy FactoryMethodC();
    }

    public class ConcreteFactory : Factory
    {
        public override Strategy FactoryMethodA()
        {
            return new ConcreteStrategyA();
        }

        public override Strategy FactoryMethodB()
        {
            return new ConcreteStrategyB();
        }

        public override Strategy FactoryMethodC()
        {
            return new ConcreteStrategyC();
        }
    }
    #endregion
}