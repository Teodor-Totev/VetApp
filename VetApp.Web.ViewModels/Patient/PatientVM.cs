﻿namespace VetApp.Web.ViewModels.Patient
{
    public class PatientVM
	{
        public PatientVM()
        {
            Examinations = new HashSet<PatientExaminationVM>();
        }

        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string Neutered { get; set; } = null!;

        public DateTime? BirthDate { get; set; }

        public string? Age { get; set; }

        public string? Microchip { get; set; }

        public string? Characteristics { get; set; }

        public string? ChronicIllnesses { get; set; }

        public ICollection<PatientExaminationVM> Examinations { get; set; }
    }
}
