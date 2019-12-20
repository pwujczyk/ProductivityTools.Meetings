﻿using ProductivityTools.Meetings.CoreObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductivityTools.Meetings.ClientCaller
{
    public class MeetingsClient
    {
        SimpleHttpPostClient.HttpPostClient HttpPostClient;

        public MeetingsClient()
        {
            this.HttpPostClient = new SimpleHttpPostClient.HttpPostClient();
            this.HttpPostClient.SetBaseUrl("https://localhost:44366/api");
            this.HttpPostClient.EnableLogging();
        }

        public async Task<List<Meeting>> GetMeetings()
        {
            var r= this.HttpPostClient.Post<List<Meeting>>(Consts.MeetingControllerName, Consts.ListName);
            return await r;
            
        }
    }
}