﻿namespace VetApp.Web.ViewModels.Examination
{
	public class ExaminationDashboardViewModel
	{
        public string Id { get; set; } = null!;

		public string PatientId { get; set; } = null!;

		public string PatientName { get; set; } = null!;

        public string PatientType { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        public DateTime CreatedOn { get; set;}
    }
}
