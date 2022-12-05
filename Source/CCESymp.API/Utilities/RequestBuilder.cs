using BD.Automation.Core.Drivers.Interface;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;

namespace CCESymp.API
{
    public class RequestBuilder : TestBase
    {

        public RequestBuilder(IDriver _webDriver)
        {
            this._webDriver = _webDriver;
        }

        //CHANGED VARIABLE TO METHOD TO BE ABLE TO CHANGE THE BASE URL AS NEEDED ACROSS THE TEST METHODS
        public static string BaseUrl(string url = "")
        {
            var urlData = url;
            if (string.IsNullOrEmpty(urlData))
            {
                urlData = Common.Common.CCESymp_Postman_Echo_Url;
            }
            return urlData;
        }

        public string GetAuthorizationToken()
        {
            if (Common.Common.UserTypeToken.Equals("Admin"))
            {
                return Common.Common.AdminAPIAccessToken;
            }
            else
            {
                return Common.Common.UserAPIAccessToken;
            }
        }

        public IRestResponse GetResponse(string url, Method requestMethod, Object model = null)
        {
            var client = new RestClient(BaseUrl());
            var request = new RestRequest(url, requestMethod);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            request.AddHeader("Authorization", string.Format("Bearer {0}", GetAuthorizationToken()));
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            request.RequestFormat = DataFormat.Json;

            if (requestMethod == Method.POST || requestMethod == Method.DELETE || requestMethod == Method.PUT || requestMethod == Method.PATCH)
            {
                request.AddJsonBody(model);
            }
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse GetResponse(string url, Method requestMethod, Dictionary<string, string> additionalHeader, Object model = null)
        {
            var client = new RestClient(BaseUrl());
            var request = new RestRequest(url, requestMethod);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            request.AddHeader("Authorization", string.Format("Bearer {0}", GetAuthorizationToken()));
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            foreach (string key in additionalHeader.Keys)
            {
                request.AddHeader(key, additionalHeader[key]);
            }

            request.RequestFormat = DataFormat.Json;
            if (requestMethod == Method.POST || requestMethod == Method.DELETE || requestMethod == Method.PUT || requestMethod == Method.PATCH)
            {
                request.AddJsonBody(model);
            }
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse GetResponseHealthCheck(string endpointUrl, Method requestMethod)
        {
            RestClient client = new RestClient(BaseUrl());
            RestRequest request = new RestRequest(endpointUrl, requestMethod);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
