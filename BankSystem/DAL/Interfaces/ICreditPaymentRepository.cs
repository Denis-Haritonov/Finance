using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ICreditPaymentRepository
    {
        void CreatePayment(CreditPayment creditPayment);

        void RemovePayment(int id);

        List<CreditPayment> GetPaymentsPerCredit(int creditId);

        CreditPayment GetPaymentById(int creditPaymentId);
    }
}
