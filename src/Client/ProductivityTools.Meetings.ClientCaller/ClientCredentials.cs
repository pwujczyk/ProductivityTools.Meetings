using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.Meetings.ClientCaller
{
    public static class ClientCredentials
    {

        internal static string IdToken { get; private set; }
        internal static string AccessToken { get; private set; }


        public static void SetCredentials(string idToken, string accessToken)
        {
            IdToken = idToken;
            AccessToken = accessToken;
        }
    }
}
