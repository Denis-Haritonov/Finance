// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RowDisplayAttribute.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid.Attributes
{
    using System;
    using Enum;

    /// <summary>
    /// Attribute with properties for render property in table column
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class RowDisplayAttribute : Attribute
    {   
        /// <summary>
        /// Name of column that will be rendered as header
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the column name resource type.
        /// </summary>
        public Type ColumnNameResourceType { get; set; }

        /// <summary>
        /// Gets or sets the column name resource name.
        /// </summary>
        public string ColumnNameResourceName { get; set; }

        /// <summary>
        /// Is current property is key for entity
        /// </summary>
        public bool IsKey { get; set; }

        /// <summary>
        /// If set true then item will be hidden
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// If true than there will be sort render in column header
        /// </summary>
        public bool IsSortable { get; set; }

        /// <summary>
        /// If true then border will shows
        /// </summary>
        public bool NonBordered { get; set; }

        /// <summary>
        /// If sets true than field will be displayed only in extended view mode
        /// </summary>
        public bool ExtendedView { get; set; }

        /// <summary>
        /// Order of this column in table
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Width for current column
        /// </summary>
        public int ColumnWidth { get; set; }

        /// <summary>
        /// For each type render could be different
        /// </summary>
        public GridColumnTypes ColumnDisplayType { get; set; }

        /// <summary>
        /// For each type render could be different
        /// </summary>
        public GridColumnTypes ColumnEditType { get; set; }

        /// <summary>
        /// Additional string pattern for render
        /// </summary>
        public string ColumnStringFormat { get; set; }

        /// <summary>
        /// Data property for order
        /// </summary>
        public string DataField { get; set; }

        /// <summary>
        /// View model property for save
        /// </summary>
        public string ModelField { get; set; }

        /// <summary>
        /// Dropdown name for dropdown template
        /// </summary>
        public string DropdownPropertyName { get; set; }
    }
}
