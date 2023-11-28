using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmaAPI.Models
{
	public class Invoice
	{
		[Key]
		public int RecordId { get; set; }
		public string? Code { get; set; }
		public string? InvoiceNumber { get; set; }
		public DateTime? InvoiceDate { get; set; }
		public decimal? OrderNumber { get; set; }
		public DateTime? OrderDate { get; set; }
		public decimal? Quantity { get; set; }
		public decimal? UnitPrice { get; set; }
		public decimal? Vat { get; set; }
		public decimal? VatRate { get; set; }
		public decimal? TotalAmount { get; set; }
		public bool? Status { get; set; }
		public bool? Deleted { get; set; }


		public List<Item> Items { get; set; }
		public virtual Company? Company { get; set; } //id olarak bağlamak için
		public virtual Customer? Customer { get; set; }
	}

}
