using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BotWatson.Models
{
    public class Bot
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
