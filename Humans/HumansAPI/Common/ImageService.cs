namespace HumansAPI.Common
{
    public class ImageService : IImageService
    {
        public async Task<string> UploadImage(IFormFile imageFile)
        {
            var imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var folder = "Images";
            var imagePath = $@"{folder}/{imageName}";
            Directory.CreateDirectory(folder);
            await using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imagePath;
        }
    }
}
