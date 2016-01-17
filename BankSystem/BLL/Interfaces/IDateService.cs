using System;

namespace BLL.Interfaces
{
    public interface IDateService
    {
        DateTime GetCurrentDate();

        void DayForward();

        void MonthForward();

        void YearForward();

        void Reset();
    }
}
