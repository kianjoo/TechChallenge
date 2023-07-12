# The Flight Plan project
Problem statement: 
Flights file a flight plan that specify a route that the pilot wishes to take between its departure and destination airports. The route is made up of waypoints and airways. We want to create a software that interrogates a few APIs, select a flight and display the associated flight route on a global map.

An additional task would be to find and propose alternate flight routes when a button is pressed and to display it accordingly. This additional task is an optional task and candidates need not complete this task. 


# Cloning the project
git clone 

# .Net Packages
Serilog packages used for logging
1. dotnet add package Serilog
2. dotnet add package Serilog.Settings.Configuration
3. dotnet add package Serilog.Sinks.Console
4. dotnet add package Serilog.Sinks.File
5. dotnet add package Microsoft.Extensions.Configuration

EntityFramework packages for Db
1. dotnet add package Microsoft.EntityFrameworkCore
2. dotnet add package Microsoft.EntityFrameworkCore.Design
3. dotnet add package Microsoft.EntityFrameworkCore.SqlServer

Json processing packages for Json messages
1. dotnet add package Newtonsoft.Json


# Containerizing release with Docker   
For this release, Docker must be installed and running for this sample to work. Additionally, only Linux-x64 containers are supported.
 
#add a reference to a (temporary) package that creates the container
1. dotnet add package Microsoft.NET.Build.Containers

#publish your project for linux-x64
2. dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer

#run your app using the new container
3. docker run -it --rm -p 4000:80 flightplanweb:1.0.0
