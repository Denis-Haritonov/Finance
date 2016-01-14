using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IDepositPaymentRepository
    {
        void CreatePayment(DepositPayment depositPayment);

        void RemovePayment(int id);

        List<DepositPayment> GetPaymentsPerDeposit(int depositId);

        DepositPayment GetPaymentById(int depositPaymentId);
    }
}
