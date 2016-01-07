// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Menu.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Common.Enum;

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
        public static string Render(string currentUrl, Roles currentRole)
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
               menuPoints = new List<MenuPoint>();     
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
        /// Generate url for menu point.
        /// </summary>
        /// <param name="action">
        /// Action name.
        /// </param>
        /// <param name="controller">
        /// Controller name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GenerateUrl(string action, string controller)
        {
            return UrlHelper.GenerateUrl(null, action, controller, null, RouteTable.Routes, HttpContext.Current.Request.RequestContext, false);
        }

        /// <summary>
        /// Setup warehouse menu
        /// </summary>
        private static void SetupWarehouseMenu()
        {

            var stockGrid = new MenuPoint()
            {
                Name = "Test",
                PointUrl = UrlHelper.GenerateUrl(null,"Index","Admin", null, RouteTable.Routes, HttpContext.Current.Request.RequestContext,false)
            };
            menuPoints.Add(stockGrid);
        }
    }
}