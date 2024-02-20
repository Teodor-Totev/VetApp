using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Data.Models;
using VetApp.Web.ViewModels.Patient;

namespace VetApp.Services.Interfaces
{
	public interface IPatientService
	{
		Task CreateAsync(CreateVM model, string userId);

		Task<ICollection<PatientVM>> GetAllPatientsAsync();

		Task<ICollection<PatientVM>> GetUserPatientsAsync(string userId);


	}
}
