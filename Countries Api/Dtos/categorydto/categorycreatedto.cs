using Countries_Api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Countries_Api.Dtos.categorydto
{
    public class categorycreatedto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public List<product> products { get; set; }
    }
}
