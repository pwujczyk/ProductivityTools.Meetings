﻿using ProductivityTools.Meetings.CoreObjects;
using System.Collections.Generic;

namespace ProductivityTools.Meetings.Services
{
    public interface ITreeService
    {
        List<TreeNode> GetTree();
        void AddTreeNode(int parentId, string name);
        List<int> GetFlatChildsId(int parent);
    }
}