using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ruby.Models
{
    [Table("Chat")]
    public class Chat
    {
        [Key]
        public Guid ChatId { get; set; }
        
        //[StringLength(25, ErrorMessage = "Chat name is too long")]
        //public string ChatName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        
        public DateTime TimeSent { get; set; }

        public Guid? ServerId { get; set; }
        public string UserId { get; set; }

        // Navigation
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("ServerId")]
        public virtual Server Server { get; set; }
    }
}