using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace WebAPI
{


    class RequestManager
    {
        public RequestBuilder builder;
        public RequestManager(RequestBuilder builder)
        {
            this.builder = builder;
        }
        public RestRequest BuildDefault(string body)
        {
            builder.SetBody(body);
            builder.SetDefaultHeaders();
            return builder.GetRequest();
        }

        public RestRequest Build(string body, Dictionary<string, string> headers)
        {
            builder.SetAuth(Config.tokenType, Config.token);
            builder.SetBody(body);
            builder.SetHeaders(headers);
            return builder.GetRequest();
        }
    }
}
