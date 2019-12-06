using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTools.Meetings.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingsController : ControllerBase
    {
        [HttpGet]
        [Route("Date")]
        public string GetDate()
        {
            return DateTime.Now.ToString();
        }
    }
}
