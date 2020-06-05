using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.CoreObjects
{
    public class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> Nodes { get; set; }

        public TreeNode(string name)
        {
            this.Name = name;
            this.Nodes = new List<TreeNode>();
        }
    }
}
