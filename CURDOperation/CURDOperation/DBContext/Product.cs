using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CURDOperation.DBContext
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column("ProductName",TypeName ="Varchar(50)")]
        public string Name { get; set; }
        [Column("Product_Description", TypeName = "Varchar(200)")]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
