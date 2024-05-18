using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CatalogProductsMVVM.Model
{
    public class Category
    {
        [Key]
        public int Id_Category { get; set; }
        public string? CategoryName { get; set; }

        public virtual List<Product>? Products { get; set;}
    }
}
