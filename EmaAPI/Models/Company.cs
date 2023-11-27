using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmaAPI.Models
{
	public class Company
	{

		[Key]
		public int CompanyID { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(100)]
		[Required(ErrorMessage = "This field cannot be empty!")]
		public string? CompanyName { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(100)]
		public string? Address { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(15)]
		public string? PhoneNumber { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(200)]
		public string? Website { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		[Required(ErrorMessage = "This field cannot be empty!")]
		public string? Email { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string? TaxOffice { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string? TaxID { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(255)]
		[Required(ErrorMessage = "This field cannot be empty!")]
		public string? Password { get; set; }

		public ICollection<Customer>? Customer { get; set; }
		public ICollection<Invoice>? Invoice { get; set; }
		public bool Status { get; set; }

		

	}
}
