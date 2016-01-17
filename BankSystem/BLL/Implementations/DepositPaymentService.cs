using System;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.Enums;
using DAL;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class DepositPaymentService : IDepositPaymentService
    {
        private IDepositPaymentRepository depositPaymentRepository;

        private IDepositRepository depositRepository;

        private IDateService dateService;

        public DepositPaymentService(IDepositPaymentRepository depositPaymentRepository, IDepositRepository depositRepository, IDateService dateService)
        {
            this.depositPaymentRepository = depositPaymentRepository;
            this.depositRepository = depositRepository;
            this.dateService = dateService;
        }

        public void AddPayment(DepositPaymentModel paymentModel)
        {
            var deposit = depositRepository.GetDepositById(paymentModel.DepositId);
            if (paymentModel.Type == DepositPaymentType.Income)
            {
                deposit.Balance += paymentModel.Amount;
            }
            else if (paymentModel.Type == DepositPaymentType.Outcome)
            {
                deposit.Balance -= paymentModel.Amount;
            }
            if (deposit.Balance < 1)
            {
                deposit.Balance = 0;
            }
            depositRepository.UpdateDeposit(deposit);
            var date = dateService.GetCurrentDate();
            var payment = new DepositPayment
            {
                Amount = paymentModel.Amount,
                DepositId = paymentModel.DepositId,
                Type = (int) paymentModel.Type,
                Date = date
            };
            depositPaymentRepository.CreatePayment(payment);
        }

        public void CancelPayment(int paymentId)
        {
            var payment = depositPaymentRepository.GetPaymentById(paymentId);
            var deposit = depositRepository.GetDepositById(payment.DepositId);
            if ((DepositPaymentType) payment.Type == DepositPaymentType.Income)
            {
                deposit.Balance -= payment.Amount;
            }
            else if ((DepositPaymentType)payment.Type == DepositPaymentType.Outcome)
            {
                deposit.Balance += payment.Amount;
            }
            depositRepository.UpdateDeposit(deposit);
            depositPaymentRepository.RemovePayment(paymentId);
        }

        public DepositPaymentModel GetPaymentById(int depositPaymentId)
        {
            var payment = depositPaymentRepository.GetPaymentById(depositPaymentId);
            if (payment != null)
            {
                return new DepositPaymentModel(payment);
            }
            return null;
        }
    }
}
