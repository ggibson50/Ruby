using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    [Table("Server")]
    public class Server
    {
        [Key]
        [Display(Name = "Server")]
        public Guid ServerId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ServerName { get; set; }

        public string ServerImage { get; set; }


        // Navigation
        [ForeignKey("ServerId")]
        public virtual List<UserServer> Members { get; set; }

        public virtual List<Audit> AuditLog { get; set; }

        public virtual List<Role> Roles { get; set; }
    }
}