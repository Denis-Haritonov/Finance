using BLL.Models;

namespace BLL.Interfaces
{
    public interface ICreditPaymentService
    {
        void AddPayment(CreditPaymentModel paymentModel);

        void CancelPayment(int paymentId);

        CreditPaymentModel GetPaymentById(int creditPaymentId);
    }
}
