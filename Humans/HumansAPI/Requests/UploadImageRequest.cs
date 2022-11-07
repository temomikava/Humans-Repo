using System.ComponentModel.DataAnnotations.Schema;

namespace HumansAPI.Requests
{
    public class UploadImageRequest
    {
        public int HumanId { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
