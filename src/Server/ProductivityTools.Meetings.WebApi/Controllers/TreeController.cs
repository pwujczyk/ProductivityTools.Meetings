using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Meetings.CoreObjects;

namespace ProductivityTools.Meetings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        [HttpPost]
        [Route("Get")]
        public List<TreeNode> GetTree()
        {
            List<TreeNode> result = new List<TreeNode>();
            result.Add(new TreeNode("EcoVadis"));
            result[0].Nodes = new List<TreeNode>();
            result[0].Nodes.Add(new TreeNode("DevSteering"));
            result.Add(new TreeNode("Pawel"));
            return result;
        }
    }
}