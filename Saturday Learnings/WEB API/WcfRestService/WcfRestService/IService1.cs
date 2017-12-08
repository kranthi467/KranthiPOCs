using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Contact GetContact(int id);

        [OperationContract]
        bool PutContact(int id, Contact customer);

        [OperationContract]
        bool DeleteContact(int id);
        // TODO: Add your service operations here
    }
    
}
