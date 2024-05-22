using System.ComponentModel.DataAnnotations;

namespace ClubsGestionLastVersion.Models
{
    public class Evenement
    {
        [Key]
        public int EvenementId { get; set; }

        [Required]
        [StringLength(100)]
        public string NomEvenement { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DateEvenement { get; set; }

        // Foreign key
        public int ClubId { get; set; }

        // Navigation property
        public Club Club { get; set; }
    }
}
