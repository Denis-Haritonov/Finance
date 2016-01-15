// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditWithList.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.AdditionalClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for dropdown 
    /// </summary>
    public class EditWithList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EditWithList"/> class.
        /// </summary>
        public EditWithList()
        {
            this.List = new Dictionary<string, string>();
        }

        /// <summary>
        /// Selected value key
        /// </summary>
        public string SelectedValue { get; set; }

        /// <summary>
        /// Select list
        /// </summary>
        public Dictionary<string, string> List { get; set; }
    }
}
