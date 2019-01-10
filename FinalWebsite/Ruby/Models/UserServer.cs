using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    public class UserServer
    {
        [Key, Column(Order = 0)]
        public Guid ServerId { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        // Navigation
        [ForeignKey("ServerId")]
        public virtual Server Server { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}