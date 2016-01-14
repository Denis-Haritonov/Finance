using BLL.Models;

namespace BLL.Interfaces
{
    public interface IDepositPaymentService
    {
        void AddPayment(DepositPaymentModel paymentModel);

        void CancelPayment(int paymentId);

        DepositPaymentModel GetPaymentById(int depositPaymentId);
    }
}
