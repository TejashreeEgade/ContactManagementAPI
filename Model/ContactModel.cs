using System.ComponentModel.DataAnnotations;

namespace ContactManagementAPI.Model
{
    public class ContactModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required][EmailAddress]
        public string Email { get; set; } = string.Empty;

    }
}
