using AutoMapper;
using ProductivityTools.Meetings.CoreObjects;
using ProducvitityTools.Meetings.Commands;
using ProducvitityTools.Meetings.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductivityTools.Meetings.Services
{
    class MeetingService : IMeetingService
    {
        IMeetingQueries MeetingQueries;
        IMeetingCommands MeetingCommand;
        ITreeService TreeService;
        readonly IMapper Mapper;

        public MeetingService(IMeetingQueries meetingQueries, IMeetingCommands meetingCommands, ITreeService treeService, IMapper mapper)
        {
            this.MeetingQueries = meetingQueries;
            this.TreeService = treeService;
            this.MeetingCommand = meetingCommands;
            this.Mapper = mapper;
        }

        public List<Meeting> GetMeetings(int? treeNodeId)
        {
            if (treeNodeId.HasValue)
            {
                return GetMeetingsInternal(treeNodeId.Value);

            }
            else
            {
                return this.Mapper.Map<List<Meeting>>(this.MeetingQueries.GetMeetings());
            }
        }

        public List<Meeting> GetMeetingsInternal(int treeNodeId)
        {
            var trees = this.TreeService.GetFlatChildsId(treeNodeId);
            trees.Add(treeNodeId);
            //var result = new List<Meeting>();
            var dbResult = this.MeetingQueries.GetMeetings(trees).ToList();
            var result = this.Mapper.Map<List<Meeting>>(dbResult);
            return result;
        }

        public void DeleteMeeting(int meetingId)
        {
            var meeting=this.MeetingQueries.GetMeeting(meetingId);
            this.MeetingCommand.Delete(meeting);
        }
    }
}
