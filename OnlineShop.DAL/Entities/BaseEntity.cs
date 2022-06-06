
namespace OnlineShop.DAL.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; }
        public DateTime? IsDeleted { get; set; }
    }
}
