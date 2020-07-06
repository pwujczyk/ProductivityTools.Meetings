using ProductivityTools.Meetings.Database;
using ProductivityTools.Meetings.Database.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProducvitityTools.Meetings.Queries
{
    public interface ITreeQueries
    {
        List<TreeNode> GetTree();
    }

    class TreeQueries: ITreeQueries
    {
        MeetingContext MeetingContext;

        public TreeQueries(MeetingContext context)
        {
            this.MeetingContext = context;
        }

        public List<TreeNode> GetTree()
        {
            throw new Exception();
            //var result = this.MeetingContext..OrderByDescending(x => x.Date).ToList();
            //return result;
        }

      
    }
}
