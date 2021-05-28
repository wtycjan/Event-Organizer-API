using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_API.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
    }
}
