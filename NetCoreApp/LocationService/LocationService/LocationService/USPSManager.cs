using LocationService;
using Portal.ServiceModel.Address;
using System;
using System.Net;

namespace Portal.ServiceClient.Address
{
    class USPSManager
    {
        #region Private Members
        private string productionUrl = string.Empty;
        private string testingUrl = string.Empty;
        private string validationUrl = string.Empty;
        private WebClient web;
        private string _userid;
        public const string uspsValidationURL = "?API=Verify&XML=<AddressValidateRequest USERID=\"{0}\"><Address ID=\"{1}\"><Address1>{2}</Address1><Address2>{3}</Address2><City>{4}</City><State>{5}</State><Zip5>{6}</Zip5><Zip4>{7}</Zip4></Address></AddressValidateRequest>";
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new USPS Manager instance
        /// </summary>
        /// <param name="USPSWebtoolUserID">The UserID required by the USPS Web Tools</param>
        public USPSManager(string USPSWebtoolUserID)
        {
            web = new WebClient();
            _userid = USPSWebtoolUserID;
            TestMode = false;

        }
        /// <summary>
        /// Creates a new USPS Manager instance
        /// </summary>
        /// <param name="USPSWebtoolUserID">The UserID required by the USPS Web Tools</param>
        /// <param name="testmode">If True, then the USPS Test URL will be used.</param>
        public USPSManager(string USPSWebtoolUserID, bool testmode)
        {
            TestMode = testmode;
            web = new WebClient();
            _userid = USPSWebtoolUserID;
        }
        /// <summary>
        /// Determines if the Calls to the USPS server is made to the Test or Production server.
        /// </summary>
        public bool TestMode { get; set; }

        #endregion

        #region Address Methods
        /// <summary>
        /// Validate a single address
        /// </summary>
        /// <param name="address">Address object to be validated</param>
        /// <returns>Validated Address</returns>
        public USPSAddress ValidateAddress(AddressDTO address)
        {
            USPSAddress uspsAddress = new USPSAddress();
            uspsAddress.Address1 = address.Line1;
            uspsAddress.Address2 = address.Line2;
            uspsAddress.City = address.City;
            uspsAddress.State = address.State.StateCode;
            uspsAddress.Zip = address.ZipCode;
            uspsAddress.ZipPlus4 = string.Empty;

            productionUrl = "https://secure.shippingapis.com/ShippingAPI.dll";
            testingUrl = "http://production.shippingapis.com/ShippingAPI.dll";
            validationUrl = uspsValidationURL;

            try
            {

                string url = GetURL() + validationUrl;
                url = String.Format(url, _userid, uspsAddress.ID.ToString(), uspsAddress.Address1, uspsAddress.Address2,
                    uspsAddress.City, uspsAddress.State, uspsAddress.Zip, uspsAddress.ZipPlus4);
                string addressxml = web.DownloadString(url);
                
                return USPSAddress.FromXml(addressxml);
            }
            catch (WebException)
            {
            }
            return null;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// returns the USPS URL
        /// </summary>
        /// <returns></returns>
		private string GetURL()
        {
            string url = productionUrl;
            if (TestMode)
                url = testingUrl;
            return url;
        }
        #endregion
    }
}
