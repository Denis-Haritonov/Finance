// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkTemplate.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.RenderTemplates
{
    using System.Reflection;

    using global::Common.Grid.Html;

    /// <summary>
    /// Template for cell with link
    /// </summary>
    public class LinkTemplate : BaseTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkTemplate"/> class.
        /// </summary>
        /// <param name="property">Entity property</param>
        /// <param name="format">Render format</param>
        public LinkTemplate(PropertyInfo property, string format)
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
            var propertyValue = this.Property.GetValue(value);
            var linkItem = propertyValue as LinkItem;
            if (linkItem == null)
            {
                return base.Render(value);
            }

            var result = new HtmlTableCell();
            if (!string.IsNullOrEmpty(linkItem.Link))
            {
                result.InnerHtml = string.Format("<a target=\"_blank\" href=\"{1}\">{0}</a>", linkItem.Item, linkItem.Link);
            }
            else
            {
                result.InnerHtml = linkItem.Item;
            }

            return result;
        }
    }
}
