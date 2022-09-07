using System.ComponentModel.DataAnnotations.Schema;

namespace Countries_Api.Models
{
    public class product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public category category { get; set; }
        public bool IsDeactive { get; set; }

    }
}
