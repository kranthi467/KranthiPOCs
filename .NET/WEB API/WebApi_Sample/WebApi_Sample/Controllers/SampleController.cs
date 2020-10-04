
using System.Collections.Generic;

using System.Web.Http;
using System.Web.Http.Cors;
using WebApi_Sample.Models;

namespace WebApi_Sample.Controllers
{
    [RoutePrefix("api/sample")]
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SampleController : ApiController
    {
        private static List<Employee> _employees;
        static SampleController()
        {
            _employees = new List<Employee>()
            {
                new Employee {ID=0, Name="Emp0", Age=21 },
                new Employee {ID=1, Name="Emp1", Age=21 },
                new Employee {ID=2, Name="Emp2", Age=21 },

            };
        }
        // GET: api/Sample
        //[Route("List")]
        //[HttpGet]
        //[DisableCors]
        //public IEnumerable<Employee> list()
        //{
        //    return _employees;
        //}

        [HttpGet]
        public IEnumerable<Employee> GetEmp()
        {
            return _employees;
        }

        // GET: api/Sample/5
        [Route("{idd}")]
        public Employee Get(int idd)
        {
            int index = _employees.FindIndex(x => x.ID == idd);
            if (index >= 0)
            {
                return _employees[index];
            }
            return null;
        }

        // POST: api/Sample
        [HttpPost]
        public void Post(Employee value)
            {
            _employees.Add(value);
        }

        // PUT: api/Sample/5
        [Route("{ID}")]
        public void Put(int id, [FromBody]Employee value)
        {
            int index = _employees.FindIndex(x => x.ID == id);
            _employees.RemoveAt(index);
            _employees.Add(value);
        }

        // DELETE: api/Sample/5
        [Route("{ID}")]
        public void Delete(int id)
        {
            int index = _employees.FindIndex(x => x.ID == id);
            _employees.RemoveAt(index);
        }
    }
}
