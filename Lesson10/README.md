# Lesson9 - Tasks

## Reading Materials
1. https://www.geeksforgeeks.org/c-sharp-method-overriding/
2. https://www.geeksforgeeks.org/c-sharp-encapsulation/

## ToDo
1. https://www.exercisescsharp.com/oop/shapes-class-diagram - After creating correct classes create ab array of different SHAPES and calculate both perimeter and area

1. Create a SchoolPerson class that has SchoolName, Name, Surname, Age and DateOfBirth, CurrentClass properties. Also this class will have a general Greet method, which will show us "Hello {Name Surname}".

   Create a class "Student" and another class "Teacher", both descendants of "SchoolPerson" class. "SchoolPerson" will have a method calles "GoToClasses" and when calling this method it will show us "Inside Base GoToClasses method"

   The class "Student" will also have a public method "GoToClasses", which will write on screen "I’m {name surname}, I am student and I'm going to class."

   The class "Teacher" will have a public method "Explain", which will show on screen "Explanation begin on subject {subject}". Also, it will have a private attribute "subject", a string which indicates his/her speciality. Also "Teacher" will have a public method "GoToClasses", which will write on screen "I’m {name surname}, I am a teacher."

   The class SchoolPerson must have a functionality to set of their age (eg, 20 years old). Note: Age cannot be less than 6 and more than 50. If we try to assign invalid number exception should be thrown.

   The student will have a public method "ShowAge" which will write on the screen "My age is: 20 years old" (or the corresponding number).

   You must create another test class called "StudentAndTeacherTest" that will contain "Main" and: \
   Create a SchoolPerson and make it say hello \
   Create a student, set his age to 21, tell him to Greet, display his age and make him to go classes \
   Create a teacher, set age to 30 years old, ask him to say hello, then go to classes and then explain.
