# Lesson24 - Tasks

## Reading Materials
1. https://www.sqlservertutorial.net/sql-server-basics/sql-server-primary-key/
2. https://www.sqlservertutorial.net/sql-server-basics/sql-server-foreign-key/
3. https://www.sqlservertutorial.net/sql-server-basics/sql-server-not-null-constraint/
4. https://www.sqlservertutorial.net/sql-server-basics/sql-server-unique-constraint/
5. https://www.sqlservertutorial.net/sql-server-basics/sql-server-check-constraint/
6. https://www.sqlservertutorial.net/sql-server-basics/sql-server-create-database/
7. https://www.sqlservertutorial.net/sql-server-basics/sql-server-drop-database/
8. https://www.sqlservertutorial.net/sql-server-basics/sql-server-create-table/
9. https://www.sqlservertutorial.net/sql-server-basics/sql-server-identity/
10. https://www.sqlservertutorial.net/sql-server-basics/sql-server-alter-table-add-column/
11. https://www.sqlservertutorial.net/sql-server-basics/sql-server-alter-table-alter-column/
12. https://www.sqlservertutorial.net/sql-server-basics/sql-server-alter-table-drop-column/
13. https://www.sqlservertutorial.net/sql-server-basics/sql-server-drop-table/
14. https://www.sqlservertutorial.net/sql-server-basics/sql-server-truncate-table/
15. https://www.sqlservertutorial.net/sql-server-basics/sql-server-select-into/
16. https://www.sqlservertutorial.net/sql-server-basics/sql-server-rename-table/
17. https://www.sqlservertutorial.net/sql-server-basics/sql-server-temporary-tables/


## TODO
   Create 2 tables 
   - **Departments** (**Id**(int), **Name**(nvarchar(50) not null), **CreatedDate**(datetime) not null default getdate()) 
   - **Employees**   (**Id**(int), **FirstName**(nvarchar(20) not null), LastName(nvarchar(20) not null), **EmploymentDate** (datetime), **DepartmentId**(int foreign key not null), **ManagerId** int self foreign key))

Do create these 2 tables based on the following criterias:
   - **DepartmentId** in **Employees** table should be a foreign key. Foreign key name should be "FK_Employees_DepartmentId_Departments_Id". You should explicitly set ON UPDATE and ON DELETE actions to "NO ACTION"
   - **ManagerId** in **Employees** table is self foreign key (read https://www.sqlservertutorial.net/sql-server-basics/sql-server-self-join/). For the director **ManagerId** will be null, but for all others **ManagerId** should be set and foreign key name should be "FK_Employees_ManagerId_Employees_Id"
   - For both tables ID column should be identity (1,1)
   - In **Departments** table **CreatedDate** should not null and give "DF_Departments_CreatedDate" name to this default constraint
   - After creation of tables populate them with some mock data
   - Write a query to return **EmployeeFirstName, EmployeeLastName, ManagerFirstName, ManagerLastName, DepartmentName** result