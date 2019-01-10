using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    public class UserRole
    {
        // Composite Key
        [Key, Column(Order = 0)]
        public Guid RoleId { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        [Key, Column(Order = 2)]
        public Guid ServerId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}