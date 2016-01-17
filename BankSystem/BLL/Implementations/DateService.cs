using System;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Implementations
{
    public class DateService: IDateService
    {
        private IDateRepository dateRepository;

        public DateService(IDateRepository dateRepository)
        {
            this.dateRepository = dateRepository;
        }

        public DateTime GetCurrentDate()
        {
            return dateRepository.GetCurrentDate();
        }

        public void DayForward()
        {
            dateRepository.AddDay();
        }

        public void MonthForward()
        {
            for (int i = 0; i < 30; i++)
            {
                dateRepository.AddDay();
            }
        }

        public void YearForward()
        {
            for (int i = 0; i < 12; i++)
            {
                MonthForward();
            }
        }

        public void Reset()
        {
            dateRepository.ResetDate();
        }
    }
}
