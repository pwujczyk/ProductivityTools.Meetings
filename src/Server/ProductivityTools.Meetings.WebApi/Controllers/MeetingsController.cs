using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public MeetingsController(IMeetingQueries meetingQueries, IMeetingCommands meetingCommands, IMapper mapper, IConfiguration configuration)
        {
            this.MeetingQueries = meetingQueries;
            this.mapper = mapper;
            this.MeetingCommands = meetingCommands;
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("Date")]
        public string GetDate()
        {
            return DateTime.Now.ToString();
        }

        [HttpPost]
        [Route("List2")]
        public string Get2(object name)
        {
            return $"Welcome {name.ToString()}";
        }

        [HttpPost]
        [Route("List3")]
        public string Get3(object name)
        {
            var remotesecret = name.ToString();
            string s = Environment.GetEnvironmentVariable("MeetingsSecret", EnvironmentVariableTarget.Machine);
            if (!string.IsNullOrEmpty(s))
            {
                if (remotesecret != s)
                {
                    throw new Exception("Wrong secret");
                }
            }
            return $"Welcome {name.ToString()} secret checked= {s}";
        }

        [HttpPost]
        [Route("List4")]
        public string Get4(object name)
        {
            var remotesecret = name.ToString();
            string s = Environment.GetEnvironmentVariable("MeetingsSecret", EnvironmentVariableTarget.Machine);
            return $"Welcome {name.ToString()} secret checked= {s}";
        }

        [HttpPost]
        [Route("List5")]
        public List<Meeting> Get5(object name)
        {
            var partresult = MeetingQueries.GetMeetings();
            List<Meeting> result = this.mapper.Map<List<Meeting>>(partresult);
            return result.Skip(2).Take(2).ToList();
        }




        [HttpPost]
        [Route(Consts.ListName)]
        public List<Meeting> Get(object name)
        {
            var remotesecret = name.ToString();
            string s = Environment.GetEnvironmentVariable("MeetingsSecret",EnvironmentVariableTarget.Machine);
            if (!string.IsNullOrEmpty(s))
            {
                if (remotesecret!=s)
                {
                    throw new Exception("Wrong secret");
                }
            }
            var partresult = MeetingQueries.GetMeetings();
            List<Meeting> result = this.mapper.Map<List<Meeting>>(partresult);
            return result;
        }

        [HttpPost]
        [Route(Consts.AddMeetingName)]
        //add validation
        public void Save(Meeting meeting)
        {
            Database.Objects.Meeting dbMeeting = this.mapper.Map<Database.Objects.Meeting>(meeting);
            MeetingCommands.Save(dbMeeting);
        }

        [HttpPost]
        [Route(Consts.UpdateMeetingName)]
        public void Update(Meeting meeting)
        {
            Database.Objects.Meeting dbMeeting = this.mapper.Map<Database.Objects.Meeting>(meeting);
            MeetingCommands.Update(dbMeeting);
        }
    }
}
