using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace WebAPI
{
    [TestFixture]
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        private IRestResponse SendDefaultRequest(string url, RequestBuilder builder, string body)
        {
            var client = new RestClient(url);
            RequestManager requestManager = new RequestManager(builder);
            var request = requestManager.BuildDefault(body);

            return client.Post(request);
        }


        [Test, Order(1)]
        public void UploadScenario()
        {
            Assert.AreEqual(HttpStatusCode.OK, SendDefaultRequest(Config.uploadUrl, new UploadFile(), Config.localFilePath).StatusCode);
        }

        [Test, Order(2)]
        public void GetFileMetadataScenario()
        {
            Assert.AreEqual(HttpStatusCode.OK, SendDefaultRequest(Config.getFileMetadataUrl, new GetFileMetadata(), Config.dropboxFilePath).StatusCode);
        } 

        [Test, Order(3)]
        public void DeleteScenario()
        {
            Assert.AreEqual(HttpStatusCode.OK, SendDefaultRequest(Config.deleteFileUrl, new DeleteFile(), Config.dropboxFilePath).StatusCode);
        }
    }
}