using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Meetings.CoreObjects;
using ProducvitityTools.Meetings.Commands;
using ProducvitityTools.Meetings.Queries;
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
        private readonly IMapper mapper;
        IMeetingQueries MeetingQueries;
        IMeetingCommands MeetingCommands;

        public MeetingsController(IMeetingQueries meetingQueries, IMeetingCommands meetingCommands, IMapper mapper)
        {
            this.MeetingQueries = meetingQueries;
            this.mapper = mapper;
            this.MeetingCommands = meetingCommands;
        }

        [HttpGet]
        [Route("Date")]
        public string GetDate()
        {
            return DateTime.Now.ToString();
        }

        [HttpPost]
        [Route(Consts.ListName)]
        public List<Meeting> Get()
        {
            var partresult = MeetingQueries.GetMeetings();
            List<Meeting> result = this.mapper.Map<List<Meeting>>(partresult);
            return result;
        }

        [HttpPost]
        [Route(Consts.AddMeetingName)]
        public void Save(Meeting meeting)
        {
            Database.Objects.Meeting dbMeeting = this.mapper.Map<Database.Objects.Meeting>(meeting);
            MeetingCommands.Save(dbMeeting);
        }
    }
}
