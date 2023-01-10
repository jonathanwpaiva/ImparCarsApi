using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Impar.Cars.Api.Models
{
    public class Car
    {       
        public int id { get; set; }

        public int photoid { get; set; }

        public string name { get; set; }

        public string status { get; set; }
    }
}
