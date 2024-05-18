using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogProductsMVVM.Model
{
    public class Product
    {
        [Key]
        public int Id_Product { get; set; }
        public string? Title { get; set; }
        public decimal Cost { get; set; }
        public string? Photo { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }   
        public string? Producer { get; set; }

        [ForeignKey("Categories")]
        [Column("Fk_Category")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
