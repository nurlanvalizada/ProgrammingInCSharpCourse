# Lesson12 - Tasks

## Reading Materials
1. https://www.geeksforgeeks.org/c-sharp-interface/
   
## ToDo
1. Organize contents of any directory and it's files in the following style \
   - All image files should be in **Images** folder (png, jpg and etc.)
   - All video files should be in **Videos** folder (.mp4 and etc.)
   - All pdf and office files should be in **Documents** folder
   - All other files should in **Other Files** folder
   - Remove any empty directory
2. Write a program in C# Sharp to create and read the last line of a file. \
    Test Data: \
    Input number of lines to write in the file :3\
    Input 3 strings below :\
    Input line 1 : line1\
    Input line 2 : line2\
    Input line 3 : line3
    
    Expected Output: 

    The content of the last line of the file mytest.txt is: line3  

3. Write a program to calculate all files and directories count in a given directory (including files and folder in any subdirectory)
4. Create a C# program that implements an **IVehicle** interface with two methods, one for **Drive** of type void and another for **Refuel** of type bool that has a parameter of type integer with the amount of gasoline to refuel. \ 
Then create a **Car** class with a builder that receives a parameter with the car's starting gasoline amount and implements the **Drive** and **Refuel** methods of the **IVehicle**. \
The Drive method will print on the screen that the car is Driving, if the gasoline is greater than 0. The Refuel method will increase the gasoline of the car and return true.
To carry out the tests, create an object of type Car with 0 of gasoline in the **Main** of the program and ask the user for an amount of gasoline to refuel, finally execute the Drive method of the car. \
**Input** \
50 \
**Output** \
Driving