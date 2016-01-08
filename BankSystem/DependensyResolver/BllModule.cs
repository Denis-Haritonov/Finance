using BLL.Implementations;
using BLL.Interfaces;
using DAL.Implementation;
using DAL.Interfaces;
using Ninject.Modules;

namespace DependensyResolver
{
        public class BllLayerModule : NinjectModule
        {
            public override void Load()
            {
                this.Bind<IUserService>().To<UserService>().InSingletonScope();
            }
        }

}
