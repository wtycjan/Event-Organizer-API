
using event_API.DBContexts;
using event_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace event_API.Controllers
{
    [Route("api/Event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private MyDBContext myDbContext;

        public EventController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<Event> Get()
        {
            return (this.myDbContext.Events.ToList());
        }

        [HttpDelete("{eventId:int}")]
        public IActionResult Delete(int eventId)
        {
            try { 
                if (eventId <= 0)
                    return BadRequest("Not a valid event id");

                Event eventToDelete = myDbContext.Events.Find(eventId);
                var listOfParticipantId = myDbContext.Participants.Select(r => r.Id);
                var particpantsInEvent = myDbContext.Participants.Where(r => listOfParticipantId.Contains(r.EventId));
                foreach (Participant participant in particpantsInEvent)
                {
                    myDbContext.Participants.Remove(participant);
                }
                myDbContext.Events.Remove(eventToDelete);
                myDbContext.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPost]
        public IActionResult Post(Event newEvent)
        {
            try { 
                if (newEvent == null)
                {
                    return BadRequest();
                }

                myDbContext.Events.Add(newEvent);
                myDbContext.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

    }
}
