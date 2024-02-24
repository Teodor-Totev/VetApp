namespace VetApp.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.StatusValidations;

	public class Status
	{
        public Status()
        {
			this.Examinations = new HashSet<Examination>();    
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

        public ICollection<Examination> Examinations { get; set; }
    }
}
