using System;
namespace Factory
{
    /// <summary>
    /// The 'Product' interface
    /// </summary>
    public interface IVehicle
    {
        void Drive(int miles);
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Scooter : IVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Bike : IVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class VehicleFactory
    {
        public abstract IVehicle GetVehicle(string Vehicle);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteTwoVehicleFactory : VehicleFactory
    {
        public override IVehicle GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new Scooter();
                case "Bike":
                    return new Bike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteFourVehicleFactory : VehicleFactory
    {
        public override IVehicle GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Car":
                    return new Scooter();
                case "Auto(Tata AC)":
                    return new Bike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }


    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class VehicleTypeFactory
    {
        public abstract VehicleFactory GetVehicleType(string VehicleType);

    }



    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteVehicleTypeFactory : VehicleTypeFactory
    {
        public override VehicleFactory GetVehicleType(string Vehicle)
        {
            switch (Vehicle)
            {
                case "four":
                    return new ConcreteFourVehicleFactory();
                case "three":
                    return new ConcreteTwoVehicleFactory();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }


    public class vehicleClient
    {
        VehicleFactory factory;
        public vehicleClient(ConcreteVehicleTypeFactory concreteVehicleTypeFactory, string type)
        {
            factory = concreteVehicleTypeFactory.GetVehicleType(type);
        }

        public void GetScooterrate()
        {
            IVehicle scooter = factory.GetVehicle("Scooter");
            scooter.Drive(10);
        }

        public void GetScooteghrrate()
        {
            IVehicle bike = factory.GetVehicle("Bike");
            bike.Drive(20);
        }
        
    }

    /// <summary>
    /// Factory Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteVehicleTypeFactory concreteVehicleTypeFactory = new ConcreteVehicleTypeFactory();
            vehicleClient vehicleClient = new vehicleClient(concreteVehicleTypeFactory,"two");
            
            Console.ReadKey();

        }
    }
}