using ProductivityTools.Meetings.CoreObjects;
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
            this.HttpPostClient.SetBaseUrl(" https://localhost:44366/api");//iis
       
            //this.HttpPostClient.SetBaseUrl("http://localhost:101/api");//iis
            //this.HttpPostClient.SetBaseUrl("https://productivitytools.tech:443/api");
            //this.HttpPostClient.SetBaseUrl("http://productivitytools.tech:8081/api");

            this.HttpPostClient.EnableLogging();
        }

        public async Task<List<Meeting>> GetMeetings()
        {
            var r= this.HttpPostClient.Post<List<Meeting>>(Consts.MeetingControllerName, Consts.ListName);
            return await r;
        }

        public async Task UpdateMeeting(Meeting meeting)
        {
            await this.HttpPostClient.Post<Meeting>(Consts.MeetingControllerName, Consts.UpdateMeetingName, meeting);
        }

        public async Task SaveMeeting(Meeting meeting)
        {
            await this.HttpPostClient.Post<Meeting>(Consts.MeetingControllerName, Consts.AddMeetingName, meeting);
        }
    }
}
