using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.CoreObjects
{
    public class TreeNode
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public List<TreeNode> Nodes { get; set; }

        public TreeNode(string name)
        {
            this.Value = name;
            this.Nodes = new List<TreeNode>();
        }
    }
}
