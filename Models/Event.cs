using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_API.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
    }
}
