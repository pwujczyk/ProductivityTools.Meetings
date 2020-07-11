using ProductivityTools.Meetings.CoreObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.WpfClient.Controls
{
    public class EditTreeNodeVM
    {
        private TreeNode ParentTreeNode;

        public EditTreeNodeVM(TreeNode treeNode)
        {
            this.ParentTreeNode = treeNode; 
        }
    }
}
