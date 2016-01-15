// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTag.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.Html
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class for html tags present
    /// </summary>
    public class HtmlTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTag"/> class.
        /// </summary>
        public HtmlTag()
        {
            this.Classes = new List<string>();
            this.Styles = new List<string>();
            this.Attributes = new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Presents id attribute value
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Presents tag classes
        /// </summary>
        public List<string> Classes { get; set; }

        /// <summary>
        /// Presents tag attributes
        /// </summary>
        public List<KeyValuePair<string, string>> Attributes { get; set; }

        /// <summary>
        /// Value to render in html table tag
        /// </summary>
        public string InnerHtml { get; set; }

        /// <summary>
        /// Value to render
        /// </summary>
        public List<string> Styles { get; set; }

        /// <summary>
        /// Provide id attribute as string
        /// </summary>
        /// <returns>Id attribute</returns>
        protected string IdAttribute()
        {
            if (!string.IsNullOrEmpty(this.Id))
            {
                return string.Format(" id=\"{0}\" ", this.Id);
            }

            return string.Empty;
        }

        /// <summary>
        /// Provide class attribute as string
        /// </summary>
        /// <returns>Class attribute</returns>
        protected string ClassAttribute()
        {
            if (this.Classes.Any())
            {
                return string.Format(" class=\"{0}\" ", string.Join(" ", this.Classes));
            }

            return string.Empty;
        }

        /// <summary>
        /// Provide style attribute as string
        /// </summary>
        /// <returns>Style attribute</returns>
        protected string StyleAttribute()
        {
            if (this.Styles.Any())
            {
                return string.Format(" style=\"{0}\" ", string.Join(";", this.Styles));
            }

            return string.Empty;
        }

        /// <summary>
        /// Render attributes
        /// </summary>
        /// <returns>Attributes in string</returns>
        protected string RenderAttributes()
        {
            var result = string.Empty;
            if (this.Attributes.Any())
            {
                foreach (var attribute in this.Attributes)
                {
                    result += string.Format(" {0}=\"{1}\" ", attribute.Key, attribute.Value);
                }              
            }

            return result;
        }
    }
}
