﻿namespace VetApp.Web.ViewModels.Patient
{
	public class PatientOwnerVM
	{
		public PatientOwnerVM()
		{
			this.Patients = new HashSet<PatientVM>();
		}

		public int Id { get; set; }

        public string Address { get; set; } = null!;

		public string OwnerName { get; set; } = null!;

		public string PhoneNumber { get; set; } = null!;

		public IEnumerable<PatientVM> Patients { get; set; }
    }
}
