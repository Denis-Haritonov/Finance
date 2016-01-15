// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGridReflector.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.Interfaces
{
    using System;
    using Enum;

    /// <summary>
    /// Interface for grid reflector
    /// </summary>
    public interface IGridReflector
    {
         /// <summary>
        /// Makes grid from attribute
        /// </summary>
        /// <param name="t">Entity for reflection</param>
        /// <param name="mode">Template mode</param>
        /// <returns>Grid class</returns>
        Grid Reflect(Type t, TemplateMode mode);
    }
}
