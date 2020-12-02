# CLI commands

# Create web api app
First we create the project
>`dotnet` new webapi -n NameOfYourProject
  
Then we enter the project folder
>`code` r- NameOfYourProject
    


# Install entity framework
>`dotnet` add package Microsoft.EntityframeworkCore (in this the version is not specified, so it will download the lastest one)
  
>`dotnet` add package Microsoft.EntityFrameworkCore.Design
 
>`dotnet` add package Microsoft.EntityFrameworkCore.SqlServer

In case of error:  
>`dotnet` tool install --global dotnet-ef

# EF migrations
>`dotnet` ef migrations add InitialMigration

Apply migration to database 
>`dotnet` ef database update
undo migration:
>`dotnet` ef migrations remove