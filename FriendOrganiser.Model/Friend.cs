using System.ComponentModel.DataAnnotations;

namespace FriendOrganiser.Model
{
    public class Friend
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
