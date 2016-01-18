using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enum;
using Common.Grid.Attributes;

namespace BLL.Models.GridModels.DepositType
{
    [GridProperties]
    public class DepositTypeRowModel
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Номер типа вклада", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public int Id { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Имя типа вклада", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public string Name { get; set; }

        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Процент по вкладу", IsKey = true, Order = 1, IsSortable = false, DataField = "Id", ModelField = "UserId")]
        public double Percent { get; set; }

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
