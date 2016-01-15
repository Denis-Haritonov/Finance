// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GridRow.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid
{
    using System.Reflection;

    using Attributes;

    using Common;

    using Enum;

    using Interfaces;

    using RenderTemplates;

    /// <summary>
    /// Grid row
    /// </summary>
    public class GridRow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridRow"/> class.
        /// </summary>
        public GridRow()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridRow"/> class.
        /// </summary>
        /// <param name="targetProperty">property to render in row</param>
        /// <param name="attribute">Property attribute</param>
        /// <param name="mode">Template mode</param>
        public GridRow(PropertyInfo targetProperty, RowDisplayAttribute attribute, TemplateMode mode)
        {
            this.RowProperty = targetProperty;
            this.ColumnName = attribute.ColumnName;
            this.IsKey = attribute.IsKey;
            this.ColumnType = mode == TemplateMode.Edit ? attribute.ColumnEditType : attribute.ColumnDisplayType;
            this.ColumnWidth = attribute.ColumnWidth;
            this.IsHidden = attribute.IsHidden;
            this.IsSortable = attribute.IsSortable;
            this.NonBordered = attribute.NonBordered;
            this.ColumnStringFormat = attribute.ColumnStringFormat;
            this.Order = attribute.Order;
            this.DataField = attribute.DataField;
            this.ModelField = attribute.ModelField;
            switch (this.ColumnType)
            {
                case GridColumnTypes.Base:
                    {                        
                        this.RenderTemplate = new BaseTemplate(this.RowProperty, this.ColumnStringFormat);    
                        break;
                    }

                case GridColumnTypes.Input:
                    {
                        this.RenderTemplate = new InputTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }

                case GridColumnTypes.PercentInput:
                    {
                        this.RenderTemplate = new PercentInputTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }

                case GridColumnTypes.Boolean:
                    {
                        this.RenderTemplate = new BooleanTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }

                case GridColumnTypes.CheckBox:
                    {
                        this.RenderTemplate = new CheckBoxTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }

                case GridColumnTypes.Date:
                    {
                        this.RenderTemplate = new DateTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }

                case GridColumnTypes.Calendar:
                    {
                        this.RenderTemplate = new CalendarTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }

                case GridColumnTypes.DropDown:
                    {
                        this.RenderTemplate = new DropDownTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }

                case GridColumnTypes.Link:
                    {
                        this.RenderTemplate = new LinkTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }

                case GridColumnTypes.None:
                    {
                        this.RenderTemplate = new EmptyTemplate(this.RowProperty, this.ColumnStringFormat);
                        break;
                    }
            }
        }

        /// <summary>
        /// Store render templates
        /// </summary>
        public IRenderTemplate RenderTemplate { get; set; }

        /// <summary>
        /// Attached property that will be render in this row
        /// </summary>
        public PropertyInfo RowProperty { get; set; }

        /// <summary>
        /// Name of column that will be rendered as header
        /// </summary>
        public string ColumnName { get; set; }

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
        /// If true then cell will be bordered
        /// </summary>
        public bool NonBordered { get; set; }

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
        public GridColumnTypes ColumnType { get; set; }

        /// <summary>
        /// Additional string pattern for render
        /// </summary>
        public string ColumnStringFormat { get; set; }

        /// <summary>
        /// Data field name
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
