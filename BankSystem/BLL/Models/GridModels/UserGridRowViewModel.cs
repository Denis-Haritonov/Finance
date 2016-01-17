using Common.Enum;
using Common.Grid.Attributes;

namespace BLL.Models.GridModels
{
    using System;
    using Common.Grid.Attributes;



    /// <summary>
    /// Model for user grid row
    /// </summary>
    [GridProperties]
    public class UserGridRowViewModel
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Номер пользователя", IsKey = true, Order = 1, IsSortable = true, DataField = "UserId", ModelField = "UserId")]
        public int UserId { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Input, ColumnName = "Логин", Order = 2, IsSortable = true, DataField = "Name", ModelField = "Name")]
        public string Login { get; set; }/// <summary>
                                        /// 
        /// User name
        /// </summary>
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Input, ColumnName = "Имя", Order = 3, IsSortable = true, DataField = "Name", ModelField = "Name")]
        public string UserName { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Input, ColumnName = "Фамилия", Order = 4, IsSortable = true, DataField = "Name", ModelField = "Name")]
        public string UserSurname { get; set; }

        /// <summary>
        /// User role name
        /// </summary>
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Роль", Order = 5, IsSortable = true, DataField = "Company.Type", ModelField = "Role")]
        public string Role { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        [RowDisplay(ColumnDisplayType = GridColumnTypes.Base, ColumnEditType = GridColumnTypes.Base, ColumnName = "Email", Order = 7, IsSortable = true, DataField = "Email", ModelField = "Email")]
        public string Email { get; set; }

    }
}
