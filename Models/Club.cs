using System.ComponentModel.DataAnnotations;
using System;

namespace ClubsGestionLastVersion.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nom { get; set; }

        public string Description { get; set; }

        // Navigation properties
        public ICollection<Membre> Membres { get; set; }
        public ICollection<Activite> Activites { get; set; }

    }
}
