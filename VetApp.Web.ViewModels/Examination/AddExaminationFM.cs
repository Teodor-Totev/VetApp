namespace VetApp.Web.ViewModels.Examination
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.ExaminationValidations;

    public class AddExaminationFM
    {
        public AddExaminationFM()
        {
            this.CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string User { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int? Weight { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Reason { get; set; }

        [MaxLength(TextMaxLength)]
        public string? MedicalHistory { get; set; }

        [MaxLength(TextMaxLength)]
        public string? CurrentCondition { get; set; }

        [MaxLength(TextMaxLength)]
        public string? SpecificCondition { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Research { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Diagnosis { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Surgery { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Therapy { get; set; }

        [MaxLength(TextMaxLength)]
        public string? Exit { get; set; }

        public DateTime? NextExamination { get; set; }
    }
}
