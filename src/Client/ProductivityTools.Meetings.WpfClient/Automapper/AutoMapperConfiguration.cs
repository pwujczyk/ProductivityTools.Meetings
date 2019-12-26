using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.WpfClient.Automapper
{
    class AutoMapperConfiguration
    {
        public static IMapper Configuration;

        static AutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MeetingProfile>();
            });

            Configuration = config.CreateMapper();
        }
    }
}
