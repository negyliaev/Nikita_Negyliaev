using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WebAPI
{
    class Config
    {
        //Auth
        public static readonly string tokenType = "Bearer";
        public static readonly string token = "sl.BIl86fT_dkQgRQsM1FOoe0-S3nQ5xy7Yy_AZxBdXAMe0HG9xRR1mersfNjSr6bI14wU8tYHnUgFxWsLNKCROnGMtPC51KVhMV8EzseV4feyGrxSt_ZFTOSwKyoNkhDUA4NA-pTnunAif";

        //File
        public static readonly string fileName = "everest.jpg";
        public static readonly string dropboxFilePath = "/WebAPI/everest.jpg";
        public static readonly string dropboxFolderPath = "/WebAPI";
        public static readonly string localFilePath = "pictures/everest.jpg";


        //Upload
        public static readonly string uploadUrl = "https://content.dropboxapi.com/2/files/upload";
        public static readonly Dictionary<string, string> defaultUploadHeaders = new Dictionary<string, string>()
        {
            ["Dropbox-API-Arg"] = "{\"path\":\"" + dropboxFilePath + "\",\"mode\":\"add\"}",
            ["Content-Type"] = "application/octet-stream"
        };

        //GetFileMetadata
        public static readonly string getFileMetadataUrl = "https://api.dropboxapi.com/2/sharing/get_file_metadata";

        //DeleteFile
        public static readonly string deleteFileUrl = "https://api.dropboxapi.com/2/files/delete_v2";

        //ListFolder
        public static readonly string listFolderUrl = "https://api.dropboxapi.com/2/files/list_folder";
    }
}
