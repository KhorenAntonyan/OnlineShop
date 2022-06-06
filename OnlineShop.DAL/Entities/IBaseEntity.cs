
namespace OnlineShop.DAL.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        DateTime? IsDeleted { get; set; }
    }
}
