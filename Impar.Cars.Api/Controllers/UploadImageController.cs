using Impar.Cars.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Impar.Cars.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private readonly IUploadImage _uploadImage;
       
        public UploadImageController(IUploadImage uploadImage)
        {
            _uploadImage = uploadImage;
        }

        [HttpGet("allimages")]
        public IActionResult GetAllImages() 
        {
            var images =  _uploadImage.GetAllImges();

            return Ok(images);
        }

        [HttpPost("uploadimage")]
        public async Task<IActionResult> UploadImageToSpecificFolder([FromForm] IFormFile file)
        {
            var base64FileName = await _uploadImage.UploadImageToSpecificFolder(file);
            return Ok(base64FileName);
        }       
    }
}
