using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Web.ViewModels.Patient;

namespace VetApp.Services.Interfaces
{
	public interface IPatientService
	{
		ICollection<PatientGender> GetPatientGender();
	}
}
