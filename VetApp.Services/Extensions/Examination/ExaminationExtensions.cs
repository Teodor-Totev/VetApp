namespace VetApp.Services.Extensions.Examination
{
    using VetApp.Data.Models;
    using VetApp.Web.ViewModels.Examination;

    public static class ExaminationExtensions
    {
        public static ExaminationViewModel ToViewModel(this Examination examination)
        {
            return new ExaminationViewModel()
            {
                Id = examination.Id.ToString(),
                CreatedOn = examination.CreatedOn,
                Reason = examination.Reason,
                PatientName = examination.Patient.Name,
                DoctorName = examination.Doctor.FirstName + " " + examination.Doctor.LastName,
                StatusName = examination.Status.Name,
                PatientId = examination.PatientId.ToString()
            };
        }
    }
}
