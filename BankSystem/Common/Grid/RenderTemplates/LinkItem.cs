// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinkItem.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.RenderTemplates
{
    /// <summary>
    /// Data object representing hyper-link and it's text
    /// </summary>
    public class LinkItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinkItem"/> class.
        /// </summary>
        /// <param name="item">Item to show to user</param>
        public LinkItem(string item = "")
        {
            this.Item = item;
            this.Link = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkItem"/> class.
        /// </summary>
        /// <param name="item">Item to show to user</param>
        /// <param name="link">Url for generated link</param>
        public LinkItem(string item, string link)
        {
            this.Item = item;
            this.Link = link;
        }

        /// <summary>
        /// Gets or sets item
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets link
        /// </summary>
        public string Link { get; set; }
    }
}
