using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    public class Friend
    {
        // Composite key
        [Key, Column(Order = 0)]
        public string SentFromId { get; set; }

        [Key, Column(Order = 1)]
        public string SentToId { get; set; }

        public bool IsAccepted { get; set; }

        // Navigation
        [ForeignKey("SentFromId")]
        public virtual User SendFrom { get; set; }

        [ForeignKey("SentToId")]
        public virtual User SendTo { get; set; }
    }
}