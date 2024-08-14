using System.ComponentModel.DataAnnotations;

namespace Dummymvc3.Models
{
    public class ProductViewModel
    {
        [Key]
        public int Pid { get; set; }
        public string? Pname { get; set; }
        public string? Pcat { get; set; }
        public double Price { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
