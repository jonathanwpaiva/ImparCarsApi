using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;

namespace Impar.Cars.Api.Services.Interfaces
{
    public interface IUploadImage
    {
        public Task<string> UploadImageToSpecificFolder(IFormFile file);
        public List<string> GetAllImges();
    }
}
