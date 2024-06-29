namespace EmaOtomasyon.Models.Company.Response
{
    public class CompanyResponseModel
    {

        public int RecordId { get; set; }  //recorid değerini ? nullable kontrolü verirsen db'ye kayıt atmıyor.
        public string? Code { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? TaxOffice { get; set; }
        public string? TaxNo { get; set; }
        public bool? Status { get; set; }
        public bool? Deleted { get; set; }
        public int? UserId { get; set; }
        public DateTime? UpdatedDatetime { get; set; }
        public DateTime? CreatedDatetime { get; set; }
    }
}
