using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "First name is too long")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Last name is too long")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Username is too long")]
        public string UserName { get; set; }

        [MaxLength(200, ErrorMessage = "Email is too long")]
        public string Email { get; set; }

        // Image
        public string ProfilePicture { get; set; }

        // Add properties -
        //[ForeignKey("SentToId")]
        //public virtual List<Friend> FriendList { get; set; }
    }
}