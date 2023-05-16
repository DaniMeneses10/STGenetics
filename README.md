# STGenetics
**API where  customers can create, edit, delete, filter, and buy bulls or cows from our farm**
APi created in different layers
Controllers
Database
Interfaces
Models
Services

**Controllers**

**DATABASE Folder - SQL Server**
1. You will find an StoredProcedure Helper file, that will help us to filter Animals created
2. You will find some Scripts to create the Tables, Seeds in SQL Server
3. Keep in mind the "Connection String" on your local device
**Note: You will be able to create n seeds from Swagger**

**Interfaces**
All the required Interfaces to run the services classes

**Models**
1. Entities: Tables mapped with SQL Server
2. Requests: Classes to create a New Order from Swagger
3. Responses: Class for the Order Created
4. Validator: It will validate if any AnimalID is duplicated. The error will be added to the Order Response
however it can be handle with Excepetion handler too.

**Services**
You will find the logic of the API
