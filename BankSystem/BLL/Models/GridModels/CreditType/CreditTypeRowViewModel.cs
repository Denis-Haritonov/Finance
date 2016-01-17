using Common.Enum;
using Common.Grid.Attributes;

namespace BLL.Models.GridModels.CreditType
{
    using System;
    using Common.Grid.Attributes;



    /// <summary>
    /// Model for user grid row
    /// </summary>
    [GridProperties]
    public class CreditTypeRowViewModel
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Номер типа кредита", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public int Id { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Имя типа кредита", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public string Name { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Процент по кредиту", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public double Percent { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Штрафной процент", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public double OverduePercent { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Срок возврата", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public int ReturnTerm { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Boolean, ColumnEditType = GridColumnTypes.Base, ColumnName = "Активен?", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public bool IsActive { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Описание", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public string Description { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Валюта", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public string CurrencyShort { get; set; }

    }
}
