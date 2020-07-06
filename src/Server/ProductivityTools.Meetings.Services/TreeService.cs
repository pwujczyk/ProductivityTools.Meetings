using AutoMapper;
using ProductivityTools.Meetings.CoreObjects;
using ProducvitityTools.Meetings.Queries;
using System;
using System.Collections.Generic;

namespace ProductivityTools.Meetings.Services
{
    public class TreeService : ITreeService
    {
        readonly ITreeQueries TreeQueries;
        readonly IMapper Mapper;

        public TreeService(ITreeQueries treeQueries, IMapper mapper)
        {
            this.TreeQueries = treeQueries;
            this.Mapper = mapper;
        }

        private List<TreeNode> GetNodes(int parent)
        {
            List<TreeNode> result = new List<TreeNode>();
            var dbTreeNodes = this.TreeQueries.GetTree(parent);
            foreach (var dbTreeNode in dbTreeNodes)
            {
                TreeNode treeNode = this.Mapper.Map<TreeNode>(dbTreeNode);
                treeNode.Nodes = GetNodes(dbTreeNode.TreeId);
                result.Add(treeNode);
            }
            return result;
        }

        public List<TreeNode> GetTree()
        {
            var rootdb = TreeQueries.GetRoot();
            TreeNode root = Mapper.Map<TreeNode>(rootdb);
            List<TreeNode> result = GetNodes(rootdb.TreeId);
            return result;
        }
    }
}
