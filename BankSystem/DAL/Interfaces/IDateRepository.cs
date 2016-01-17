using System;

namespace DAL.Interfaces
{
    public interface IDateRepository
    {
        DateTime GetCurrentDate();

        void AddDay();

        void ResetDate();
    }
}
