using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmaAPI.Models
{
	public class Invoice
	{
		[Key]
		public int InvoiceID { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string? InvoiceNumber { get; set; }
		public DateTime InvoiceDate { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string? OrderNumber { get; set; }
		public DateTime OrderDate { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(100)]
		public string? Product { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Quantity { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? UnitPrice { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? Vat { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal? VatRate { get; set; }
		[Column(TypeName = "decimal(18,2)")]
		public decimal? TotalAmount { get; set; }
		public virtual Company? Company { get; set; }
		public virtual Customer? Customer { get; set; }
		public bool? Status { get; set; }
	}

}
