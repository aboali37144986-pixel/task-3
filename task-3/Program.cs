namespace task_3
{

    class Course
    {
        public int courseId;
        public string Title;

       public Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            this.courseId = courseId;
            Title = title;
            this.Instructor = instructor;
        }

        public string PrintCourseDetails()
        {
            return $"Course ID: {courseId}, Title: {Title}, Instructor: {Instructor.Name}   ";
        }
    }
    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            this.InstructorId = instructorId;
            this.Name = name;
            this.Specialization = specialization;
        }
        public string PrintInstructorDetails()
        {
            return $"Instructor ID: {InstructorId}, Name: {Name}, Specialization: {Specialization}";
        }
    }


    class Student
    {
       public int studentId;
       public string name;
       public int age;
        List<Course> courses;

        public Student(int studentId, string name, int age)
        {
            this.studentId = studentId;
            this.name = name;
            this.age = age;
            courses = new List<Course>();
        }
        public bool EnrollInCourse(Course course)
        {
            if (courses.Contains(course))
            {
                return false;
            }
            courses.Add(course);
            return true;
        }
        public string PrintStudentDetails()
        {
            return $"Student ID: {studentId}, Name: {name}, Age: {age}";
        }
        public bool CheckEnrollmentInCourse(Course course)
        {
            return courses.Contains(course);
        }
    }
    class StudentManager
    {
        List<Student> students;
        List<Course> courses;
        List<Instructor> instructors;

        public StudentManager()
        {
            students = new List<Student>();
            courses = new List<Course>();
            instructors = new List<Instructor>();
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public void AddCourse(Course course)
        {
            courses.Add(course);

        }
        public void AddInstructor(Instructor instructor)
        {
            instructors.Add(instructor);
        }
        public Student FindStudent(int studentId)
        {

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].studentId == studentId)
                {
                    return students[i];

                }
            }
            return null;

        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].courseId == courseId)
                {
                    return courses[i];
                }
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].InstructorId == instructorId)
                {
                    return instructors[i];
                }
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student != null && course != null)
            {
                return student.EnrollInCourse(course);
            }
            return false;
        }
        public void ViewAllStudents()
        {
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].PrintStudentDetails());
            }

        }
        public void ViewAllCourses()
        {
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine(courses[i].PrintCourseDetails());
            }
        }
        public void ViewAllInstructors()
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                Console.WriteLine(instructors[i].PrintInstructorDetails());
            }
        }
        public bool UpdateStudent(int studentId, string newName, int newAge)
        {
            Student student = FindStudent(studentId);
            if (student != null)
            {
                student.name = newName;
                student.age = newAge;
                return true;
            }
            return false;
        }
        public bool DeleteStudent(int studentId)
        {
            Student student = FindStudent(studentId);
            if (student != null)
            {
                students.Remove(student);
                return true;
            }
            return false;

        }
        public bool isStudentEnrolledInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student != null && course != null)
            {
                return student.CheckEnrollmentInCourse(course);
            }
            return false;
        }
        public string FindInstructorByCourse(string courseName)
        {
           for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Title == courseName)
                {
                    return courses[i].Instructor.Name;
                }
            }
            return "Instructor not found for the given course.";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            int opt;
            do
            {
                Console.WriteLine("1. Add a New Student");
                Console.WriteLine("2.View all Students");
                Console.WriteLine("3. Search for Student by ID");
                Console.WriteLine("4. Add Course");
                Console.WriteLine("5. Add Instructor");
                Console.WriteLine("6. Enroll Student in Course");
                Console.WriteLine("7. View all Courses");
                Console.WriteLine("8. View all Instructors");
                Console.WriteLine("9. Update Student Information");
                Console.WriteLine("10. Delete Student");
                Console.WriteLine("11. Is Student Enrolled in Course? :"); // bouns
                Console.WriteLine("12. Find Instructor by Course");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                opt = Convert.ToInt32(Console.ReadLine());


                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Enter Student ID:");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Student Name:");
                        string studentName = Console.ReadLine();
                        Console.WriteLine("Enter student Age:");
                        int studentAge = Convert.ToInt32(Console.ReadLine());
                        Student student = new Student(studentId, studentName, studentAge);
                        manager.AddStudent(student);

                        Console.WriteLine("Student added successfully.");

                        break;
                    case 2:
                        manager.ViewAllStudents();

                        break;
                    case 3:
                        Console.WriteLine("Enter Student ID:");
                        int searchId = Convert.ToInt32(Console.ReadLine());
                        Student foundStudent = manager.FindStudent(searchId);
                        if (foundStudent != null)
                        {
                            Console.WriteLine(foundStudent.PrintStudentDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Course ID:");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter course title:");
                        string courseTitle = Console.ReadLine();
                        Console.WriteLine("Enter Instructor ID:");
                        int instructorIdForCourse = Convert.ToInt32(Console.ReadLine());
                        Instructor selectedInstructor = manager.FindInstructor(instructorIdForCourse);
                        if (selectedInstructor != null)
                        {
                            manager.AddCourse(new Course(courseId, courseTitle, selectedInstructor));
                            Console.WriteLine("Course added successfully.");

                        }
                        else
                        {

                            Console.WriteLine("Instructor not found. Please add the instructor first.");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Instructor ID:");
                        int instructorId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Instructor Name:");
                        string instructorName = Console.ReadLine();
                        Console.WriteLine("Enter Instructor Specialization:");
                        string instructorSpecialization = Console.ReadLine();
                        Instructor instructor = new Instructor(instructorId, instructorName, instructorSpecialization);
                        manager.AddInstructor(instructor);

                        Console.WriteLine("Instructor added successfully.");

                        break;
                    case 6:
                        Console.WriteLine("Enter Student ID:");
                        int studentIdForEnrollment = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Course ID:");
                        int courseIdForEnrollment = Convert.ToInt32(Console.ReadLine());
                        bool isEnrolled = manager.EnrollStudentInCourse(studentIdForEnrollment, courseIdForEnrollment);
                        if (isEnrolled)
                        {
                            Console.WriteLine("Student enrolled in course successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Enrollment failed. Please check if the student and course exist.");
                        }

                        break;
                    case 7:
                        manager.ViewAllCourses();

                        break;
                    case 8:
                        manager.ViewAllInstructors();
                        break;
                    case 9:

                        Console.WriteLine("Enter Student ID:");
                        int studentIdToUpdate = Convert.ToInt32(Console.ReadLine());
                        Student studentupdate = manager.FindStudent(studentIdToUpdate);
                        if (studentupdate != null)
                        {
                            Console.WriteLine("Enter New Name:");
                            string newStudentName = Console.ReadLine();
                            Console.WriteLine("Enter New Age:");
                            int newStudentAge = Convert.ToInt32(Console.ReadLine());
                            bool isUpdated = manager.UpdateStudent(studentIdToUpdate, newStudentName, newStudentAge);
                            if (isUpdated)
                            {
                                Console.WriteLine("Student information updated successfully.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Update failed. Student not found.");
                        }


                        break;
                    case 10:
                        Console.WriteLine("Enter Student ID to Delete:");
                        int studentIdToDelete = Convert.ToInt32(Console.ReadLine());
                        bool isDeleted = manager.DeleteStudent(studentIdToDelete);
                        if (isDeleted)
                        {
                            Console.WriteLine("Student deleted successfully.");

                        }
                        else
                        {
                            Console.WriteLine("Deletion failed. Student not found.");
                        }
                        break;

                    case 11:
                        Console.WriteLine("Enter course id:");
                        int courseIdToCheck = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter student id:");
                        int studentIdToCheck = Convert.ToInt32(Console.ReadLine());
                      bool check=  manager.isStudentEnrolledInCourse(studentIdToCheck, courseIdToCheck);
                        if (check)
                        {
                            Console.WriteLine("Student is enrolled in the course.");
                        }
                        else
                        {
                            Console.WriteLine("Student is not enrolled in the course.");
                        }
                        break;
                    case 12:
                        Console.WriteLine("Enter course Name:");
                        string cname = Console.ReadLine();
                        string instructorNameForCourse = manager.FindInstructorByCourse(cname);
                        Console.WriteLine("Instructor for the course: " + instructorNameForCourse);


                        break;
                    case 0:

                        break;


                }      
                        

            } while (opt != 0);

        }
    }
}
