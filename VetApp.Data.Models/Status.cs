namespace VetApp.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	public class Status
	{
        [Key]
        public int Id { get; set; }

        [Required]
		public string Name { get; set; } = null!;

    }
}
