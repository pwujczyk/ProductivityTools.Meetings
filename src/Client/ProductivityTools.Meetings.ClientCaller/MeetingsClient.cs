using IdentityModel.Client;
using ProductivityTools.Meetings.CoreObjects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductivityTools.Meetings.ClientCaller
{
    public class MeetingsClient
    {
        SimpleHttpPostClient.HttpPostClient HttpPostClient;
        string Secret;

        private string token;
        private string Token
        {
            get
            {
                if (string.IsNullOrEmpty(token))
                {//code to be rewritten, mising asyncs and others, but it needs to start working
                    ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

                    var client = new HttpClient();

                    var disco = client.GetDiscoveryDocumentAsync("https://identityserver.productivitytools.tech:8084/").Result;
                    if (disco.IsError)
                    {
                        Console.WriteLine(disco.Error);
                    }

                    var tokenResponse = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                    {
                        Address = disco.TokenEndpoint,

                        ClientId = "WPFApplication",
                        ClientSecret = "secret",
                        Scope = "ProductivityTools.Meetings.API"
                    }).Result;

                    if (tokenResponse.IsError)
                    {
                        Console.WriteLine(tokenResponse.Error);

                    }

                    Console.WriteLine(tokenResponse.Json);

                    token = tokenResponse.AccessToken;

                    //// call api
                    //var apiClient = new HttpClient();
                    //apiClient.SetBearerToken(tokenResponse.AccessToken);

                    //var response = apiClient.GetAsync("http://localhost:7001/Identity/Paid").Result;
                    //if (!response.IsSuccessStatusCode)
                    //{
                    //    Console.WriteLine(response.StatusCode);
                    //}
                    //else
                    //{
                    //    var content = response.Content.ReadAsStringAsync().Result;
                    //    Console.WriteLine(content);
                    //}
                }
                return token;
            }
        }

        public void RenewTokens()
        {
            var disco = await DiscoveryClient.GetAsync(Constants.Authority);
            if (disco.IsError) throw new Exception(disco.Error);

            var tokenClient = new TokenClient(disco.TokenEndpoint, "mvc.hybrid", "secret");
            var rt = await HttpContext.Authentication.GetTokenAsync("refresh_token");
            var tokenResult = await tokenClient.RequestRefreshTokenAsync(rt);

            if (!tokenResult.IsError)
            {
                var old_id_token = await HttpContext.Authentication.GetTokenAsync("id_token");
                var new_access_token = tokenResult.AccessToken;
                var new_refresh_token = tokenResult.RefreshToken;

                var tokens = new List<AuthenticationToken>();
                tokens.Add(new AuthenticationToken { Name = OpenIdConnectParameterNames.IdToken, Value = old_id_token });
                tokens.Add(new AuthenticationToken { Name = OpenIdConnectParameterNames.AccessToken, Value = new_access_token });
                tokens.Add(new AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value = new_refresh_token });

                var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResult.ExpiresIn);
                tokens.Add(new AuthenticationToken { Name = "expires_at", Value = expiresAt.ToString("o", CultureInfo.InvariantCulture) });

                var info = await HttpContext.Authentication.GetAuthenticateInfoAsync("Cookies");
                info.Properties.StoreTokens(tokens);
                await HttpContext.Authentication.SignInAsync("Cookies", info.Principal, info.Properties);

                return Redirect("~/Home/Secure");
            }

            ViewData["Error"] = tokenResult.Error;
            return View("Error");
        }

        public MeetingsClient(string secret)
        {
            this.Secret = secret;
            this.HttpPostClient = new SimpleHttpPostClient.HttpPostClient(true);

            // this.HttpPostClient.SetBaseUrl("https://localhost:44366/api");//iis

            //this.HttpPostClient.SetBaseUrl("http://localhost:5002/api");//vs

            //this.HttpPostClient.SetBaseUrl("https://productivitytools.tech:443/api");
            this.HttpPostClient.SetBaseUrl("https://meetings.productivitytools.tech:8081/api");
            //this.HttpPostClient.SetBaseUrl("http://192.168.1.51:8081/api");
            this.HttpPostClient.HttpClient.SetBearerToken(Token);

        }

        public async Task<List<Meeting>> GetMeetings(int? treeNodeId = null, bool drillDown = true)
        {
            var r = this.HttpPostClient.PostAsync<List<Meeting>>(Consts.MeetingControllerName, Consts.ListName, new MeetingListRequest() { Id = treeNodeId, DrillDown = drillDown });
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

        public async Task DeleteMeeting(MeetingId meetingId)
        {
            await this.HttpPostClient.PostAsync<object>(Consts.MeetingControllerName, Consts.DeleteMeetingName, meetingId);
        }

        public async Task<List<TreeNode>> GetTree()
        {
            var r = await this.HttpPostClient.PostAsync<List<TreeNode>>(Consts.TreeControllerName, Consts.TreeControlerGet);
            return r;
        }

        public async Task<object> NewTreeNode(int parentTreeId, string name)
        {
            var r = await this.HttpPostClient.PostAsync<object>(Consts.TreeControllerName, Consts.TreeControlerNewNode, new NewTreeNodeRequest(parentTreeId, name));
            return r;
        }

    }
}
