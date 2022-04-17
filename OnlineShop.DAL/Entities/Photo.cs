

using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.DAL.Entities
{
    public class Photo : BaseEntity
    {
        //public byte[] Bytes { get; set; }
        //public decimal Size { get; set; }
        public string PhotoURL { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
