using System.ComponentModel.DataAnnotations.Schema;

namespace Countries_Api.Dtos.productdto
{
    public class productcreatedto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
