using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetApp.Data.Models
{
	[Comment("User Patints")]
	public class PatientUser
	{
        public int PatientId { get; set; } 

		[ForeignKey(nameof(PatientId))]
		public virtual Patient Patient { get; set; } = null!;

        public Guid DoctorId { get; set; }

		[ForeignKey(nameof(DoctorId))]
		public virtual ApplicationUser Doctor { get; set; } = null!;
    }
}
