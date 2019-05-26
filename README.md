# moviedatabase
# Database
An empty database called dbMovies needs to be created

Script.sql in the Database folder can then be run to create the database

All data extraction is done via code, not stored procedures, etc

Connection strings need to be set in appsettings.json file (perform search for MovieDatabaseDb)

Database is SQL Server 2016

# General Overview
Visual Studio 2017 was used for solution along with .NET Core 2.2

System uses Autofac to resolve services.  Assemblies are scanned and the modules loaded automatically.  
Fody.LoadAssembliesOnStartup is used to ensure that assemblies are loaded where relevant when looking for the AutoFac modules to be loaded

Automapper is used for Mapping objects

Business logic is inside services rather than controllers.  This approach avoids business logic being tied into the API allowing the code to be reused in other systems

Clients hide all the logic from the caller for interacting with the API which makes mistakes less likely.  Tests cover the functionality.  Clients all inherit from WebApiClient that deals with post and get, and also raising exceptions if response from the API is an error code

EF Core has been used - Code first

DataSeeder has been used to provide the data for the system

Controllers have been created for each Api, these call the relevant service

Seperating the database and business logic from the controllers is a more flexible approach, and changes would be needed in fewer places if, for example, the database engine was changed.  

This layout/principle is my preferred way for implementing software as it allows a better seperation of concerns.  I see Web Api as a host, hence why the host doesnt contain business logic

Post is used for searching.  Get is used for simple method calling, and for Adding/Updating ratings 

# Running System
Load solution and run ensuring Web Api is the start up project.  A browser is NOT loaded.

The root is http://localhost:51286 

The system can be tested either by looking at/running the Api Client tests or using PostMan

# Tests

Several tests have been implemented to test functionality.  Some of these may only work once due to them changing data (only 1 or 2)

Tests can be run either via Test Explorer in Visual Studio or via Resharper

# Solution Structure

1 Shared - Contains common code used throughout the system, mainly helpers, models and extensions

2 Database - Contains assembly that holds the database model - EF Core Code First

3 Services - Contains the 2 services that contain the business logic, along with a test assembly

4 Web Api - Contains web Api host, Web Api clients and test projects
