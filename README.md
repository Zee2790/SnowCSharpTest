# SnowCSharpTest

              
How to run the Program

    Front end 

Technology Used : Angular

go to Frontend folder :  cd frontend

if Node.js not install Plz install Node.js

Install Packages:   npm install

After sucessfully install packages 
Press this command :  ng serve   

and your client side run this port:  localhost:4200

and you go to browser and enter this command:  localhost:4200

and your browser is run start page


    Back end  

Technology Used : Asp.net Webapi

Go to backend folder install visual studio 2017 and after sucessfully install open this file CodingTest.sln

when project start see it solution Explorer right hand side right click SnowCSharpTest and go to this folder Manage NuGet Packages and you see it restore button click it and install all of the packages After Sucessfully install go to run button and check the result if browser not open sucessfully then you need 2 more packaged to install because we connection front end angular.

So go to press tool button from the top of the menu and then go to Nuget Package Manager and then Package Manager console you see it PM open :

and put this command
Install-Package Microsoft.AspNet.WebApi.Cors -verstion 5.2.3

and after sucessfully install and put this command

Update-Package Microsoft.AspNet.WebApi -reinstall

After sucessfully install packages go to run button and run the server 

Your server must run this port:

 http://localhost:54984/

and then go back to client side as run port

 http://localhost:4200/

choose file and upload the server 




