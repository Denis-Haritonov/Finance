using BLL.Implementations;
using BLL.Interfaces;
using Common.Grid;
using Common.Grid.Interfaces;
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
            this.Bind<ICommentService>().To<CommentService>().InSingletonScope();
            this.Bind<IDepositService>().To<DepositService>().InSingletonScope();
            this.Bind<ICreditService>().To<CreditService>().InSingletonScope();
            this.Bind<IDepositPaymentService>().To<DepositPaymentService>().InSingletonScope();
            this.Bind<ICreditPaymentService>().To<CreditPaymentService>().InSingletonScope(); 
            this.Bind<IGridRenderer>().To<GridRenderer>().InSingletonScope();
            this.Bind<IGridReflector>().To<GridEntityReflector>().InSingletonScope();
        }
    }
}
