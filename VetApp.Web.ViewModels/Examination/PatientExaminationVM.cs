using System.ComponentModel.DataAnnotations;
using static VetApp.Common.EntityValidationConstants.ExaminationValidations;

namespace VetApp.Web.ViewModels.Examination
{
    public class PatientExaminationVM
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public string Doctor { get; set; } = null!;

        public int PatientId { get; set; }
    }
}
