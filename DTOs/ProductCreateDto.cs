using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage ="name is Required" )]
        [StringLength(100, MinimumLength=3,ErrorMessage=" Must between 3 and 100")]
        public string Name {get;set;}
        [Range(0,1000000, ErrorMessage="Price Range must between 0 to 1000000")]
        public decimal Price {get;set;}
        public string? Description {get;set;}        
        public DateTime ExpiryDate {get;set;}
    }
    
}