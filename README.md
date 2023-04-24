# Loans Website

Website back-end is created using ASP.NET Core Web API in .NET 7
ClientApp is created using Sencha ExtJS (Client app is not fully functional edit page is not working)

## How to run

- Update connection string named 'DefaultConnection' in src/Host/appsettings.json file
- When you run the back-end, database is automatically created and seeded with admin user.
    - username: admin
    - password: Admin123
- You can test the app using postman. Postman collection is inside docs/Gigiz Loans.postman_collection.json file
- To run client app (You need to have sencha cmd installed) navigate to src/ClientApp directory and run:
    > sencha app watch
- Navigate to url http://localhost:1841/ and you can test it out

## Technologies

- Back-End uses ASP.NET Core Web API in .NET 7
- Front-End uses ExtJS 7.0.0
- Database is Microsoft SQL Server
