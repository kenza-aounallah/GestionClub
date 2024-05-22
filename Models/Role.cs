using System.ComponentModel.DataAnnotations;

namespace ClubsGestionLastVersion.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string NomRole { get; set; }

        public string Description { get; set; }

        // Navigation property
        public ICollection<Membre> Membres { get; set; }
    }
}
