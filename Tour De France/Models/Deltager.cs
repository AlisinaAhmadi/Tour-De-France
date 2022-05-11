using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tour_De_France.Models
{
    public class Deltager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(8)]
        public string Mobil { get; set; }
        [Required]
        public string Email { get; set; }
        public bool VIP { get; set; }
        [Required]
        public string Password { get; set; }

        public Deltager()
        {
            
        }
        public Deltager(string email,string password)
        {
            Email = email;
            Password = password;
        }
    }
}
