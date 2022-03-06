# Lesson37 - Tasks

## Reading Materials
1. https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-6.0
2. https://www.tutorialsteacher.com/core/aspnet-core-logging
3. https://stackoverflow.com/questions/40073743/how-to-log-to-a-file-without-using-third-party-logger-in-net-core
4. https://github.com/serilog/serilog-aspnetcore
5. https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-6.0
6. https://docs.fluentvalidation.net/en/latest/aspnet.html

## Tasks
1. Try to implement correct validation and logging in our **StudentManager** (working previously) application
   - We should only user DTOs (model) for controller actions not directly entities
   - Configure both data annotations validation and fluent validation (on startup we should be able to configure to use which one)
   - All exceptions should be logged, correct debug, information and warning logs also should be added