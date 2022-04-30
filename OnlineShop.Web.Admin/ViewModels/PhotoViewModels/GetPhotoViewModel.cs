namespace OnlineShop.Web.Admin.ViewModels.PhotoViewModels
{
    public class GetPhotoViewModel
    {
        public int Id { get; set; }
        public string PhotoURL { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
    }
}
