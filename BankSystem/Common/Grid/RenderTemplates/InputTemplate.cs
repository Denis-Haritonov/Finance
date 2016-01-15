// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputTemplate.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.RenderTemplates
{
    using System.Reflection;
    using Html;

    /// <summary>
    /// Template for base field edit with input
    /// </summary>
    public class InputTemplate : BaseTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InputTemplate"/> class.
        /// </summary>
        /// <param name="property">Entity property</param>
        /// <param name="format">Render format</param>
        public InputTemplate(PropertyInfo property, string format)
        {
            this.Property = property;
            this.Format = format;
        }

        /// <summary>
        /// Transfer object in html cell
        /// </summary>
        /// <param name="value">Object to render</param>
        /// <returns>Html cell</returns>
        public override HtmlTableCell Render(object value)
        {           
            var result = new HtmlTableCell();
            result.InnerHtml = string.Format("<input type=\"text\" value=\"{0}\"/>", Property.GetValue(value));
            return result;
        }
    }
}
