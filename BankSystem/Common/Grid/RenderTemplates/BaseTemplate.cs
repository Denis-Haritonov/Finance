// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseTemplate.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Common.Enum;

namespace Common.Grid.RenderTemplates
{
    using System;
    using System.Reflection;

    using global::Common.Common;

    using Html;
    using Interfaces;

    /// <summary>
    /// Base property template
    /// </summary>
    public class BaseTemplate : IRenderTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTemplate"/> class.
        /// </summary>
        /// <param name="property">Property for render</param>
        /// <param name="format">Render format</param>        
        public BaseTemplate(PropertyInfo property, string format)
        {
            this.Property = property;
            this.Format = format;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTemplate"/> class.
        /// </summary>
        public BaseTemplate()
        {
        }

        /// <summary>
        /// Property of entity to render
        /// </summary>
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// Format to render
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Transfer object to html table cell
        /// </summary>
        /// <param name="value">Entity property to render</param>
        /// <returns>Html table cell to string render</returns>
        public virtual HtmlTableCell Render(object value)
        {
            var propertyValue = this.Property.GetValue(value);
            if (propertyValue is Enum)
            {
                propertyValue = ((Enum)propertyValue).GetDisplayName();
            }

            return new HtmlTableCell { InnerHtml = propertyValue == null ? string.Empty : propertyValue.ToString() };
        }
    }
}
