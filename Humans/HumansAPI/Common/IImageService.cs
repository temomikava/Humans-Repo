namespace HumansAPI
{
    public interface IImageService
    {
        Task<string> UploadImage(IFormFile imageFile);
    }
}
