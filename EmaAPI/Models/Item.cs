using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmaAPI.Models
{
	
	public class Item
	{
		[Key]
		public int RecordId { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[StringLength(30)]
		public string Code { get; set; }

		[StringLength(1000)]
		public string Description { get; set; }

		[Required]
		[Range(0, double.MaxValue)]
		public decimal SalesPrice { get; set; }

		[Required]
		[Range(0, double.MaxValue)]
		public decimal PurchasePrice { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public int StockQuantity { get; set; }

		public decimal? DiscountRate { get; set; }
		public decimal? VatRate { get; set; }

		[Required]
		public DateTime CreatedDatetime { get; set; }

		public DateTime? UpdatedDatetime { get; set; }
		public bool? Deleted { get; set; }

		public int? UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public User? User { get; set; }

		public ICollection<InvoiceLine> InvoiceLine { get; set; }

	}

}
