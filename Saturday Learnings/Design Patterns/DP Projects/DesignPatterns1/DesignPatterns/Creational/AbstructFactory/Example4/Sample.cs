using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAbstructFactory
{
    class Program
    {
        #region Products
        public interface IBody
        {
            string GetBodyConfiguration();
        }
        public interface Iwheels
        {
            string GetWheelsConfiguration();
        }
        public interface IEngine
        {
            string GetEngineConfiguration();
        }
        #endregion

        #region Concrete Products
        public class I10CarBody : IBody
        {
            public string GetBodyConfiguration()
            {
                throw new NotImplementedException();
            }
        }

        public class I20CarBody : IBody
        {
            public string GetBodyConfiguration()
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Abstruct Factory
        public interface ICar
        {
            IBody GetBody();
            Iwheels GetWheels();
            IEngine GetEngine();
        }
        #endregion

        #region Concrete Factory
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
        #endregion

        #region Client
        public class Cleint
        {
            private IBody body;
            private Iwheels wheels;
            private IEngine engine;

            public Cleint(string cartype)
            {
                ICar car = CarSimpleFactory.GetCar(cartype);

                body = car.GetBody();
                wheels = car.GetWheels();
                engine = car.GetEngine();
            }

            public string GetBodyConfiguration()
            {
                return body.GetBodyConfiguration();
            }

            public string GetWheelsConfiguration()
            {
                return wheels.GetWheelsConfiguration();
            }

            public string GetEngineConfiguration()
            {
                return engine.GetEngineConfiguration();
            }
        }
        #endregion

        #region Simple Factory (to select the family)
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
        #endregion

        #region Main
        public class StartExample3
        {
            public void GetResult()
            {
                Cleint cleint = new Cleint("I10");

                cleint.GetBodyConfiguration();
                cleint.GetEngineConfiguration();
                cleint.GetWheelsConfiguration();
            }

        }
        #endregion
    }
}
