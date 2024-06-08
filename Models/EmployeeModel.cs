using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeFirst.Models
{
    
    [Table("employees")]
    public class EmployeeModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("first_name")]
        public string Name { get; set; }

        [Required]
        [Column("last_name")]
        public string Surname { get; set; }

        [Required]
        [Column("email")]
        [EmailAddress, Display(Name="The E-Mail")]
        public string Email { get; set; }

    }
}
