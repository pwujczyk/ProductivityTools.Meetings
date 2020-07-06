using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.Services.AutoMapper
{
    public class TreeProfile : Profile
    {
        public TreeProfile()
        {
            CreateMap<ProductivityTools.Meetings.Database.Objects.TreeNode, ProductivityTools.Meetings.CoreObjects.TreeNode>()
                .ReverseMap();
        }
    }
}
