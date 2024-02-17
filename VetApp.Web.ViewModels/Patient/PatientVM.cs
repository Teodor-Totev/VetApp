using System.ComponentModel.DataAnnotations;
using VetApp.Data.Models;

namespace VetApp.Web.ViewModels.Patient
{
	public class PatientVM
	{
        public PatientVM()
        {
            Examinations = new HashSet<PatientExaminationVM>();
        }

        public ICollection<PatientExaminationVM> Examinations { get; set; }
    }
}
