using System;
using Common.Enum;
using Common.Grid.Attributes;

namespace BLL.Models.GridModels.Credit
{
    [GridProperties]
    public class CreditRowModel
    {
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Номер кредита", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public String Id { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Дата открытия", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public DateTime StartDate { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Взятая сумма", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public decimal StartAmount { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Основная задолженность", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public decimal MainDebt { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Имя клиента", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public string ClientName { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Тип кредита", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public string CreditTypeName { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Задолженность по процентам", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public decimal PercentageDebt { get; set; }
    }
}
