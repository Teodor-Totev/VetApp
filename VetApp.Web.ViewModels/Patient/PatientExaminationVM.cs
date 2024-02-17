using System.ComponentModel.DataAnnotations;
using static VetApp.Common.EntityValidationConstants.ExaminationValidations;

namespace VetApp.Web.ViewModels.Patient
{
	public class PatientExaminationVM
	{
        public int Id { get; set; }

		[DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

		[Required]
		[MaxLength(DescMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[MaxLength(StateMaxLength)]
		public string State { get; set; } = null!;

		public int PatientId { get; set; }
	}
}
