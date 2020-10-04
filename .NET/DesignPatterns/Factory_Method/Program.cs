using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    public interface Product
    {
        void doWork();

    }

    public class ConcreteProduct : Product
    {
        public void doWork()
        {
            // Method intentionally left empty.
        }
    }


    public abstract class Creator
    {
        public void anOperation()
        {
            // Method intentionally left empty.
        }

        public abstract Product factoryMethod(string type);
    }



    public class ConcreteCreator : Creator
    {
        public override Product factoryMethod(string type)
        {
            return new ConcreteProduct();
        }
    }

    public class Client
    {
        public static void main(String arg[] )
        {
            Creator creator = new ConcreteCreator();
            Product product = creator.factoryMethod("type");
            product.doWork();

        }
    }
}
