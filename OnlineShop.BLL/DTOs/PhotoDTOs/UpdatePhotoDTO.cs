
namespace OnlineShop.BLL.DTOs.PhotoDTOs
{
    public class UpdatePhotoDTO
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
    }
}
