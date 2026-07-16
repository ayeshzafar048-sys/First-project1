using System;

namespace UniversitySystem
{
    // Base Class
    class Student
    {
        
        public int name1;
        public int Student_Id;
        public string Student_Name;
        public string Father_Name;
        public string e_mail;
        public DateTime Date_Of_Birth;
        public int Department_Id;
        public double CGPA;
        public double Fee;

        // Default Constructor
        public Student()
        {
        }

        // Parameterized Constructor
        public Student(int studentId, string studentName, string fatherName,
                       string email, DateTime dob, int departmentId,
                       double cgpa, double fee)
        {
            Student_Id = studentId;
            Student_Name = studentName;
            Father_Name = fatherName;
            e_mail = email;
            Date_Of_Birth = dob;
            Department_Id = departmentId;
            CGPA = cgpa;
            Fee = fee;
        }

        public void InputStudent()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Student ID: ");
                    Student_Id = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid ID, try again.");
                }
            }

            Console.Write("Enter Student Name: ");
            Student_Name = Console.ReadLine();

            Console.Write("Enter Father Name: ");
            Father_Name = Console.ReadLine();

            Console.Write("Enter Email: ");
            e_mail = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
                    Date_Of_Birth = Convert.ToDateTime(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid Date, try again.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter Department ID: ");
                    Department_Id = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid Department ID, try again.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter CGPA: ");
                    CGPA = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid CGPA, try again.");
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter Fee: ");
                    Fee = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid Fee, try again.");
                }
            }
        }

        public void DisplayStudent()
        {
            Console.WriteLine("\n========== Student Information ==========");
            Console.WriteLine("Student ID      : " + Student_Id);
            Console.WriteLine(" Name    : " + Student_Name);
            Console.WriteLine("Father Name     : " + Father_Name);
            Console.WriteLine("Email           : " + e_mail);
            Console.WriteLine("Date of Birth   : " + Date_Of_Birth.ToShortDateString());
            Console.WriteLine("Department ID   : " + Department_Id);
            Console.WriteLine("CGPA            : " + CGPA);
            Console.WriteLine("Fee             : " + Fee);
            Console.WriteLine("Age             : " + CalculateAge());
        }
        public int CalculateAge()
        {
            int age = DateTime.Now.Year - Date_Of_Birth.Year;

            if (DateTime.Now.DayOfYear < Date_Of_Birth.DayOfYear)
            {
                age--;
            }

            return age;
        }

        public void CalculateGrade()
        {
            if (CGPA >= 3.7)
                Console.WriteLine("Grade : A");
            else if (CGPA >= 3.3)
                Console.WriteLine("Grade : B+");
            else if (CGPA >= 3.0)
                Console.WriteLine("Grade : B");
            else if (CGPA >= 2.5)
                Console.WriteLine("Grade : C");
            else if (CGPA >= 2.0)
                Console.WriteLine("Grade : D");
            else
                Console.WriteLine("Grade : F");
        }

        public void FeeConcession()
        {
            double concession = 0;

            if (CGPA >= 3.7)
                concession = Fee * 0.50;
            else if (CGPA >= 3.3)
                concession = Fee * 0.30;
            else if (CGPA >= 3.0)
                concession = Fee * 0.20;

            Console.WriteLine("Fee Concession : " + concession);
            Console.WriteLine("Remaining Fee  : " + (Fee - concession));
        }
    }

    // Derived Class
    class Account : Student
    {
        public int AccountID;
        public string Username;
        public string PasswordHash;
        public string AccountStatus;

        // Default Constructor
        public Account()
        {
        }

        // Parameterized Constructor
        public Account(int studentId, string studentName, string fatherName,
                       string email, DateTime dob, int departmentId,
                       double cgpa, double fee,
                       int accountId, string username,
                       string passwordHash, string accountStatus)
            : base(studentId, studentName, fatherName, email, dob,
                  departmentId, cgpa, fee)
        {
            AccountID = accountId;
            Username = username;
            PasswordHash = passwordHash;
            AccountStatus = accountStatus;
        }

        public void InputAccount()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter Account ID: ");
                    AccountID = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid Account ID, try again.");
                }
            }

            Console.Write("Enter Username: ");
            Username = Console.ReadLine();

            Console.Write("Enter Password: ");
            PasswordHash = Console.ReadLine();

            Console.Write("Enter Account Status (Active/Suspended): ");
            AccountStatus = Console.ReadLine();
        }

        public void DisplayAccount()
        {
            Console.WriteLine("\n========== Account Information ==========");
            Console.WriteLine(" student Account ID      : " + AccountID);
            Console.WriteLine("Username        : " + Username);
            Console.WriteLine("Password     ayesha   : " + PasswordHash);
            Console.WriteLine("Account Status  : " + AccountStatus);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account student = new Account();

            student.InputStudent();

            Console.WriteLine();

            student.InputAccount();

            Console.WriteLine("\n=================================");

            student.DisplayStudent();
            student.DisplayAccount();

            Console.WriteLine("\n========== RESULT ==========");
            student.CalculateGrade();
            student.FeeConcession();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}