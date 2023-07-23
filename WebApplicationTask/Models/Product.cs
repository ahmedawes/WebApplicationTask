using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationTask.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		[DisplayName("Product Name")]
		public string? ProdName { get; set; }

		[DisplayName("Product Price")]
		public double ProdPrice { get; set; }

		[DisplayName("Product Quantity")]
		[Range(1, 100, ErrorMessage = "ProdQty must be between 1-100")]
		public double ProdQty { get; set; }

	
    }
}
