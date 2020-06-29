using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.Database.Objects
{
    public class Tree
    {
        public int TreeId { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }

        public Tree Parent { get; set; }
    }
}
