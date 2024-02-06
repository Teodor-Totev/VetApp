using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetApp.Common.EntityValidationConstants;

namespace VetApp.Data.Models
{
	public class PatientUser
	{
        public int PatientId { get; set; }

		[ForeignKey(nameof(PatientId))]
		public virtual Patient Patient { get; set; } = null!;

        public Guid UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual VetUser User { get; set; } = null!;
    }
}
