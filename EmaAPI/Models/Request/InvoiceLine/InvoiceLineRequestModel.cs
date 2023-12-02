using System.ComponentModel.DataAnnotations;

namespace EmaAPI.Models.Request.InvoiceLine
{
	public class InvoiceLineRequestModel
	{
		public int? RecordId { get; set; }
		public string? Code { get; set; }
		public string? Description { get; set; }
		public decimal? Quantity { get; set; }
		public decimal? UnitPrice { get; set; }
		public decimal? DiscountRate { get; set; }
		public decimal? VatRate { get; set; }
		public decimal? TotalAmount { get; set; }
		public bool? Status { get; set; }
		public bool? Deleted { get; set; }
		public int? InvoiceId { get; set; }
		public int? ItemId { get; set; }
		public int? UserId { get; set; }
	}
}
