using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    public class Student
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public char Grade { get; set; }

        public Student(string name, int rollNumber, char grade)
        {
            Name = name;
            RollNumber = rollNumber;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}";
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();

                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddNewStudent();
                        break;
                    case "2":
                        ViewAllStudents();
                        break;
                    case "3":
                        SearchStudentByNumber();
                        break;
                    case "4":
                        UpdateStudentGrade();
                        break;
                    case "5":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\nStudent Management System");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search for Student by Number");
            Console.WriteLine("4. Update Student Grade");
            Console.WriteLine("5. Exit");
        }

        static void AddNewStudent()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            
            Console.Write("Enter Roll Number: ");
            if (!int.TryParse(Console.ReadLine(), out int rollNumber))
            {
                Console.WriteLine("Invalid roll number. Please enter a numeric value.");
                return;
            }

            // Check if the roll number already exists
            if (students.Exists(s => s.RollNumber == rollNumber))
            {
                Console.WriteLine($"Roll Number {rollNumber} already exists. Please enter a unique roll number.");
                return;
            }

            Console.Write("Enter Grade (A-F): ");
            char grade = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (!char.IsLetter(grade) || !"ABCDEF".Contains(char.ToUpper(grade)))
            {
                Console.WriteLine("Invalid grade. Please enter a letter (A-F).");
                return;
            }

            students.Add(new Student(name, rollNumber, char.ToUpper(grade)));
            Console.WriteLine("Student added successfully.");
        }

        static void ViewAllStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students in the system.");
                return;
            }

            Console.WriteLine("\nList of Students:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        static void SearchStudentByNumber()
        {
            Console.Write("Enter Roll Number to Search: ");
            if (!int.TryParse(Console.ReadLine(), out int rollNumber))
            {
                Console.WriteLine("Invalid roll number. Please enter a numeric value.");
                return;
            }

            var student = students.Find(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                Console.WriteLine("Student Found:");
                Console.WriteLine(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        static void UpdateStudentGrade()
        {
            Console.Write("Enter Roll Number to Update Grade: ");
            if (!int.TryParse(Console.ReadLine(), out int rollNumber))
            {
                Console.WriteLine("Invalid roll number. Please enter a numeric value.");
                return;
            }

            var student = students.Find(s => s.RollNumber == rollNumber);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter New Grade (A-F): ");
            char grade = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (!char.IsLetter(grade) || !"ABCDEF".Contains(char.ToUpper(grade)))
            {
                Console.WriteLine("Invalid grade. Please enter a letter (A-F).");
                return;
            }

            student.Grade = char.ToUpper(grade);
            Console.WriteLine("Student grade updated successfully.");
        }
    }
}
