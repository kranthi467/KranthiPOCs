using Portal.ServiceClient.Address;
using System;
using System.Text;

namespace Portal.ServiceModel.Address
{
    [Serializable()]
    public class USPSAddress
    {
        public USPSAddress()
        {
            this._ID = 1;
            this.Error = null;
        }

        private int _ID;
        /// <summary>
        /// ID of this address
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Address1 = "";
        /// <summary>
        /// Address Line 1 is used to provide an apartment or suite
        /// number, if applicable. Maximum characters allowed: 38
        /// </summary>
        public string Address1
        {
            get { return _Address1; }
            set
            {
                if (value?.Length > 38)
                    throw new USPSManagerException("Address1 is is limited to a maximum of 38 characters.");
                _Address1 = value;
            }
        }

        private string _Address2 = "";
        /// <summary>
        /// Street address
        /// Maximum characters allowed: 38
        /// </summary>
        public string Address2
        {
            get { return _Address2; }
            set
            {
                if (value?.Length > 38)
                    throw new USPSManagerException("Address2 is is limited to a maximum of 38 characters.");
                _Address2 = value;
            }
        }

        private string _City = "";
        /// <summary>
        /// City
        /// Either the City and State or Zip are required.
        /// Maximum characters allowed: 15
        /// </summary>
        public string City
        {
            get { return _City; }
            set
            {
                if (value?.Length > 15)
                    throw new USPSManagerException("City is is limited to a maximum of 15 characters.");
                _City = value;
            }
        }

        private string _State = "";
        /// <summary>
        /// State
        /// Either the City and State or Zip are required.
        /// Maximum characters allowed = 2
        /// </summary>
        public string State
        {
            get { return _State; }
            set
            {
                if (value?.Length > 2)
                    throw new USPSManagerException("State is is limited to a maximum of 2 characters.");
                _State = value;
            }
        }

        private string _Zip = "";
        /// <summary>
        /// Zipcode
        /// Maximum characters allowed = 5
        /// </summary>
        public string Zip
        {
            get { return _Zip; }
            set
            {
                if (value?.Length > 5)
                    throw new USPSManagerException("Zip is is limited to a maximum of 5 characters.");
                _Zip = value;
            }
        }

        private string _ZipPlus4 = "";
        /// <summary>
        /// Zip code extension
        /// Maximum characters allowed = 4
        /// </summary>
        public string ZipPlus4
        {
            get { return _ZipPlus4; }
            set
            {
                if (value?.Length > 5)
                    throw new USPSManagerException("Zip is is limited to a maximum of 5 characters.");
                _ZipPlus4 = value;
            }
        }

        public string Error { get; set; }

        /// <summary>
        /// Get an Address object from an xml string.
        /// </summary>
        /// <param name="xml">XML representation of an Address Object</param>
        /// <returns>Address object</returns>
        public static USPSAddress FromXml(string xml)
        {
            USPSAddress newAddress = new USPSAddress();

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.LoadXml(xml);

            System.Xml.XmlNode element = doc.SelectSingleNode("/AddressValidateResponse/Address/Error");
            if (element != null)
                newAddress.Error = element.InnerText;
            else
            {
                element = doc.SelectSingleNode("/AddressValidateResponse/Address/Address1");
                if (element != null)
                    newAddress._Address1 = element.InnerText;
                element = doc.SelectSingleNode("/AddressValidateResponse/Address/Address2");
                if (element != null)
                    newAddress._Address2 = element.InnerText;
                element = doc.SelectSingleNode("/AddressValidateResponse/Address/City");
                if (element != null)
                    newAddress._City = element.InnerText;
                element = doc.SelectSingleNode("/AddressValidateResponse/Address/State");
                if (element != null)
                    newAddress._State = element.InnerText;
                element = doc.SelectSingleNode("/AddressValidateResponse/Address/Zip5");
                if (element != null)
                    newAddress._Zip = element.InnerText;
                element = doc.SelectSingleNode("/AddressValidateResponse/Address/Zip4");
                if (element != null)
                    newAddress._ZipPlus4 = element.InnerText;
            }

            return newAddress;
        }

        /// <summary>
        /// Get the Xml representation of this address object
        /// </summary>
        /// <returns>String</returns>
        public string ToXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Address ID=\"" + this.ID.ToString() + "\">");
            sb.Append("<Address1>" + this._Address1 + "</Address1>");
            sb.Append("<Address2>" + this._Address2 + "</Address2>");
            sb.Append("<City>" + this.City + "</City>");
            sb.Append("<State>" + this.State + "</State>");
            sb.Append("<Zip5>" + this.Zip + "</Zip5>");
            sb.Append("<Zip4>" + this.ZipPlus4 + "</Zip4>");
            sb.Append("</Address>");
            return sb.ToString();
        }
    }
}

