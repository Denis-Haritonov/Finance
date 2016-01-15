// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GridSorting.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.AdditionalClasses
{
    /// <summary>
    /// Providing information about grid sort
    /// </summary>
    public class GridSorting
    {
        /// <summary>
        /// Name of column with sort
        /// </summary>
        public string SortColumnName { get; set; }

        /// <summary>
        /// Sort direction
        /// </summary>
        public bool LowestToHight { get; set; }
    }
}
