# Lesson38-39 - Tasks

## Reading Materials
1. https://docs.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-6.0
2. https://jwt.io/introduction
3. https://jasonwatmore.com/post/2021/06/02/net-5-create-and-validate-jwt-tokens-use-custom-jwt-middleware
4. https://www.tektutorialshub.com/asp-net-core/claims-based-authorization-in-asp-net-core/
5. https://www.tektutorialshub.com/asp-net-core/policy-based-authorization-in-asp-net-core/
6. https://www.tektutorialshub.com/asp-net-core/resource-based-authorization-in-asp-net-core/
7. https://docs.microsoft.com/en-us/aspnet/core/security/authorization/introduction?view=aspnetcore-6.0
8. https://docs.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-6.0

## Tasks
1. Try to implement authentication and authorization in our **StudentManager** (working previously) application
   - We should application users in database (Full Name, Email, BirthDate, Password (hash))
   - We should be able to create JWT tokens based on email and password
   - Authorize all Student CRUD endpoints so no anonymous user can access this APIs
   - Create a custom policy named **"StudentUpdatePolicy"** 
      1. Create a new requirement named **"StudentUpdateRequirement"**
         - Users with **Admin** role and have at least 21 years old can update the student **OR**
         - Users with **SuperAdmin** role can update the student
         - No other users can update the student
      2. Create 2 Handlers to process above 2 cases
   - Apply this policy to student update action method