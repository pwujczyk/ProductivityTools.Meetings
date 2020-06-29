using ProductivityTools.Meetings.Database;
using ProductivityTools.Meetings.Database.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProducvitityTools.Meetings.Queries
{
    class TreeQueries
    {
        MeetingContext MeetingContext;

        public TreeQueries(MeetingContext context)
        {
            this.MeetingContext = context;
        }

        public List<TreeNode> GetTree()
        {
            var result = this.MeetingContext..OrderByDescending(x => x.Date).ToList();
            return result;
        }

        public void GetTree()
        {

        }
    }
}
