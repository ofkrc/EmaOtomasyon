﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmaAPI.Models
{
	public class Customer
	{
		[Key]
		public int RecordId { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(20)]
		[Required(ErrorMessage = "Bu alan boş geçilemez!")]
		public string? Name { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(20)]
		[Required(ErrorMessage = "Bu alan boş geçilemez!")]
		public string? Surname { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(100)]
		public string? Address { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(50)]
		public string? Email { get; set; }

		[Column(TypeName = "Varchar")]
		[StringLength(15)]
		public string? PhoneNumber { get; set; }

		public ICollection<Invoice>? Invoices { get; set; } //bir customerın birden fazla faturası olabilir.
		public virtual Company? Company { get; set; } //id olarak bağlamak için
		public bool Status { get; set; }
	}

}
