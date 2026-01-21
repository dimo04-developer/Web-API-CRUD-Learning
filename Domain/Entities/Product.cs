using System;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}