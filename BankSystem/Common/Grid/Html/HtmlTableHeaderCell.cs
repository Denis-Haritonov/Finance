// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlTableHeaderCell.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.Html
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provide class presentation of html table header cell tag
    /// </summary>
    public class HtmlTableHeaderCell : HtmlTag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTableHeaderCell"/> class.
        /// </summary>
        public HtmlTableHeaderCell()
        {
            this.Classes = new List<string>();
            this.Styles = new List<string>();
        }

        /// <summary>
        /// Returns html table tag
        /// </summary>
        /// <returns>String table tag</returns>
        public override string ToString()
        {
            return string.Format("<th{0}{1}{3}{4}>{2}</th>", this.IdAttribute(), this.ClassAttribute(), this.InnerHtml, this.StyleAttribute(), this.RenderAttributes());
        }     
    }
}
