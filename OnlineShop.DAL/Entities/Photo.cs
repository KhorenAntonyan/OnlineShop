
namespace OnlineShop.DAL.Entities
{
    public class Photo : BaseEntity
    {
        public string PhotoURL { get; set; }
        public int ProductId { get; set; }
        public bool IsMain { get; set; }
        public Product Product { get; set; }
    }
}
