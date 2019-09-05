using System;
using System.ComponentModel.DataAnnotations;

namespace Zadanie_Rekrutacyjne.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be at least 1 and at most 100 characters.")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]     
        public decimal Price { get; set; }
        
        protected Product() { }
        public Product(string name, decimal price)
        {   
            Name = name;
            Price = price;
            Id = Guid.NewGuid();
        }
        protected Product(string name, decimal price, Guid id)
        {
            Name = name;
            Price = price;
        }

    }

}