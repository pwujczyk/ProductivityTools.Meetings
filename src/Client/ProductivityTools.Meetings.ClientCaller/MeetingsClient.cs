using ProductivityTools.Meetings.CoreObjects;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductivityTools.Meetings.ClientCaller
{
    public class MeetingsClient
    {
        SimpleHttpPostClient.HttpPostClient HttpPostClient;
        string Secret;

        public MeetingsClient(string secret)
        {
            this.Secret = secret;
            this.HttpPostClient = new SimpleHttpPostClient.HttpPostClient(true);
            
           // this.HttpPostClient.SetBaseUrl("https://localhost:44366/api");//iis

            this.HttpPostClient.SetBaseUrl("https://localhost:5001/api");//vs

            //this.HttpPostClient.SetBaseUrl("https://productivitytools.tech:443/api");
           // this.HttpPostClient.SetBaseUrl("http://productivitytools.tech:8081/api");
            //this.HttpPostClient.SetBaseUrl("http://192.168.1.51:8081/api");
            this.HttpPostClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ClientCredentials.AccessToken);

        }

        public async Task<List<Meeting>> GetMeetings()
        {
            var r = this.HttpPostClient.PostAsync<List<Meeting>>(Consts.MeetingControllerName, Consts.ListName, Secret ?? "");
            return await r;
        }

        public async Task UpdateMeeting(Meeting meeting)
        {
            await this.HttpPostClient.PostAsync<Meeting>(Consts.MeetingControllerName, Consts.UpdateMeetingName, meeting);
        }

        public async Task SaveMeeting(Meeting meeting)
        {
            await this.HttpPostClient.PostAsync<Meeting>(Consts.MeetingControllerName, Consts.AddMeetingName, meeting);
        }
    }
}
