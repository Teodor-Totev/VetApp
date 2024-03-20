﻿namespace VetApp.Web.ViewModels.Patient
{
	using System.ComponentModel.DataAnnotations;

	using static Web.Common.ViewModelValidationConstants.QueryModelConstants;

	public class MinePatientsQueryModel
	{
		public MinePatientsQueryModel()
		{
			this.CurrentPage = defaultPage;
			this.PatientsPerPage = entitiesPerPage;
			this.Patients = new HashSet<PatientViewModel>();
		}

		public string DoctorId { get; set; } = null!;

        [Display(Name = "Search by word")]
		public string? SearchString { get; set; }

		public int CurrentPage { get; set; }

		[Display(Name = "Show animals on page")]
		public int PatientsPerPage { get; set; }

		public ICollection<PatientViewModel> Patients { get; set; }
	}
}
