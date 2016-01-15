// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEntity.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Common.Grid.Attributes;

namespace Common.Grid.AdditionalClasses
{
    using System;
    using Attributes;
    using Enum;

    /// <summary>
    /// Entity for grid test
    /// </summary>
    [GridProperties]
    public class TestEntity
    {
        /// <summary>
        /// Actions check boxes columns
        /// </summary>
        [RowDisplay(ColumnName = "", ColumnEditType = GridColumnTypes.CheckBox, ColumnDisplayType = GridColumnTypes.CheckBox, Order = 0, ColumnWidth = 50, IsHidden = false, IsKey = false, NonBordered = true)]
        public bool Actions { get; set; }

        /// <summary>
        /// Price test column
        /// </summary>
        [RowDisplay(ColumnName = "Price", ColumnEditType = GridColumnTypes.MoneyEdit, ColumnDisplayType = GridColumnTypes.Money, Order = 2,  IsHidden = false, IsKey = false, ColumnStringFormat = "F")]
        public Price Price { get; set; }

        /// <summary>
        /// Check box check column
        /// </summary>
        [RowDisplay(ColumnName = "Check", ColumnEditType = GridColumnTypes.CheckBox, ColumnDisplayType = GridColumnTypes.Boolean, Order = 3,  IsHidden = false, IsKey = false)]
        public bool Check { get; set; }

        /// <summary>
        /// Base check column
        /// </summary>
        [RowDisplay(ColumnName = "Name", ColumnEditType = GridColumnTypes.Input,  ColumnDisplayType = GridColumnTypes.Base, Order = 1,  IsHidden = false, IsKey = false)]
        public string Name { get; set; }

        /// <summary>
        /// Test date
        /// </summary>
        [RowDisplay(ColumnName = "Date", ColumnEditType = GridColumnTypes.Calendar, ColumnDisplayType = GridColumnTypes.Date, Order = 4, IsHidden = false, IsKey = false, ColumnStringFormat = "dd/mm/yyyy hh:MM", IsSortable = true)]
        public DateTime TestDate { get; set; }
    }
}
