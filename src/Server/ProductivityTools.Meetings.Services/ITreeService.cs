using ProductivityTools.Meetings.CoreObjects;
using System.Collections.Generic;

namespace ProductivityTools.Meetings.Services
{
    public interface ITreeService
    {
        List<TreeNode> GetTree();
        List<int> GetFlatChildsId(int parent);
    }
}