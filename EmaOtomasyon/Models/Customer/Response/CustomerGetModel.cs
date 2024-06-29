namespace EmaOtomasyon.Models.Customer.Response
{
    public class CustomerGetModel
    {
        public int RecordId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? UpdatedDatetime { get; set; }
        public DateTime? CreatedDatetime { get; set; }
    }
}
