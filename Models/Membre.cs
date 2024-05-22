using System.ComponentModel.DataAnnotations;

namespace ClubsGestionLastVersion.Models
{
    public class Membre
    {
        [Key]
        public int MembreId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [Required]
        public DateTime DateAdhesion { get; set; }

        // Foreign key
        public int ClubId { get; set; }

        // Navigation properties
        public Club Club { get; set; }
    }
}
