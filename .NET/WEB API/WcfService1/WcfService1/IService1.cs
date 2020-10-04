using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        string NotAContractMethod();

        [OperationContract]
        string GetGreeting(string name);

        [OperationContract]
        CompositeType Sample(CompositeType abc,Random ran);

        [OperationContract]
        int AddData(int firstNum, int secondNum);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    [DataContract]

    public class Random
    {
        [DataMember]
        public int Random1 { get; set; }
        [DataMember]
        public int Random2 { get; set; }
        public int Random3 { get; set; }
    }
}
