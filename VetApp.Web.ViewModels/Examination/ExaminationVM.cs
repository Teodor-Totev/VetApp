namespace VetApp.Web.ViewModels.Examination
{
	using System.ComponentModel.DataAnnotations;

	public class ExaminationVM
	{
		public int Id { get; set; }

		[DataType(DataType.Date)]
		public DateTime CreatedOn { get; set; }

		public string Doctor { get; set; } = null!;
	}
}
