Run in command line description:
1) Open diretory at terminal or command line.
2) Write "dotnet test" and press enter..


Used PageObject Design Pattern and made four steps of Scenario, one step for each page.


Fixes: 
1) Changed driver path to Path.GetFullPath("driver")
2) Added [OneTimeTearDownAttribute] annotation
3) Renamed Scenario and Scenario steps
4) Replaced driver setups to Setup
5) Added implicit and explicit waits
6) Changed all absolute Xpathes to relative ones
7) Mage parent class BasePage with constructor
8) Made UserStorage an OrderEntity classes
9) Renamed methods to big first letter
10) Updated result check adding check of popup text and data 
