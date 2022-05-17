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
        public string Name { get; set; }
        [Required]
        public string Mobil { get; set; }
        [Required]
        public string Email { get; set; }
        public bool VIP { get; set; }
        [Required]
        public string Password { get; set; }

        public Deltager()
        {
            
        }
        public Deltager(string name, string mobil,string email,string password)
        {
            Name = name;
            Mobil = mobil;
            Email = email;
            Password = password;
            
        }
    }
}
