using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BotWatson.Models
{
    public class Messagem
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string ConversationId { get; set; }

        [Required]
        public string TimeStamp { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
