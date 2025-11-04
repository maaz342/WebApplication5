using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        public double price { get; set; }
        public string image { get; set; }
        [DisplayName("Category")]
        public int? categoryid { get; set; }
        public Category category { get; set; }
    }
}
