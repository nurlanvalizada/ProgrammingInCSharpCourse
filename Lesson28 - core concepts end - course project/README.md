# CourseManagement Portal

## DB structure (Main objects)

 ### Course
- Id
- Name
- Duration (in months)
- Price (AZN)
- CreationTime
- ModificationTime

 ### Student
- Id
- Name
- Surname
- BirthDate
- CreationTime
- ModificationTime


### Teacher
- Id
- Name
- Surname
- BirthDate
- Profession
  
## Requirements
  1. We should have CRUD functionality for Course, Student and Teacher
  2. Teacher can teach different courses, we need to store which courses can be teached by a given teacher
  3. We should be able to start a course for given period (Planned start date, Planned end date), register student to that course and assign appropriate teacher for this course, (StudentId, TeacherId, CourseId, StartDate, EndDate)
  4. We planned to do course lessons 2 times in a week. Therefore for each lesson we can do the followings \
    - Indicate if student is participated in a lesson or not \
    - Add some note for student and for that lesson 
  5. We should monitor current ongoing courses, see students and teacher, select student and see all progress(for each lesson)