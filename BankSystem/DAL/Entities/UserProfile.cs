namespace DAL.Entities
{
    public class UserProfile : BaseEntity
    {

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
