# Lesson32 - Tasks

## Reading Materials
1. https://www.geeksforgeeks.org/basics-computer-networking/
2. https://www.kaspersky.com/resource-center/definitions/what-is-an-ip-address
3. https://www.cloudflare.com/learning/network-layer/what-is-a-computer-port/

## Tasks
1. Let's write a custom middleware that logs the followings as info severity:
   - Logs the timestamp of request
   - Logs the whole url
   - Logs Http method (GET, POST and etc.)
   - If in **appsettings.json** file "**LogBody**" confic is declared as true then log the body if any
   - Log the response time of whole request, in what seconds application processed your request
2. We have the following Employee object
   - Id
   - Name
   - Surname
   - BirthDate
   - Position
   - Salary
   - IsManager \
   \
     We need to do the followings
   - Create in memory CRUD app for Employee in EmployeeController 
   - We should be anly change the user Position, Salary and IsManager properties