// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenderTemplate.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.Interfaces
{
    using Html;

    /// <summary>
    /// Interface for render template
    /// </summary>
    public interface IRenderTemplate
    {
        /// <summary>
        /// Render object in html cell
        /// </summary>
        /// <param name="value">Object to render</param>
        /// <returns>Html table cell</returns>
        HtmlTableCell Render(object value);
    }
}
