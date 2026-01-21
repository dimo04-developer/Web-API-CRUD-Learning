namespace DTOs
{
    public class ProductCreateDto
    {
        public string Name {get;set;}
        public decimal Price {get;set;}
        public string? Description {get;set;}
        public DateTime ExpiryDate {get;set;}
    }
    
}