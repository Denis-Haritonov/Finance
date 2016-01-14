using System;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Enums;
using DAL;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class CreditPaymentService : ICreditPaymentService
    {
        private ICreditPaymentRepository creditPaymentRepository;

        private ICreditRepository creditRepository;

        public CreditPaymentService(ICreditRepository creditRepository, ICreditPaymentRepository creditPaymentRepository)
        {
            this.creditRepository = creditRepository;
            this.creditPaymentRepository = creditPaymentRepository;
        }

        public void AddPayment(CreditPaymentModel paymentModel)
        {
            var credit = creditRepository.GetCreditById(paymentModel.CreditId);
            var rest = paymentModel.MainAmount - credit.PercentageDebt;
            decimal mainMinus, percentMinus;
            if (rest >= 0)
            {
                mainMinus = rest;
                percentMinus = credit.PercentageDebt;
            }
            else
            {
                mainMinus = 0;
                percentMinus = paymentModel.MainAmount;
            }
            credit.MainDebt -= mainMinus;
            credit.PercentageDebt -= percentMinus;
            creditRepository.UpdateCredit(credit);
            var payment = new CreditPayment
            {
                MainAmount = mainMinus,
                PercentsAmount = percentMinus,
                CreditId = paymentModel.CreditId,
                Type = (int)paymentModel.Type,
                Date = DateTime.Now,
            };
            creditPaymentRepository.CreatePayment(payment);
        }

        public void CancelPayment(int paymentId)
        {
            var payment = creditPaymentRepository.GetPaymentById(paymentId);
            var credit = creditRepository.GetCreditById(payment.CreditId);
            if ((CreditPaymentType) payment.Type == CreditPaymentType.Payment)
            {
                credit.MainDebt += payment.MainAmount;
                credit.PercentageDebt += payment.PercentsAmount;
            }
            creditRepository.UpdateCredit(credit);
            creditPaymentRepository.RemovePayment(paymentId);
        }

        public CreditPaymentModel GetPaymentById(int creditPaymentId)
        {
            var payment = creditPaymentRepository.GetPaymentById(creditPaymentId);
            if (payment != null)
            {
                return new CreditPaymentModel(payment);
            }
            return null;
        }
    }
}
