
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
    [Route("api/Participant")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private MyDBContext myDbContext;

        public ParticipantController(MyDBContext context)
        {
            myDbContext = context;
        }

        [HttpPost]
        public IActionResult Post(Participant participant)
        {
            try
            {
                if (participant == null)
                {
                    return BadRequest();
                }
                var count = myDbContext.Participants.Where(o => o.EventId == participant.EventId).Count();
                Console.WriteLine(count);
                if (count>25)
                {
                    return StatusCode(StatusCodes.Status405MethodNotAllowed,
                        "This event already has 25 participants");
                }

                myDbContext.Participants.Add(participant);
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
