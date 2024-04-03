namespace EmaOtomasyon.Models.Item.Response
{
    public class ItemResponseModel
    {
        public int RecordId { get; set; }  //recorid değerini ? nullable kontrolü verirsen db'ye kayıt atmıyor.
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? StockQuantity { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? VatRate { get; set; }
        public bool? Deleted { get; set; }
        public int? UserId { get; set; }
        public DateTime? UpdatedDatetime { get; set; }
        public DateTime? CreatedDatetime { get; set; }
    }
}
