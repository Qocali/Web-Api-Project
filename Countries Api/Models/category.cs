using System.ComponentModel.DataAnnotations.Schema;

namespace Countries_Api.Models
{
    public class category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsDeactive { get; set; }

        public List<product> products { get; set; }
    }
}
