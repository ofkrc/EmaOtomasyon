using EmaAPI.Models.Request.InvoiceLine;
using EmaAPI.Models.Request.Item;

namespace EmaAPI.Models.Request.Invoice
{
	public class InvoiceRequestModel
	{
		public int RecordId { get; set; }
		public string? Code { get; set; }
		public string? InvoiceNumber { get; set; }
		public DateTime? InvoiceDate { get; set; }
		public decimal? OrderNumber { get; set; }
		public DateTime? OrderDate { get; set; }
		public decimal? TotalAmount { get; set; }
		public bool? Status { get; set; }
		public bool? Deleted { get; set; }
		public int CompanyId { get; set; } 
		public int CustomerId { get; set; }
		public int UserId { get; set; }

		public List<InvoiceLineRequestModel> invoiceLineRequestModels { get; set; }
	}
}
