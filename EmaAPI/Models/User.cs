using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmaAPI.Models
{
	public class User
	{
		[Key]
		public int RecordId { get; set; } 

		[Required]
		[MaxLength(256)]
		public string UserName { get; set; }

		[Required]
		[MaxLength(256)]
		public string Email { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Surname { get; set; }

		[Required]
		public string CompanyName { get; set; }

		public DateTime CreatedDatetime { get; set; } = DateTime.UtcNow;

		public bool IsActive { get; set; } = true;

	}
}
