// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GridExtensions.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Common.Enum;

namespace Pl.Web.Portal
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Common.Common;
    using Common.Enum;
    using Common.Grid.AdditionalClasses;
    using Common.Grid.Interfaces;

    /// <summary>
    /// Grid html helper
    /// </summary>
    public static class GridExtensions
    {
        /// <summary>
        /// Provide grid render logic
        /// </summary>
        private static IGridRenderer renderer;

        /// <summary>
        /// Initializes static members of the <see cref="GridExtensions"/> class.
        /// </summary>
        static GridExtensions()
        {
            renderer = (IGridRenderer)DependencyResolver.Current.GetService(typeof(IGridRenderer));
        }

        /// <summary>
        /// Build grid for paging collection class
        /// </summary>
        /// <param name="helper">Html helper</param>
        /// <param name="collection">Collection for render</param>
        /// <param name="mode">Templates mode</param>
        /// <param name="sorting">Grid sorting</param>
        /// <returns>Html grid for collection</returns>
        public static IHtmlString Gridd(this HtmlHelper helper, PagingCollection<object> collection, TemplateMode mode, GridSorting sorting = null)
        {
            if (collection.Any())
            {
                var type = collection.First().GetType();
                return helper.Raw(renderer.Render(type, collection, mode, sorting));
            }

            return new HtmlString("No stock has been found.");
        }
    }
}
