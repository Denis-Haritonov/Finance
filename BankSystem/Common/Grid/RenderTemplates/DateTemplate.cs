// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTemplate.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.RenderTemplates
{
    using System;
    using System.Reflection;
    using Html;

    /// <summary>
    /// Templates for html date
    /// </summary>
    public class DateTemplate : BaseTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTemplate"/> class.
        /// </summary>
        /// <param name="property">Property for render</param>
        /// <param name="format">Render format</param>
        public DateTemplate(PropertyInfo property, string format)
        {
            this.Property = property;
            this.Format = format;
        }

        /// <summary>
        /// Render object in html cell
        /// </summary>
        /// <param name="value">Object to render</param>
        /// <returns>Html table cell</returns>
        public override HtmlTableCell Render(object value)
        {
            var result = new HtmlTableCell() { InnerHtml = "N/A" };
            var propValue = Property.GetValue(value);
            if (propValue != null)
            {
                var date = (DateTime)propValue;
                if (date != DateTime.MinValue)
                {
                    result.InnerHtml = date.ToShortDateString();
                }
            }

            return result;
        }
    }
}
