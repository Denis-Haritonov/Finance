// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GridEntityReflector.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid
{   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Attributes;
    using Enum;
    using Interfaces;
    using RenderTemplates;

    /// <summary>
    /// Create grid for entity type
    /// </summary>
    public class GridEntityReflector : IGridReflector
    {
        /// <summary>
        /// Makes grid from attribute
        /// </summary>
        /// <param name="t">Entity for reflection</param>
        /// <param name="mode">Template render mode</param>
        /// <returns>Grid class</returns>
        public Grid Reflect(Type t, TemplateMode mode)
        {
            var attribute = (GridPropertiesAttribute)t.GetCustomAttribute(typeof(GridPropertiesAttribute));
            if (attribute != null)
            {
                var grid = new Grid(attribute);
                var rows = new List<GridRow>();
                foreach (var property in t.GetProperties())
                {
                    var rowAttribute = (RowDisplayAttribute)property.GetCustomAttribute(typeof(RowDisplayAttribute));
                    if (rowAttribute != null)
                    {
                        if (mode == TemplateMode.ExtendedDisplay || !rowAttribute.ExtendedView)
                        {
                            if (mode == TemplateMode.Edit && rowAttribute.ColumnEditType == GridColumnTypes.DropDown)
                            {
                                rows.Add(new GridRow(t.GetProperty(rowAttribute.DropdownPropertyName), rowAttribute, mode));
                            }
                            else
                            {
                                rows.Add(new GridRow(property, rowAttribute, mode));
                            }
                        }
                    }
                }

                grid.Rows = rows.ToList();
                return grid;
            }

            return null;
        }
    }
}
