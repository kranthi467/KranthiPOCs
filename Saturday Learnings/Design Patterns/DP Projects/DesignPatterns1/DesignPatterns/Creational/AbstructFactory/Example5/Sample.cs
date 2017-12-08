using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstructFactory.Example5
{
    class Sample
    {
        public abstract class CarFactory
        {
            public abstract SportsCar CreateSportsCar();
            public abstract FamilyCar CreateFamilyCar();
        }

        public class AudiFactory : CarFactory
        {
            public override SportsCar CreateSportsCar()
            {
                return new AudiSportsCar();
            }

            public override FamilyCar CreateFamilyCar()
            {
                return new AudiFamilyCar();
            }
        }

        public class MercedesFactory : CarFactory
        {
            public override SportsCar CreateSportsCar()
            {
                return new MercedesSportsCar();
            }

            public override FamilyCar CreateFamilyCar()
            {
                return new MercedesFamilyCar();
            }
        }

        public abstract class SportsCar
        {

        }

        public abstract class FamilyCar
        {
            public abstract void Speed(SportsCar abstractFamilyCar);
        }

        class MercedesSportsCar : SportsCar
        {
        }

        class MercedesFamilyCar : FamilyCar
        {
            public override void Speed(SportsCar abstractSportsCar)
            {
                Console.WriteLine(GetType().Name + " is slower than "
                    + abstractSportsCar.GetType().Name);
            }
        }

        class AudiSportsCar : SportsCar
        {
        }

        class AudiFamilyCar : FamilyCar
        {
            public override void Speed(SportsCar abstractSportsCar)
            {
                Console.WriteLine(GetType().Name + " is slower than "
                    + abstractSportsCar.GetType().Name);
            }
        }



        public class Driver
        {
            public CarFactory CarFactory;
            public SportsCar SportsCar;
            public FamilyCar FamilyCar;

            public Driver(CarFactory carFactory)
            {
                CarFactory = carFactory;
                SportsCar = CarFactory.CreateSportsCar();
                FamilyCar = CarFactory.CreateFamilyCar();
            }


            public void CompareSpeed()
            {
                FamilyCar.Speed(SportsCar);
            }
        }


        public class GenericFactory<T> where T : new()
        {
            public T CreateObject()
            {
                return new T();
            }
        }


        public static void StartExample5()
        {
            CarFactory audiFactory = new AudiFactory();
            Driver driver1 = new Driver(audiFactory);
            driver1.CompareSpeed();

            CarFactory mercedesFactory = new MercedesFactory();
            Driver driver2 = new Driver(mercedesFactory);
            driver2.CompareSpeed();

            // C# specific version using generics
            var factory = new GenericFactory<MercedesSportsCar>();
            var mercedesSportsCar = factory.CreateObject();
            Console.WriteLine(mercedesSportsCar.GetType().ToString());

            Console.ReadKey();
        }


    }
}
