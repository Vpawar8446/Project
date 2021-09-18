using System;
using HRMSAPI;
using HRMSModule;
using System.Text.RegularExpressions;


namespace HRMSPROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            Connection.CreateConnection();
            string input;

          A:
            Console.WriteLine("D. Display All Record From Both Table");
            Console.WriteLine("I. Insert Details Of Employee");
            Console.WriteLine("DEL. Delete Record From EmployeeDetails");
            Console.WriteLine("U. Update Record In Table");
            Console.WriteLine("S. Search Employee By Employee_ID ");
            Console.WriteLine("ID. Insert records in Dempartment Table");
            Console.WriteLine("SD. List Of Employee by Dept_ID");
            Console.WriteLine("C. Department wise employee count");
            Console.WriteLine("E. Exit from table");
            
            Console.WriteLine("===================================================================================");

            
            //input = Console.ReadLine();
            string Employee_ID, Name, EmailId, ContactNo, Address;
            decimal Salary;
            string Dept_ID, Dept_Name, Job_Name;
           
            
            do
            {
                Console.Write("Enter your Choice : ");
                input= Console.ReadLine();
                switch (input)
                {

                    case "D":
                        Console.WriteLine();
                        Connection.DisplayData();
                        break;


                    case "I":
                        Console.WriteLine();
                        Console.WriteLine("**** Insert Employee Details ****");

                        Console.Write("Enter Employee ID : ");
                        Employee_ID = Console.ReadLine();
                        Console.Write("Enter Empoyee Name : ");
                        Name = Console.ReadLine();
                        while (string.IsNullOrEmpty(Name))
                        {
                         Console.WriteLine("Please Enter the Employee Name It Cannot be blank");
                         Console.WriteLine("Enter the Employee name again");
                         Console.Write("Enter Empoyee Name : ");
                         Name= Console.ReadLine();
                        }
                        Console.Write("Enter Empoyee Email-Id : ");
                        EmailId = Console.ReadLine();
                       Console.Write("Enter Empoyee Contact Number : ");
                        ContactNo = Console.ReadLine();
                        Console.Write("Enter Empoyee Address : ");
                        Address = Console.ReadLine();
                        Console.Write("Enter Employee Salary : ");
                        Salary = Convert.ToDecimal(Console.ReadLine());
                        Connection.InsertEmpData(Employee_ID, Name, EmailId, ContactNo, Address, Salary);
                        Connection.DisplayEmpData();
                        break;

                    case "DEL":
                        Console.WriteLine();
                        Console.WriteLine("***** Delete Record In Table *****");
                        Console.WriteLine("Enter Empoyee Name to Deleted record : ");
                        Name = Console.ReadLine();
                        Connection.DeleteEmpData(Name);
                        Connection.DisplayEmpUpdatedData();
                        break;

                    case "U":
                        Console.WriteLine();
                        Console.WriteLine("***** Update Record In Table *****");
                        Console.Write("Enter the employee ID : ");
                        Employee_ID = Console.ReadLine();
                        Console.Write("Enter Employee Name to update : ");
                        Name = Console.ReadLine();
                        Console.Write("Enter Address to Upate : ");
                        Address = Console.ReadLine();
                        Console.Write("Enter Salary to Upate : ");
                        Salary = Convert.ToDecimal(Console.ReadLine());
                        Connection.UpdateData(Employee_ID, Name, Address, Salary);
                        Connection.DisplayEmpData();
                        
                        break;

                    case "S":
                        Console.WriteLine();
                        Console.WriteLine("***** Search Record In Table By Employee ID *****");
                        Console.WriteLine("Enter the Employee ID : ");
                        Employee_ID = Console.ReadLine();
                        Connection.SearchEmpData(Employee_ID);
                        break;

                    case "ID":
                        Console.WriteLine();
                        Console.WriteLine("***** Insert Record Into DepartmentDetails Table *****");
                         Console.Write("Enter the Department ID : ");
                        Dept_ID = Console.ReadLine();
                        Console.Write("Enter Your Department Name : ");
                        Dept_Name = Console.ReadLine();
                        Console.Write("Enter Your Job Name : ");
                        Job_Name = Console.ReadLine();
                        Console.Write("Enter Your Employee ID : ");
                        Employee_ID = Console.ReadLine();
                        Connection.InsertDeptData(Dept_ID, Dept_Name, Job_Name, Employee_ID);
                        //Connection.DisplayDeptData();
                        break;

                   case "SD":
                        Console.WriteLine("***** Search Record In Table By Department ID  *****");
                        Console.WriteLine();
                        Console.WriteLine("Enter Department Name : ");
                        Dept_Name = Console.ReadLine();
                        Connection.DisplayEmpDataDept(Dept_Name);
                        break;

                    case "C":
                        Console.WriteLine();
                        Console.WriteLine("Enter Department Name : ");
                        Dept_Name = Console.ReadLine();

                        Connection.CountDeptEmpData(Dept_Name);
                        break;
                    

                    case "E":
                        Console.WriteLine();
                        Connection.ExitEmpApp();
                        break;

                    default:
                        
                        Console.WriteLine("Please enter correct details");
                        break;

                }

                Console.Write("Wish You Revisit Press Y to Continue : ");
                input = Console.ReadLine();
                Console.WriteLine("---------------------------------------------------------------------------------------");
            } 
            while (input == "y" || input == "Y");

        }
    }
}
