using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impar.Cars.Api.Models
{
    public class Photo
    {
        
        public int id { get; set; }
                
        public string Base64 { get; set; }
        
    }
}
