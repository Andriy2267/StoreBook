using System.ComponentModel.DataAnnotations;

namespace StoreBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Category name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 80 chars")]
        public string Name { get; set; }
        [Display(Name = "Display order")]
        [Range(minimum: 1, maximum: 100, ErrorMessage = "Order must be between 1 and 100")]
        [Required(ErrorMessage = "DisplayOrder is required")]
        public int DisplayOrder { get; set; }
    }
}
