using AutoMapper;
using ProductivityTools.Meetings.CoreObjects;
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
        readonly IMapper Mapper;

        public MeetingService(IMeetingQueries meetingQueries, IMapper mapper)
        {
            this.MeetingQueries = meetingQueries;
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
            var result = new List<Meeting>();
            var dbResult = this.MeetingQueries.GetMeetings(treeNodeId).ToList();
            var partResult = this.Mapper.Map<List<Meeting>>(dbResult);
            result.AddRange(partResult);

            List<int> parents = partResult.Where(x => x.MeetingId.HasValue).Select(x => x.MeetingId.Value).ToList<int>();

            foreach (int i in parents)
            {
                var childs = GetMeetingsInternal(i);
                result.AddRange(childs);
            }

            return result;
        }
    }
}
