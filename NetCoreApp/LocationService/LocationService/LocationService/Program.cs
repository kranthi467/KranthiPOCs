using Portal.ServiceClient.Address;
using System;

namespace LocationService
{
    class Program
    {
        public static void Main(string[] args)
        {
            USPSAddressService service = new USPSAddressService();
            AddressDTO addressRequest = new AddressDTO();

            Console.WriteLine("Enter Line1: ");
            addressRequest.Line1 = Console.ReadLine();

            Console.WriteLine("Enter Line2: ");
            addressRequest.Line2 = Console.ReadLine();

            Console.WriteLine("Enter City: ");
            addressRequest.City = Console.ReadLine();

            Console.WriteLine("Enter StateCode: ");
            addressRequest.State.StateCode = Console.ReadLine();

            Console.WriteLine("Enter ZipCode: ");
            addressRequest.ZipCode = Console.ReadLine();

            AddressDTO addressResponse = service.GetStandardizedAddess(addressRequest);

            Console.WriteLine(addressResponse.Line1);

            Console.WriteLine(addressResponse.Line2);

            Console.WriteLine(addressResponse.City);

            Console.WriteLine(addressResponse.State.StateCode);

            Console.WriteLine(addressResponse.ZipCode);

            Console.WriteLine(addressResponse.Error);

            Console.ReadLine();

        }

    }
}
