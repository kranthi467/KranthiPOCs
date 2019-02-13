namespace LocationService
{
    public class AddressDTO
    {
        #region public properties
        public int AddressID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public CountyDTO County { get; set; }
        public StateDTO State { get; set; }
        public CountryDTO Country { get; set; }
        public int? CountyId { get; set; }
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public string Error { get; set; }

        #endregion public properties

        #region constructor
        public AddressDTO()
        {
            County = new CountyDTO();
            State = new StateDTO();
            Country = new CountryDTO();
        }
        #endregion constructor
    }

    public class CountyDTO
    {
        public int CountyId { get; set; }

        public int CountyFipsCode { get; set; }

        public string CountyName { get; set; }

        public StateDTO State { get; set; }
    }

    public class StateDTO
    {
        #region constructor
        public StateDTO()
        {
            Country = new CountryDTO();
        }
        #endregion constructor

        #region public properties
        public CountryDTO Country { get; set; }

        public int StateID { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public int CountryID { get; set; }

        public bool IsDefault { get; set; }

        #endregion public properties
    }

    public class CountryDTO
    {
        public int CountryID { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string ISOAlpha3CountryCode { get; set; }
        public int PhoneCode { get; set; }
        public string DefaultCurrencyCode { get; set; }
    }
}
