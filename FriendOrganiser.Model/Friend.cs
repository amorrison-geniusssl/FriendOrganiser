using System.ComponentModel.DataAnnotations;

namespace FriendOrganiser.Model
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(20)]
        public string Email { get; set; }
    }
}
