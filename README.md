#ProjectTitle: Candidate Management System

### Project Overview
- This is a Web API to add or update the information of Candidate
- This project is built using the CQRS pattern with MediatR for handling requests, an SQLite database for data storage, and NUnit for unit testing
- .NET Core 8, Visual Studio 2022 was used to build it

### Running the Application
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build the solution to restore NuGet packages.
4. Run `dotnet ef database update` to create the database.
5. Run the application.

### Improvements
- Implement caching mechanism.
- Enhancing validation checks, especially on large datasets.
- Expanding testing coverage to cover edge cases.

### Assumptions
- SQLite used as the initial database.
- CQRS chosen to facilitate future scalability.
- PreferredCallTime is supposed as string but it can be dateTime duration(like from - To)
- Id was use as PK

### Total Time Spent
- Research and Initial Setup: 1.5 hour
- API and Controller: 2.5 hours
- CQRS Implementation: 1.5 hours
- Testing: 1.5 hours
- Documentation: 0.5 hour
**Total**: 7.5 hours
