Run in command line description:
1) Change at Config.cs bearer token to yours. 
2) Open diretory at terminal or command line. 
3) Write "dotnet test" and press enter. 


Used Builder Design Pattern to build requests for each scenario (at RequestBuilder.cs). To build request RequestManager class at RequestManager.cs is used.


Updated:
1) UploadFile and DeleteFile tests are now checked by checking if file id is in folder by calling filelist request. 
2) Metadata response data is now checked with file name and path at dropbox. 
