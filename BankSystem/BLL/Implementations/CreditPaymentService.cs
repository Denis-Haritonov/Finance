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

        private IDateService dateService;

        public CreditPaymentService(ICreditRepository creditRepository, ICreditPaymentRepository creditPaymentRepository, IDateService dateService)
        {
            this.creditRepository = creditRepository;
            this.creditPaymentRepository = creditPaymentRepository;
            this.dateService = dateService;
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
            if (credit.MainDebt < 1)
            {
                credit.MainDebt = 0;
            }
            if (credit.PercentageDebt < 1)
            {
                credit.PercentageDebt = 0;
            }
            creditRepository.UpdateCredit(credit);
            var date = dateService.GetCurrentDate();
            var payment = new CreditPayment
            {
                MainAmount = mainMinus,
                PercentsAmount = percentMinus,
                CreditId = paymentModel.CreditId,
                Type = (int)paymentModel.Type,
                Date = date,
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
