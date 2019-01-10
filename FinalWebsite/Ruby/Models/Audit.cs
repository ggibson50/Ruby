using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    public class Audit
    {
        public Guid AuditId { get; set; }
        public string Log { get; set; }

        public Guid ServerId { get; set; }

        // Navigation
        [ForeignKey("ServerId")]
        public virtual Server Server { get; set; }
    }
}