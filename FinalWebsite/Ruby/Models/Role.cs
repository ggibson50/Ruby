using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        public Guid ServerId { get; set; }

        [Required]
        [Display(Name = "Role Name")]
        [MaxLength(25, ErrorMessage = "Name is too long")]
        public string RoleName { get; set; }

        [Display(Name = "Administrator")]
        public bool isAdmin { get; set; }

        [Display(Name = "Moderator")]
        public bool isMod { get; set; }

        [ForeignKey("ServerId")]
        public virtual Server Server { get; set; }
    }
}