using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RestSharp;

namespace WebAPI
{
    abstract class RequestBuilder
    {
        public abstract void SetBody(string filePath);
        public abstract void SetAuth(string tokenType, string token);
        public abstract void SetHeaders(Dictionary<string, string> headers);

        public abstract void SetDefaultHeaders();

        public abstract RestRequest GetRequest();
    }

    class UploadFile : RequestBuilder
    {
        public RestRequest Request = new RestRequest() ;

        public override void SetAuth(string tokenType, string token)
        {
            Request.AddHeader("Authorization", tokenType+" "+token);
        }

        public override void SetBody(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            long fileLength = fileInfo.Length;
            Request.AddHeader("Content-Length", fileLength.ToString());
            byte[] fileData = File.ReadAllBytes(filePath);
            var body = new Parameter("file", fileData, ParameterType.RequestBody);
            Request.Parameters.Add(body);

        }

        public override void SetHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
                Request.AddHeader(header.Key, header.Value);
        }

        public override void SetDefaultHeaders()
        {
            SetAuth(Config.tokenType, Config.token);
            SetHeaders(Config.defaultUploadHeaders);
        }

        public override RestRequest GetRequest()
        {
            return this.Request;
        }

        
    }

    class GetFileMetadata : RequestBuilder
    {
        public RestRequest Request = new RestRequest();

        public override void SetAuth(string tokenType, string token)
        {
            Request.AddHeader("Authorization", tokenType + " " + token);
        }

        public override void SetBody(string filePath)
        {
            Request.AddJsonBody(new { file = filePath });
        }

        public override void SetHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
                Request.AddHeader(header.Key, header.Value);
        }

        public override void SetDefaultHeaders()
        {
            SetAuth(Config.tokenType, Config.token);
        }

        public override RestRequest GetRequest()
        {
            return this.Request;
        }


    }

    class DeleteFile : RequestBuilder
    {
        public RestRequest Request = new RestRequest();

        public override void SetAuth(string tokenType, string token)
        {
            Request.AddHeader("Authorization", tokenType + " " + token);
        }

        public override void SetBody(string filePath)
        {
            Request.AddJsonBody(new { path = filePath });
        }

        public override void SetHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
                Request.AddHeader(header.Key, header.Value);
        }

        public override void SetDefaultHeaders()
        {
            SetAuth(Config.tokenType, Config.token);
        }

        public override RestRequest GetRequest()
        {
            return this.Request;
        }

    }



}