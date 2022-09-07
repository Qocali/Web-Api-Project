using System.ComponentModel.DataAnnotations.Schema;

namespace Countries_Api.Dtos.productdto
{
    public class productgetdto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
