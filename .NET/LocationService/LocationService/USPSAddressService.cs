using LocationService;
using Portal.ServiceClient.Address;
using Portal.ServiceModel.Address;

namespace Portal.ServiceClient.Address
{
    public class USPSAddressService
    {
        public USPSAddressService()
        {
        }

        /// <summary>
        /// returns the standardized address from USPS service
        /// </summary>
        /// <param name="addressRequest"></param>
        /// <returns></returns>
        public AddressDTO GetStandardizedAddess(AddressDTO addressRequest)
        {
            string userId = "366GGKTE4390";
            USPSAddress validatedAddress = new USPSAddress();

            if (addressRequest != null)
            {
                USPSAddress addressResponse = new USPSAddress();
                USPSManager uspsManager = new USPSManager(userId);

                ///By calling ValidateAddress on the USPSManager object,
                ///you get an Address object that has been validated by the
                ///USPS servers
                validatedAddress = uspsManager.ValidateAddress(addressRequest);

            }

            return ToAddressDTO(validatedAddress);
        }
        /// <summary>
        /// Converts to AddressDTO from USPSAddress
        /// </summary>
        /// <param name="validatedAddress"></param>
        /// <returns></returns>
        private AddressDTO ToAddressDTO(USPSAddress validatedAddress)
        {
            AddressDTO addressDTO = new AddressDTO();
            if (validatedAddress != null)
            {
                if(validatedAddress.Error != null)
                {
                    addressDTO.Line1 = validatedAddress.Address1;
                    addressDTO.Line2 = validatedAddress.Address2;
                    addressDTO.City = validatedAddress.City;
                    addressDTO.ZipCode = validatedAddress.Zip + "-" + validatedAddress.ZipPlus4;
                    addressDTO.State.StateCode = validatedAddress.State;
                }
                else
                {
                    addressDTO.Error = validatedAddress.Error;
                }
            }
            return addressDTO;
        }
    }
}
