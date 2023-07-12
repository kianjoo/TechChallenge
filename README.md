# The Flight Plan project
Problem statement: 
Flights file a flight plan that specify a route that the pilot wishes to take between its departure and destination airports. The route is made up of waypoints and airways. We want to create a software that interrogates a few APIs, select a flight and display the associated flight route on a global map.

An additional task would be to find and propose alternate flight routes when a button is pressed and to display it accordingly. This additional task is an optional task and candidates need not complete this task. 

# APIs
flight-manager/displayAll
geopoints/list/airways
geopoints/list/fixes
geopoints/list/airports

An API Key is required, else you can connect locally through the FlightPlanAPI project   

# Cloning the project
git clone https://github.com/kianjoo/techchallenge

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

Leaflet map with OpenStreetMap tiles is used for the flight plan routing, working with markers, polylines and popups, and dealing with events.
- https://leafletjs.com/reference.html

# Containerizing release with Docker   
For this release, Docker must be installed and running for this sample to work. Additionally, only Linux-x64 containers are supported.

1. dotnet add package Microsoft.NET.Build.Containers
2. dotnet publish --os linux --arch x64 -c Release -p:PublishProfile=DefaultContainer
   ![image](https://github.com/kianjoo/TechChallenge/assets/101357464/03e41e64-7ba1-42ed-9728-4a297363aa36)
  Take note of the container name
3. docker run -it --rm -p 6000:80 flightplanweb:1.0.0
