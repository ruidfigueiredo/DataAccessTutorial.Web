# Cross platform database walk-through using ASP.NET MVC and Entity Framework Core

This project is an example of how you can use SQLite, MySQL and PostgreSQL with ASP.NET and Entity Framework Core.

The master branch uses SQLite without migrations. It will generate the database if run in environment mode:

    $ dotnet restore
    $ dotnet run --environment "Development"

There are three branches

 - SqLite
   - SQLite using migrations
 - Mysql 
   - MySQL without migrations (run with enviroment set to Development to generate have the database be generated automatically)
 - Postgres
   - PostgreSQL with migrations

Read the tutorial here: [http://www.blinkingcaret.com/2016/11/02/cross-platform-database-walk-through-using-asp-net-mvc-and-entity-framework-core/](http://www.blinkingcaret.com/2016/11/02/cross-platform-database-walk-through-using-asp-net-mvc-and-entity-framework-core/) 
