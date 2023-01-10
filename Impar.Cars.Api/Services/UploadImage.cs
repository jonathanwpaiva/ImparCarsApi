using Impar.Cars.Api.Services.Interfaces;
using ServiceStack;
using ServiceStack.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace Impar.Cars.Api.Services
{
    public class UploadImage : IUploadImage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string base64File = "";


        public UploadImage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public List<string> GetAllImges()
        {
            var imagesList = new List<string>();

            var folderPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedImages");

            string[] allImages = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);

            foreach (string image in allImages)
            {
                imagesList.Add(image);
            }

            return imagesList;
        }

        public async Task<string> UploadImageToSpecificFolder(IFormFile file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var fileExtension = Path.GetExtension(fileName);

            var image = Image.FromStream(file.OpenReadStream());
            var resized = new Bitmap(image, new Size(90, 90));
            using var imageStream = new MemoryStream();
            resized.Save(imageStream, ImageFormat.Jpeg);
            var imageBytes = imageStream.ToArray();
            base64File = Convert.ToBase64String(imageBytes);

            var newFileName = Guid.NewGuid().ToString() + fileExtension;

            var folderPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedImages");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var filePath = Path.Combine(folderPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);

            }

            return base64File;
        }
    }
}