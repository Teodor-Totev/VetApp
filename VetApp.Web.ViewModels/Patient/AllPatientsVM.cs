
namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;
	public class AllPatientsVM
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		[Display(Name = "Owner Name")]
		public string OwnerName { get; set; } = null!;

		public string Type { get; set; } = null!;

		[Display(Name = "Birth Date")]
		[DataType(DataType.Date)]
		public DateTime? BirthDate { get; set; }

		public string? Microchip { get; set; }

		public string Gender { get; set; } = null!;

		public string Neutered { get; set; } = null!;
	}
}
