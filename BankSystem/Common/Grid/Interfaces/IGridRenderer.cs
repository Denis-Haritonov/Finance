// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGridRenderer.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.Interfaces
{
    using System;
    using AdditionalClasses;
    using Common;
    using Enum;

    /// <summary>
    /// Interface for grid render
    /// </summary>
    public interface IGridRenderer
    {
        /// <summary>
        /// Render grid to string
        /// </summary>
        /// <param name="t">Entity type</param>
        /// <param name="entities">Entities to render</param>
        /// <param name="mode">TemplateMode mode</param>
        /// <param name="sorting">Grid sorting</param>
        /// <returns>Rendered in string grid</returns>
        string Render(Type t, PagingCollection<object> entities, TemplateMode mode, GridSorting sorting);
    }
}
