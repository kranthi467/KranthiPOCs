using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAbstructFactory
{
    class Program
    {
        public interface ICar
        {
            IBody GetBody();
            Iwheels GetWheels();
            IEngine GetEngine();
        }

        public interface IBody
        {
            string GetBody();
        }
        public interface Iwheels
        {
            // implementation
        }
        public interface IEngine
        {
            // implementation
        }


        public class I10CarBody : IBody
        {
            public string GetBody()
            {
                throw new NotImplementedException();
            }
        }

        public class I20CarBody : IBody
        {
            public string GetBody()
            {
                throw new NotImplementedException();
            }
        }

      

        public class I10Car : ICar
        {
            public IBody GetBody()
            {
                return new I10CarBody();
            }

            public IEngine GetEngine()
            {
                throw new NotImplementedException();
            }

            public Iwheels GetWheels()
            {
                throw new NotImplementedException();
            }
        }

        public class I20Car : ICar
        {
            public IBody GetBody()
            {
                throw new NotImplementedException();
            }

            public IEngine GetEngine()
            {
                throw new NotImplementedException();
            }

            public Iwheels GetWheels()
            {
                throw new NotImplementedException();
            }
        }


        // simple factory
        public class CarSimpleFactory
        {
            public static ICar GetCar(string val)
            {
                switch (val)
                {
                    case "I10":
                        return new I10Car();

                    case "I20":
                        return new I20Car();

                    default:
                        return new I20Car(); // null object patten
                }
            }

        }


        public class Cleint
        {
            private IBody body;
            private Iwheels wheels;
            private IEngine engine;

            public void prepareCar(string cartype)
            {
                ICar car = CarSimpleFactory.GetCar(cartype);

                body = car.GetBody();
                wheels = car.GetWheels();
                engine = car.GetEngine();
            }
            private void ConstructCar()
            {
                var body = this.body;
                var wheels = this.wheels;
                var engine = this.engine;
            }
        }


        static void Main(string[] args)
        {
        }
    }
}
