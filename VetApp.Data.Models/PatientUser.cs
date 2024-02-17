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

        public Guid UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual ApplicationUser User { get; set; } = null!;
    }
}
