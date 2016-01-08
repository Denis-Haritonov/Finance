namespace BankSystem
{
    using BusinesLogicLayer.Entities;

    /// <summary>
    /// Configure auto mapper modules
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Configure auto mapper modules
        /// </summary>
        public static void ConfigureAutomapper()
        {
            new BllAutomapperConfiguration().Configure();
        }       
    }
}