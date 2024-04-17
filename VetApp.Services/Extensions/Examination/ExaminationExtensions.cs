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

        public static ExaminationDetailsViewModel ToExaminationDetailsViewModel(this Examination e)
        {
            return new ExaminationDetailsViewModel()
            {
                Id = e.Id.ToString(),
                Weight = e.Weight,
                Reason = e.Reason,
                Diagnosis = e.Diagnosis,
                CreatedOn = e.CreatedOn,
                Surgery = e.Surgery,
                DoctorName = e.Doctor.FirstName + " " + e.Doctor.LastName,
                Therapy = e.Therapy,
                StatusName = e.Status.Name,
                SpecificCondition = e.SpecificCondition,
                CurrentCondition = e.CurrentCondition,
                Exit = e.Exit,
                MedicalHistory = e.MedicalHistory,
                Research = e.Research,
                PatientName = e.Patient.Name
            };
        }

        public static PreDeleteDetailsViewModel ToPreDeleteDetailsViewModel(this Examination examination)
        {
            return new PreDeleteDetailsViewModel()
            {
                Id = examination.Id.ToString(),
                StatusName = examination.Status.Name,
                PatientName = examination.Patient.Name,
                PatientId = examination.Patient.Id.ToString(),
                DoctorName = examination.Doctor.FirstName + " " + examination.Doctor.LastName,
                CreatedOn = examination.CreatedOn,
                Reason = examination.Reason,
                Weight = examination.Weight
            };
        }

        public static ExaminationFormModel ToExaminationFormModel(this Examination e)
        {
            return new ExaminationFormModel()
            {
                DoctorId = e.DoctorId.ToString(),
                Weight = e.Weight,
                Reason = e.Reason,
                CreatedOn = e.CreatedOn,
                MedicalHistory = e.MedicalHistory,
                CurrentCondition = e.CurrentCondition,
                SpecificCondition = e.SpecificCondition,
                Research = e.Research,
                Diagnosis = e.Diagnosis,
                Surgery = e.Surgery,
                Therapy = e.Therapy,
                Exit = e.Exit,
                StatusId = e.StatusId
            };
        }

        public static ExaminationDashboardViewModel ToExaminationDashboardViewModel(this Examination e)
        {
            return new ExaminationDashboardViewModel()
            {
                Id = e.Id.ToString(),
                PatientId = e.PatientId.ToString(),
                PatientName = e.Patient.Name,
                PatientType = e.Patient.Type,
                DoctorName = "Dr." + e.Doctor.FirstName + " " + e.Doctor.LastName,
                CreatedOn = e.CreatedOn
            };
        }

        public static void UpdateFromFormModel(this Examination targetExamination, ExaminationFormModel model)
        {
            targetExamination.Weight = model.Weight;
            targetExamination.Reason = model.Reason;
            targetExamination.MedicalHistory = model.MedicalHistory;
            targetExamination.CurrentCondition = model.CurrentCondition;
            targetExamination.SpecificCondition = model.SpecificCondition;
            targetExamination.Research = model.Research;
            targetExamination.Diagnosis = model.Diagnosis;
            targetExamination.Surgery = model.Surgery;
            targetExamination.Therapy = model.Therapy;
            targetExamination.Exit = model.Exit;
            targetExamination.StatusId = model.StatusId;
            targetExamination.CreatedOn = model.CreatedOn;
        }

        public static Examination ToExaminationEntity(this ExaminationFormModel model, string patientId, string doctorId)
        {
            return new Examination
            {
                DoctorId = Guid.Parse(doctorId),
                CreatedOn = model.CreatedOn,
                Weight = model.Weight,
                Reason = model.Reason,
                MedicalHistory = model.MedicalHistory,
                CurrentCondition = model.CurrentCondition,
                SpecificCondition = model.SpecificCondition,
                Research = model.Research,
                Diagnosis = model.Diagnosis,
                Surgery = model.Surgery,
                Therapy = model.Therapy,
                Exit = model.Exit,
                StatusId = model.StatusId,
                PatientId = Guid.Parse(patientId),
            };
        }
    }
}
