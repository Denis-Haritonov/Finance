using System;

namespace Pl.Web.Portal.Menu
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Renders menu
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Inner sub menu points
        /// </summary>
        private static List<MenuPoint> menuPoints;

        /// <summary>
        /// Initializes static members of the <see cref="Menu"/> class.
        /// </summary>
        static Menu()
        {
            menuPoints = new List<MenuPoint>();
            SetupAdminMenu();
            SetupResellerMenu();
            SetupRetailerMenu();
            SetupWarehouseMenu();
        }

        /// <summary>
        /// Renders menu in string
        /// </summary>
        /// <param name="currentUrl">Current request url</param>
        /// <param name="currentRole">Current user role</param>
        /// <returns>Rendered string</returns>
        public static string Render(string currentUrl, String currentRole)
        {
            var itemsRender = string.Empty;
            menuPoints.ForEach(mp => itemsRender += mp.Render(currentUrl, currentRole));
            return itemsRender;
        }

        /// <summary>
        /// Points to render admin menu
        /// </summary>
        private static void SetupAdminMenu()
        {
            
        }

        /// <summary>
        /// Setup reseller menu
        /// </summary>
        private static void SetupResellerMenu()
        {
            
        }

        /// <summary>
        /// Setup retailer menu
        /// </summary>
        private static void SetupRetailerMenu()
        {
            
        }


        /// <summary>
        /// Setup warehouse menu
        /// </summary>
        private static void SetupWarehouseMenu()
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var index = new MenuPoint(new List<string>() { "Admin" })
            {
                Name = "Пользователи",
                PointUrl = urlHelper.Action("Index","Admin")
            };
            menuPoints.Add(index);

            var creditTypes = new MenuPoint(new List<string>() { "Admin" })
            {
                Name = "Типы кредитов",
                PointUrl = urlHelper.Action("CreditTypeGrid", "Admin")
            };
            menuPoints.Add(creditTypes);

            var currency = new MenuPoint(new List<string>() { "Admin" })
            {
                Name = "Курсы валют",
                PointUrl = urlHelper.Action("Currency", "Admin")
            };
            menuPoints.Add(currency);

            var closecode = new MenuPoint(new List<string>() { "Admin" })
            {
                Name = "Код отмены платежа",
                PointUrl = urlHelper.Action("RefreshCode", "Admin")
            };
            menuPoints.Add(closecode);                     
        }
    }
}