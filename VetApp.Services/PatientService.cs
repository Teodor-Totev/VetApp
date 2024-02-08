using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetApp.Data;
using VetApp.Services.Interfaces;
using VetApp.Web.ViewModels.Patient;

namespace VetApp.Services
{
	public class PatientService : IPatientService
	{
		private readonly VetAppDbContext context;

        public PatientService(VetAppDbContext context)
        {
			this.context = context;
        }

	}
}
