using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstruct_FactoryPattern
{
    public abstract class AbstractProductA
    {
        public abstract void operationA1();
        public abstract void operationA2();
    }

    public class ProductA1 : AbstractProductA
    {
        public ProductA1(String arg)
        {

        } // Implement the code here

        public override void operationA1() { }
        public override void operationA2() { }
    }

    public class ProductA2 : AbstractProductA
    {
        public ProductA2(String arg)
        {

        } // Implement the code here

        public override void operationA1() { }
        public override void operationA2() { }
    }

    public abstract class AbstractProductB
    {
        //public abstract void operationB1();
        //public abstract void operationB2();
    }

    public class ProductB1 : AbstractProductB
    {
        public ProductB1(String arg)
        {

        } // Implement the code here
    }

    public class ProductB2 : AbstractProductB
    {
        public ProductB2(String arg)
        {

        } // Implement the code here
    }

    public abstract class AbstractFactory
    {
        public abstract AbstractProductA createProductA();
        public abstract AbstractProductB createProductB();
    }

    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA createProductA()
        {
            return new ProductA1("ProductA1");
        }
        public override AbstractProductB createProductB()
        {
            return new ProductB1("ProductB1");
        }
    }

    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA createProductA()
        {
            return new ProductA2("ProductA2");
        }
        public override AbstractProductB createProductB()
        {
            return new ProductB2("ProductB2");
        }
    }

    //Factory creator - an indirect way of instantiating the factories
    public class FactoryMaker
    {
        private static AbstractFactory pf = null;
        public static AbstractFactory getFactory(String choice)
        {
            if (choice.Equals("a"))
            {
                pf = new ConcreteFactory1();
            }
            else if (choice.Equals("b"))
            {
                pf = new ConcreteFactory2();
            }
            return pf;
        }
    }

    // Client
    public class Client
    {
        public static void main(String args[])
        {
            AbstractFactory pf = FactoryMaker.getFactory("a");
            AbstractProductA product = pf.createProductA();
            //more function calls on product
        }
    }
}
