using Autofac;
using Autofac.Integration.Mvc;
using Rehber.Bl.Interface;
using Rehber.Bl.Repository;
using System.Reflection;
using System.Web.Mvc;
using Telefon_Rehberi.Areas.Admin.Controllers;
using Telefon_Rehberi.Controllers;

namespace Telefon_Rehberi.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CalisanYonetimi>().As<ICalisanYonetimi>();
            builder.RegisterType<DepartmanYonetimi>().As<IDepartmanYonetimi>();
            builder.RegisterType<AyarlarYonetimi>().As<IAyarlarYonetimi>();

            builder.RegisterType<HomeController>();
            builder.RegisterType<CalisanYonetimController>();
            builder.RegisterType<DepartmanYonetimController>();
            builder.RegisterType<GirisController>();
            builder.RegisterType<UIController>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}