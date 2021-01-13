using System.Web.Http;
using HMS.BAL.Helper;
using HMS.BAL.Interface;
using Unity;
using Unity.WebApi;

namespace HotelManagmentApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IHotelManager, HotelManager>();
            container.AddNewExtension<UnityRepositoryHelper>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}