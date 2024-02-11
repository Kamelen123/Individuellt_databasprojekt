using Individuellt_databasprojekt.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace Individuellt_databasprojekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using GymnasieskolanNyDbContect context = new GymnasieskolanNyDbContect();
            MainMenu(context);
        }
        private static void MainMenu(GymnasieskolanNyDbContect context)
        {

            bool programRunning = false;
            while (!programRunning)
            {
                Console.WriteLine("Option [1] Retreive all active Courses");
                Console.WriteLine("Option [2] Retreive all students from a specific class");
                Console.WriteLine("Option [3] Add Employee to DataBase");
                Console.WriteLine("Option [4] Department distribution");
                Console.WriteLine("Option [5] Exit Program");
                Console.WriteLine("Choose an option from the menu...");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        ActiveCourses(context);
                        Clear();
                        break;
                    case "2":
                        RetreiveStudentByClass(context);
                        Clear();
                        break;
                    case "3":
                        AddEmployee(context);
                        Clear();
                        break;
                    case "4":
                        CountTeachersByDepartment(context);
                        Clear();
                        break;
                    case "5":
                        programRunning = true;
                        break;
                }
            }
        }
        private static void RetreiveStudentByClass(GymnasieskolanNyDbContect context)
        {
            var distinctClasses = context.TblStudents.Select(s => s.Class).Distinct();
            Console.WriteLine(" Select from one of these classes");
            foreach (var className in distinctClasses)
            {
                Console.WriteLine($"Class : {className}");
                Console.WriteLine("-----------------------");
            }
            Console.Write(": ");
            var selectedClass = Console.ReadLine().ToUpper();
            var students = context.TblStudents.Where(s => s.Class == selectedClass).OrderBy(s => s.FirstName);
            //var students = context.TblStudents;
            foreach (TblStudent s in students)
            {
                Console.WriteLine($"Name : {s.FirstName} {s.LastName}");
                Console.WriteLine($"ID : {s.Id}");
                Console.WriteLine($"Class : {s.Class}");
                Console.WriteLine("------------------------------------");
            }
        }
        private static void AddEmployee(GymnasieskolanNyDbContect context)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");

            try
            {
                using (SqlConnection connection = new SqlConnection(context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SpAddEmployee", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@AddFirst_Name", firstName);
                        command.Parameters.AddWithValue("@AddLast_Name", lastName);
                        command.Parameters.AddWithValue("@AddPhone_number", phoneNumber);
                        command.Parameters.AddWithValue("@AddAdress", address);
                        command.Parameters.AddWithValue("@AddSalary", salary);
                        command.Parameters.AddWithValue("@AddDate_Start", formattedDate);

                        command.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Employee added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding employee: " + ex.Message);
            }
        }
        private static void ActiveCourses(GymnasieskolanNyDbContect context)
        {
            var activeCourses = context.TblCourses.Where(c => c.Active == "YES").ToList();
            var GetTeacherName = (from course in activeCourses 
                               join teacher in context.TblTeachers 
                               on course.TeacherId equals teacher.Id
                               join employee in context.TblEmployees
                               on teacher.EmployeeId equals employee.Id
                               select new 
                               {
                                   Cid = course.Id,
                                   CActive = course.Active,
                                   CName = course.CourseName,
                                   TeacherName = $"{employee.FirstName} {employee.LastName}"
                               }).ToList();

            Console.WriteLine("Active Courses:");
            foreach (var course in GetTeacherName)
            {
                Console.WriteLine($"ID: {course.Cid}, Name: {course.CName} Thought by: {course.TeacherName} Is Active: {course.CActive}");
            }
        }
        private static void CountTeachersByDepartment(GymnasieskolanNyDbContect context)
        {
            var teacherCounts = context.TblTeachers
                .GroupBy(teacher => teacher.DepartmentId)
                .Select(group => new
                {
                    DepartmentId = group.Key,
                    DepartmentName = context.TblDepartments.FirstOrDefault(d => d.Id == group.Key).DepartmentName,
                    TeacherCount = group.Count()
                });

            Console.WriteLine("Teacher count by department:");
            foreach (var info in teacherCounts)
            {
                Console.WriteLine($"Department ID: {info.DepartmentId}, Department Name: {info.DepartmentName ?? "Unknown"}, Teacher Count: {info.TeacherCount}");
            }
        }
        private static void Clear()
        {
            Console.ReadKey();
            Console.Clear();
        }

    }
}
