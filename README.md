booksmart
=========

Personal learning project using .NET Core MVC Web app to manage Books and Authors

Repo:
https://github.com/imran-uk/booksmart

following this but suing "Books" entity
https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/?view=aspnetcore-2.2

Using MySQL, decided to use MariaDB which I installed here
https://mariadb.org/

just choose msi installer on Windows

i got latest GA on 10.4 series 64-bit arch

`mariadb-10.4.7-winx64.msi`

commandz n shiz

    mkdir /c/code/booksmart
    git clone https://github.com/imran-uk/booksmart.git

created gitignore

    vim .gitignore
    git st
    git add .gitignore
    git st
    git commit -m"add gitignore"

i'm using v2.2

    dotnet --version

use webapp template

    dotnet new webapp

with Visual Studio code

    code .

code should auto-update and restore, you might want to hity ctrl+f5 to build n run dat mofo first

do dis for good measure (maybe)

    dotnet restore

create HTTPS certs

    dotnet dev-certs https --trust

to make use of the EF magic, we need a few packages

    dotnet add package MySql.Data.EntityFrameworkCore
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.EntityFrameworkCore.Design

ensure the MySQL connection string is here

    cat appsettings.json

install dis tool

    dotnet tool install --global dotnet-aspnet-codegenerator

lets use aspnet-codegenerator tool... to auto-generate the scaffolding shiz

    dotnet aspnet-codegenerator razorpage -m Book -dc BookSmartBookContext -udl -outDir Pages/Book --referenceScriptLibraries

now lets create the files which contain code to create tables we need

    dotnet ef migrations add InitialCreate

...and now create the tables in MySQL

    dotnet ef database update

it don't work, wtf? lets verbose dat mofo

    dotnet ef -v database update

might be due to MySQL connector not supporting migrations yet, lets manually generate the SQL script

    dotnet ef migrations script


at this point i had to copy-pasta the generated SQL and run against the database manually (had to munge it a bit too)

    CREATE TABLE `__EFMigrationsHistory` (
        `MigrationId` varchar(150) NOT NULL,
        `ProductVersion` varchar(32) NOT NULL,
        PRIMARY KEY (`MigrationId`)
    );

    CREATE TABLE `Book` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Title` text NULL,
        `ReleaseDate` datetime NOT NULL,
        PRIMARY KEY (`Id`)
    );

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20190809132302_InitialCreate', '2.2.6-servicing-10079');


now start the app, you should be able to do CRUD operations on books

https://localhost:5001/Book



---




    IF EXISTS(SELECT 1 FROM information_schema.tables
      WHERE table_name = '
    __EFMigrationsHistory' AND table_schema = DATABASE())
    BEGIN
    CREATE TABLE `__EFMigrationsHistory` (
        `MigrationId` varchar(150) NOT NULL,
        `ProductVersion` varchar(32) NOT NULL,
        PRIMARY KEY (`MigrationId`)
    );

    END;


## TODO

* add support for Author



* wire-up Authors to Books

a book can have 1 or more Authors
an Author can be author of 0 or more Books


* how to use MySQL client from GitBash and with history and autocomplete of table names


* create MySQL database non-root user

remember to update settings file