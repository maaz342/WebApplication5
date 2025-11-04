using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }


    }
}
