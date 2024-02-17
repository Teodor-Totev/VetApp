using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VetApp.Data.Models;

namespace VetApp.Data.Configuration
{
	public class VetUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			//builder
			//	.HasData(GenerateDoctors());
		}

		//private VetUser[] GenerateDoctors()
		//{
		//	ICollection<VetUser> doctors = new HashSet<VetUser>();

		//	VetUser doctor;
		//	doctor = new VetUser()
		//	{
		//		Id = Guid.Parse("DAC0CA32-F631-4F41-6208-08DC27CDC049"),
		//		FirstName = "Test",
		//		LastName = "Test",
		//		Address = "гр.Димитровград",
		//		PatientsUsers = new PatientUser[]
		//		{
		//			new PatientUser()
		//			{
		//				PatientId = 1,
		//				UserId = Guid.Parse("DAC0CA32-F631-4F41-6208-08DC27CDC049"),
		//			},
		//			new PatientUser()
		//			{
		//				PatientId = 2,
		//				UserId = Guid.Parse("DAC0CA32-F631-4F41-6208-08DC27CDC049"),
		//			}
		//		}
		//	};
		//	doctors.Add(doctor);

		//	doctor = new VetUser()
		//	{
		//		Id = Guid.Parse("8A04781F-6A81-4C10-6209-08DC27CDC049"),
		//		FirstName = "Test",
		//		LastName = "Test",
		//		Address = "гр.Хасково",
		//		PatientsUsers = new PatientUser[]
		//		{
		//			new PatientUser()
		//			{
		//				PatientId = 3,
		//				UserId = Guid.Parse("8A04781F-6A81-4C10-6209-08DC27CDC049"),
		//			}
		//		}
		//	};
		//	doctors.Add(doctor);

		//	return doctors.ToArray();
		//}
	}
}
