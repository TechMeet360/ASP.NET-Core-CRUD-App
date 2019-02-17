using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Models
{
	using Microsoft.EntityFrameworkCore.Metadata.Internal;
	using System.ComponentModel.DataAnnotations;

	public class StudentViewModel
	{
		[Key]
		public string RegistrationId { get; set; }
		public string StudentName { get; set; }
		public string DateOfBirth { get; set; }
	}
}
