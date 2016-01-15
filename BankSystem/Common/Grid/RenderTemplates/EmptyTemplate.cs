// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmptyTemplate.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.RenderTemplates
{
    using System;
    using System.Reflection;
    using AdditionalClasses;
    using Enum;
    using Html;

    /// <summary>
    /// Template for money cell
    /// </summary>
    public class EmptyTemplate : BaseTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyTemplate"/> class.
        /// </summary>
        /// <param name="property">Property for render</param>
        /// <param name="format">Render format</param>
        public EmptyTemplate(PropertyInfo property, string format)
        {
            this.Property = property;
            this.Format = format;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoneyTemplate"/> class.
        /// </summary>
        /// <param name="value">Property for render</param>
        /// <returns>Html table cell</returns>
        public override HtmlTableCell Render(object value)
        {
            var result = new HtmlTableCell();
            result.InnerHtml = string.Empty;
            return result;
        }
    }
}
