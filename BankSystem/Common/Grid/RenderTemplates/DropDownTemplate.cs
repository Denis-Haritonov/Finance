// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DropDownTemplate.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.RenderTemplates
{
    using System;
    using System.Reflection;
    using AdditionalClasses;
    using Html;

    /// <summary>
    /// Dropdown render template
    /// </summary>
    public class DropDownTemplate : BaseTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownTemplate"/> class.
        /// </summary>
        /// <param name="property">Property for render</param>
        /// <param name="format">Render format</param>
        public DropDownTemplate(PropertyInfo property, string format)
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
            var editWithList = (EditWithList)this.Property.GetValue(value);
            var result = new HtmlTableCell();
            result.InnerHtml += "<select class=\"chosen\">";
            var selectedOption = string.Empty;
            if (!string.IsNullOrEmpty(editWithList.SelectedValue))
            {
                editWithList.List.TryGetValue(editWithList.SelectedValue, out selectedOption);
            }

            foreach (var option in editWithList.List)
            {
                if (option.Value == selectedOption)
                {
                    result.InnerHtml += string.Format("<option selected=\"selected\" value=\"{0}\">{1}</option>", option.Key, option.Value);
                }
                else
                {
                    result.InnerHtml += string.Format("<option value=\"{0}\">{1}</option>", option.Key, option.Value);
                }
            }

            result.InnerHtml += "</select>";
            return result;
        }
    }
}
