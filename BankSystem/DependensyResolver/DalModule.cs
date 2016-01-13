using DAL.Implementation;
using DAL.Interfaces;
using Ninject.Modules;

namespace DependensyResolver
{
    public class DalLayerModule : NinjectModule
    {

        public override void Load()
        {
            this.Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            this.Bind<IRequestRepository>().To<RequestRepository>().InSingletonScope();
            this.Bind<ICreditTypeReporsitory>().To<CreditTypeRepository>().InSingletonScope();
            this.Bind<IDepositTypeRepository>().To<DepositTypeRepository>().InSingletonScope();
            this.Bind<ICommentRepository>().To<CommentRepository>().InSingletonScope();
            this.Bind<IDepositRepository>().To<DepositRepository>().InSingletonScope();
            this.Bind<ICreditRepository>().To<CreditRepository>().InSingletonScope();
            this.Bind<IDepositPaymentRepository>().To<DepositPaymentRepository>().InSingletonScope();
        }
    }
}
