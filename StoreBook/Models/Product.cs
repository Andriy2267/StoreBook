using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name ="Image URL")]
        [Required(ErrorMessage ="Image URL is required")]
        [ValidateNever]
        public string ImageURL { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
    }
}
