using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Web.ViewModels.Patient
{
	public class AllPatientsVM
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public string OwnerName { get; set; } = null!;

		public string Type { get; set; } = null!;

		public DateTime? BirthDate { get; set; }

		public string? MicroChip { get; set; }

		public string Gender { get; set; } = null!;

		public string Neutered { get; set; } = null!;
	}
}
