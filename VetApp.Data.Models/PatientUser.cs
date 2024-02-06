using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetApp.Data.Models
{
	public class PatientUser
	{
        public Guid PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual VetUser User { get; set; } = null!;
    }
}
