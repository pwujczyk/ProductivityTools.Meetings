using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.WpfClient.Automapper
{
    class MeetingProfile:Profile
    {
        public MeetingProfile()
        {
            CreateMap<ProductivityTools.Meetings.CoreObjects.Meeting, ProductivityTools.Meetings.WpfClient.Meeting>();
        }
    }
}
