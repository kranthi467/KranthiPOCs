using BusinessAbstractions;
using Entities;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Web.Http;

namespace Demo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        IEmployeeBusiness _employeeBusiness;
        [Dependency]
        public IEmployeeBusiness businessLayer { get; set; }

        [Dependency]
        public IUnityContainer UnityContainer { get; set; }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        public ValuesController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        // GET api/values/5
        public Employee Get(int id)
        {
            string buss = "Manager";

            var currentEmployeeBusiness = UnityContainer.Resolve<IEmployeeBusiness>(buss);

            return currentEmployeeBusiness.GetEmployee(id);
        }
    }
}
