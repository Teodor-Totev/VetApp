using System.ComponentModel.DataAnnotations;
using static VetApp.Common.EntityValidationConstants.ExaminationValidations;

namespace VetApp.Web.ViewModels.Examination
{
    public class PatientExaminationVM
    {
        public PatientExaminationVM()
        {
            this.Examinations = new HashSet<ExaminationVM>();
        }
        
        public int Id { get; set; }

        public IEnumerable<ExaminationVM> Examinations { get; set; }
    }
}
