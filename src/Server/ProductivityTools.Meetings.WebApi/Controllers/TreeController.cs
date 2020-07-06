using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Meetings.CoreObjects;
using ProductivityTools.Meetings.Services;
using ProducvitityTools.Meetings.Queries;

namespace ProductivityTools.Meetings.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        readonly IMapper Mapper;
        readonly  ITreeService TreeServices;

        public TreeController(ITreeService treeService, IMapper mapper)
        {
            this.TreeServices = treeService;
            this.Mapper = mapper;
        }

        [HttpPost]
        [Route("Get")]
        public List<TreeNode> GetTree()
        {
         //   List<TreeNode> result = new List<TreeNode>();
            //result.Add(new TreeNode("EcoVadis"));
            //result[0].Nodes = new List<TreeNode>();
            //result[0].Nodes.Add(new TreeNode("DevSteering"));
            //result.Add(new TreeNode("Pawel"));
            var result = TreeServices.GetTree();
         

            return result;
        }
    }
}