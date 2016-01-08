using DAL.Implementation;
using DAL.Interfaces;

namespace DependencyResolver
{
    using Ninject.Modules;

    public class DalLayerModule : NinjectModule
    {

        public override void Load()
        {
            this.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
        }
    }
}
