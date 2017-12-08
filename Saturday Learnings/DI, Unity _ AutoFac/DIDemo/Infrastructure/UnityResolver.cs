using Business;
using BusinessAbstractions;
using Microsoft.Practices.Unity;
using Repository;
using RepositoryAbstractions;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Infrastructure
{
    public class UnityResolver : IDependencyResolver
    {
        IUnityContainer _container;
        public UnityResolver(IUnityContainer container)
        {
            _container = container ?? throw new ArgumentNullException("container");
        }
        public IDependencyScope BeginScope()
        {
            var childContainer = _container.CreateChildContainer();
            return new UnityResolver(childContainer);
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public static void GetReferences(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IEmployeeBusiness, EmployeeBusiness>();
            unityContainer.RegisterType<IEmployeeBusiness, PartTimeEmployeeBusiness>("PartTime");
            unityContainer.RegisterType<IEmployeeBusiness, ManagerBusiness>("Manager");
            unityContainer.RegisterType<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
