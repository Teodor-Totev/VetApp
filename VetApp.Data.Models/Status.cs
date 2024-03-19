namespace VetApp.Data.Models
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.StatusValidations;

	public class Status
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

    }
}
