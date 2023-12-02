using EmaAPI.Models.Request.Invoice;
using System.ComponentModel.DataAnnotations;

namespace EmaAPI.Models.Request.Item
{
	public class ItemRequestModel
	{
		public int? RecordId { get; set; }
		public string? Name { get; set; }
		public string? Code { get; set; }
		public string? Description { get; set; }
		public decimal? SalesPrice { get; set; }
		public decimal? PurchasePrice { get; set; }
		public decimal? DiscountRate { get; set; }
		public decimal? VatRate { get; set; }
		public int? StockQuantity { get; set; }
		public DateTime? CreatedDatetime { get; set; }
		public DateTime? UpdatedDatetime { get; set; }
		public bool? Deleted { get; set; }
		public int? UserId { get; set; }
	}
}
