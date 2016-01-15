// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Grid.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Common.Grid.Attributes;

namespace Common.Grid
{
    using System.Collections.Generic;
    using AdditionalClasses;
    using Attributes;

    /// <summary>
    /// Class presents grid model for render
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Grid"/> class.
        /// </summary>
        /// <param name="attribute">Attribute attached to entity for grid generation</param>
        public Grid(GridPropertiesAttribute attribute)
        {           
        }

        /// <summary>
        ///  Store information about grid sort
        /// </summary>
        public GridSorting Sorting { get; set; }

        /// <summary>
        /// List of grid rows
        /// </summary>
        public List<GridRow> Rows { get; set; }       
    }
}
