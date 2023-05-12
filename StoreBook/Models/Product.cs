using System.ComponentModel.DataAnnotations;

namespace StoreBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Title")]
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Display(Name = "Author")]
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name ="List price")]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Price for 1-50")]
        public double Price { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Price for 50+")]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 1000)]
        [Display(Name = "Price for 100+")]
        public double Price100 { get; set; }
    }
}
