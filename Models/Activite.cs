using System.ComponentModel.DataAnnotations;

namespace ClubsGestionLastVersion.Models
{
   
    public class Activite
    {
        [Key]
        public int ActiviteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DateDebut { get; set; }

        [Required]
        public DateTime DateFin { get; set; }

        // Foreign key
        public int ClubId { get; set; }

        // Navigation property
        public Club Club { get; set; }
    }
}
