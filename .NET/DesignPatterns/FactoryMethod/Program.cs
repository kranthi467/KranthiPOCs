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
    public class BazazScooter : IVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scooter : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class BazazBike : IVehicle
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike : " + miles.ToString() + "km");
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public interface IVehicleFactory
    {
        IVehicle GetVehicle(string Vehicle);

    }


    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class BazazVehicleFactory : IVehicleFactory
    {
        public IVehicle GetVehicle(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Scooter":
                    return new BazazScooter();
                case "Bike":
                    return new BazazBike();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }

    /// <summary>
    /// Factory Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IVehicleFactory factory = new ConcreteVehicleFactory();

            IVehicle scooter = factory.GetVehicle("Scooter");
            scooter.Drive(10);

            IVehicle bike = factory.GetVehicle("Bike");
            bike.Drive(20);

            Console.ReadKey();

        }
    }
}