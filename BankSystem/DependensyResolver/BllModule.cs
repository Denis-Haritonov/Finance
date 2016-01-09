using BLL.Implementations;
using BLL.Interfaces;
using Ninject.Modules;

namespace DependensyResolver
{
    public class BllLayerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserService>().To<UserService>().InSingletonScope();
            this.Bind<ICreditTypeService>().To<CreditTypeService>().InSingletonScope();
            this.Bind<IDepositTypeService>().To<DepositTypeService>().InSingletonScope();
            this.Bind<IRequestService>().To<RequestService>().InSingletonScope();
        }
    }
}
