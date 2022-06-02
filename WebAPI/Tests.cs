using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
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


        private string GetFileId(string response)
        {
            string fileId = null;

            foreach (var parameter in response.Split(','))
            {
                if (parameter.Contains("id"))
                {
                    fileId = parameter.Split(" ")[2];
                    break;
                }
            }

            return fileId;
        }

        private List<string> GetFolderFilesIds()
        {
            string response = SendDefaultRequest(Config.listFolderUrl, new FolderList(), Config.dropboxFolderPath).Content;
            List<string> fileIds = new List<string>();

            foreach (var parameter in response.Split(','))
            {
                if (parameter.Contains("id"))
                {
                    fileIds.Add(parameter.Split(" ")[2]);
                    break;
                }
            }

            return fileIds;
        }

        private bool CheckFileMetadata(string response)
        {
            bool result = true;

            string nameParameter = " \"name\": " + "\"" + Config.fileName + "\"";
            string folderParameter = " \"path_display\": " + "\"" + Config.dropboxFilePath + "\"";

            foreach (var parameter in response.Split(","))
            {
                if (parameter.Contains("\"name\""))
                    if (parameter != nameParameter)
                        result = false;

                if (parameter.Contains("\"path_display\""))
                    if (parameter != folderParameter)
                        result = false;
            }
            return result;
        }



        [Test, Order(1)]
        public void UploadScenario()
        {
            string uploadResponse = SendDefaultRequest(Config.uploadUrl, new UploadFile(), Config.localFilePath).Content;
            string fileId = GetFileId(uploadResponse);

            if (fileId == null)
                Assert.Fail();

            Assert.IsTrue(GetFolderFilesIds().Contains(fileId));
        }

        [Test, Order(2)]
        public void GetFileMetadataScenario()
        {
            Assert.IsTrue(CheckFileMetadata(SendDefaultRequest(Config.getFileMetadataUrl, new GetFileMetadata(), Config.dropboxFilePath).Content));
        } 

        [Test, Order(3)]
        public void DeleteScenario()
        {
            string deleteResponse = SendDefaultRequest(Config.deleteFileUrl, new DeleteFile(), Config.dropboxFilePath).Content;
            string fileId = GetFileId(deleteResponse);

            if (fileId == null)
                Assert.Fail();

            Assert.IsFalse(GetFolderFilesIds().Contains(fileId));
        }
    }
}