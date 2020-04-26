using Auth0.OidcClient;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using ProductivityTools.Meetings.ClientCaller;
using ProductivityTools.Meetings.WpfClient.Automapper;
using ProductivityTools.Meetings.WpfClient.Controls;
using ProductivityTools.Meetings.WpfClient.Controls.MeetingItem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ProductivityTools.Meetings.WpfClient
{
    public class MeetingsVM
    {
        public ObservableCollection<MeetingItemVM> Meetings { get; set; }

        public ICommand GetMeetingsCommand { get; }
        public ICommand NewMeetingCommand { get; }
        public ICommand LoginCommand { get; }
        public string Secret { get; set; }


        public MeetingsVM()
        {
            this.Meetings = new ObservableCollection<MeetingItemVM>();
            GetMeetingsCommand = new CommandHandler(GetMeetings, () => true);
            NewMeetingCommand = new CommandHandler(NewMeeting, () => true);
            LoginCommand = new CommandHandler(LoginClick, () => true);
            this.Meetings.Add(new MeetingItemVM(new CoreObjects.Meeting() { AfterNotes = "Core", BeforeNotes = "Core", DuringNotes = "Core", Subject = "fdsa" }));
            this.Meetings.Add(new MeetingItemVM(new CoreObjects.Meeting() { AfterNotes = "Core", BeforeNotes = "Core", DuringNotes = "Core" }));
        }

        private async void GetMeetings()
        {
            MeetingsClient client = new MeetingsClient(this.Secret);
            var xx = await client.GetMeetings();
            // await client.SaveMeeting(new CoreObjects.Meeting() { AfterNotes = "after" });
            this.Meetings.Clear();
            foreach (var item in xx)
            {
                var meeting = new MeetingItemVM(item);
                this.Meetings.Add(meeting);
            }
        }

        private void NewMeeting()
        {
            var meeting = new CoreObjects.Meeting();
            var meetingvm = new MeetingItemVM(meeting);
            this.Meetings.Add(meetingvm);
            EditMeeting edit = new EditMeeting(meeting);
            edit.Show();

        }

        private Auth0Client client;
        private async void LoginClick()
        {

            string domain = @"productivitytools-meeting-dev.eu.auth0.com";
            string clientId = "0ygl3UMljGseor6wYLAHlDPWSaoSB6gv";

            client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = domain,
                ClientId = clientId
            });

            var extraParameters = new Dictionary<string, string>();

            //if (!string.IsNullOrEmpty(connectionNameComboBox.Text))
            extraParameters.Add("connection", "google-oauth2");

            //if (!string.IsNullOrEmpty(audienceTextBox.Text))
            //    extraParameters.Add("audience", audienceTextBox.Text);

            DisplayResult(await client.LoginAsync(extraParameters: extraParameters));
        }

        private void DisplayResult(LoginResult loginResult)
        {
            ClientCredentials.SetCredentials(loginResult.IdentityToken, loginResult.AccessToken);
            //// Display error
            //if (loginResult.IsError)
            //{
            //    resultTextBox.Text = loginResult.Error;
            //    return;
            //}

            //logoutButton.Visibility = Visibility.Visible;
            //loginButton.Visibility = Visibility.Collapsed;

            // Display result
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Tokens");
            sb.AppendLine("------");
            sb.AppendLine($"id_token: {loginResult.IdentityToken}");
            sb.AppendLine($"access_token: {loginResult.AccessToken}");
            sb.AppendLine($"refresh_token: {loginResult.RefreshToken}");
            sb.AppendLine();

            sb.AppendLine("Claims");
            sb.AppendLine("------");
            foreach (var claim in loginResult.User.Claims)
            {
                sb.AppendLine($"{claim.Type}: {claim.Value}");
            }

          //  resultTextBox.Text = sb.ToString();
        }
    }
}
