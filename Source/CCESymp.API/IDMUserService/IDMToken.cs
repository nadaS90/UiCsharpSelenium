using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Security;

namespace CCESymp.IDMServices.Services
{
    public class IDMToken
    {
        public static string Scopes { get; set; }
        /// <summary>
        /// Returns the IDM Acess token used to hit the IDM API
        /// </summary>
        public static string GetUserServiceToken() {
            Collection<String> ScopesCollection = new()
            {
                string.Format(Common.Common.IDMUserServiceScopes, Common.Common.IDMReferranceName)
            };
            IEnumerable<String> RequiredScopes = ScopesCollection;

            var TokenDetails = RequestToken(Common.Common.IDMAccessTokenURL,Common.Common.IDMUserServiceClientId, Common.Common.IDMAuthServiceClientSecret, RequiredScopes);
            return TokenDetails.AccessToken;
        }

        /// <summary>
        /// Returns the IDM Acess token used to hit the IDM API
        /// </summary>
        public static string GetAuthorizationServiceToken()
        {
            if (string.IsNullOrEmpty(Scopes))
                Scopes = Common.Common.IDMAuthServiceScopes;

            Collection<String> ScopesCollection = new()
            {
                string.Format(Scopes, "roles")
            };
            IEnumerable<String> RequiredScopes = ScopesCollection;
            var TokenDetails = RequestToken(Common.Common.IDMAccessTokenURL, Common.Common.IDMAuthServiceClientId, Common.Common.IDMAuthServiceClientSecret, RequiredScopes);
            return TokenDetails.AccessToken;
        }


        /// <summary>
        /// Request an access token
        /// </summary>
        /// <param name="AccessTokenURL"></param>
        /// <param name="_clientName"></param>
        /// <param name="_clientSecret"></param>
        /// <param name="inputRequestedScope"></param>
        /// <returns></returns>
        private static TokenResponse RequestToken(String AccessTokenURL, String _clientName, String _clientSecret, IEnumerable<String> inputRequestedScope)
        {
            try
            {
                
                Console.WriteLine(string.Format("Attempting to retrieve access token.\n TokenUrl: {0} \n ClientId: {1} \n Scopes: {2}", AccessTokenURL, _clientName, string.Join(", ", inputRequestedScope)));

                HttpClient client = new();

                IgnoreInvalidCert();
                var scopes = string.Join(" ", inputRequestedScope);

                var token = client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = AccessTokenURL,
                    ClientId = _clientName,
                    ClientSecret = _clientSecret,
                    Scope = scopes
                }).Result;

                if (token != null && token.IsError)
                {
                    if (token.HttpStatusCode == HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("Unable to access token url. Verify url is correct.");
                    }
                    else
                    {
                        Console.WriteLine(string.Format("The token contains an error. Issue: {0}", token.Error ?? token.HttpErrorReason));
                    }
                }
                else if (token != null && !token.IsError)
                {
                    Console.WriteLine("Successfuly retrieved token.");
                }

                return token;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("There was an exception when attempting to request a token: {0}", ex.Message));

                if (ex.InnerException != null)
                {
                    Console.WriteLine(string.Format("InnerException: {0}", ex.InnerException.Message));
                    if (ex.InnerException.InnerException != null)
                    {
                        Console.WriteLine(string.Format("InnerInnerException: {0}", ex.InnerException.InnerException.Message));
                    }
                }
            }
            return null;
        }

        protected static void IgnoreInvalidCert()
        {
            ///This allows us to ignore server verification since the VM's cannot establish a trusted connection.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
        }
    }
}
