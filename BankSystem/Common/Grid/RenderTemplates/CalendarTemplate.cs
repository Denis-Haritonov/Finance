// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalendarTemplate.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.RenderTemplates
{
    using System;
    using System.Reflection;
    using Html;

    /// <summary>
    /// Editor template for date with calendar
    /// </summary>
    public class CalendarTemplate : BaseTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarTemplate"/> class.
        /// </summary>
        /// <param name="property">Entity property</param>
        /// <param name="format">Render format</param>
        public CalendarTemplate(PropertyInfo property, string format)
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
            var result = new HtmlTableCell() { InnerHtml = "<input class=\"datetimepicker\" type=\"text\"/>" };
            var propValue = Property.GetValue(value);
            if (propValue != null)
            {
                var date = (DateTime?)propValue;
                result.InnerHtml = string.Format("<input class=\"datetimepicker\" type=\"text\" value=\"{0}\"/>", date.Value.ToString(this.Format));
            }

            return result;
        }
    }
}
