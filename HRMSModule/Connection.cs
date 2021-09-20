using System;

//using System.Data.SqlClient.SqlParameterCollection;

using System.Data.SqlClient;
using HRMSModule;
using System.Text.RegularExpressions;



namespace HRMSModule
{
    public class Connection
    {
            public string connstr;
            public  static SqlConnection con;
            public static  SqlCommand cmd;
            public static SqlDataReader dr;


            //Create Connection with Sql Server Database (HRMSDB) 
            public static void CreateConnection()
            {
                string connstr = "Data Source=LAPTOP-3K24CQ1R; Initial Catalog= HRMSDB ; User ID= sa; Password=Pass@123";

                con = new SqlConnection();
                con.ConnectionString = connstr;
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine("******************************* WELCOME IN HRMS ***************************************");
                Console.WriteLine("---------------------------------------------------------------------------------------");


            }

        //Display record by given dept_Id ,dept_Name in both table using full join
        public static void DisplayData()
        {
            con.Open();
            string query = " select ed.*,dd.* from EmployeeDetails ed FULL JOIN DepartmentDetails dd ON ed.Employee_ID =dd.Employee_ID order by ed.Name";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("Employee_ID || Name \t|| EmailId \t\t|| ContactNo \t|| Address \t|| Salary \t|| Dept_ID \t|| Dept_Name \t|| Job_Name");
            while (dr.Read())
            {
                Console.WriteLine("{0} \t|| {1} \t|| {2} \t||  {3} \t|| {4} \t|| {5} \t|| {6} \t|| {7} \t|| {8}",
               dr["Employee_ID"], dr["Name"], dr["EmailId"], dr["ContactNo"], dr["Address"], dr["Salary"], dr["Dept_ID"], dr["Dept_Name"], dr["Job_Name"]);
            }
            dr.Close();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine();
            con.Close();

        }

        //Insert record into EmployeDetails
        public static void InsertEmpData(string Employee_ID, string Name, string EmailId,
            string ContactNo, string Address, Decimal Salary)
        {
            
            con.Open();

            string query = "insert into EmployeeDetails values(@empid,@n,@emid,@cn,@addr,@sal)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("empid", Employee_ID));
            cmd.Parameters.Add(new SqlParameter("n", Name));
            cmd.Parameters.Add(new SqlParameter("emid", EmailId));
            cmd.Parameters.Add(new SqlParameter("cn", ContactNo));
            cmd.Parameters.Add(new SqlParameter("addr", Address));
            cmd.Parameters.Add(new SqlParameter("sal", Salary));

            var r = cmd.ExecuteNonQuery();
            Console.WriteLine();
            Console.WriteLine("{0} of rows affected", r);
            Console.WriteLine();
            
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine();

            con.Close();

        }

        //Deleted Record
        public static void DeleteEmpData(string Name)
        {
            con.Open();
            SqlCommand deleteCommand = new SqlCommand("Delete from EmployeeDetails where Name=@emn", con);
            deleteCommand.Parameters.Add(new SqlParameter("emn", Name));
            Console.WriteLine();
            Console.WriteLine("Total rows affected are " + deleteCommand.ExecuteNonQuery());
            Console.WriteLine();
            
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            con.Close();

        }

        //Update Record
        public static void UpdateData(string Employee_ID, string Name, string Address, Decimal Salary)
        {
            con.Open();
            SqlCommand updateCommand = new SqlCommand("Update EmployeeDetails set Name=@na , Address=@Addr, Salary=@sal where Employee_ID=@ei ", con);

            updateCommand.Parameters.Add(new SqlParameter("na", Name));
            updateCommand.Parameters.Add(new SqlParameter("ei", Employee_ID));
            updateCommand.Parameters.Add(new SqlParameter("addr", Address));
            updateCommand.Parameters.Add(new SqlParameter("sal", Salary));
            dr = updateCommand.ExecuteReader();

            Console.WriteLine("Employee_ID \t Name \t Address \t Salary");
            while (dr.Read())
            {
                Console.WriteLine("{0} \t\t {1} \t {2} \t {3}",
               dr["Employee_ID"], dr["Name"], dr["Address"], dr["Salary"]);
            }
            dr.Close();
            Console.WriteLine();
            Console.WriteLine("Total rows affected are " + updateCommand.ExecuteNonQuery());
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.ReadLine();

            con.Close();
        }


        //Search Employee
        public static void SearchEmpData(string Employee_ID)
        {
            con.Open();
            SqlCommand searchCommand = new SqlCommand("select ed.*,dd.*from EmployeeDetails ed join DepartmentDetails dd on ed.Employee_ID = dd.Employee_ID where ed.Employee_ID = @ne", con);
            searchCommand.Parameters.Add(new SqlParameter("ne", Employee_ID));
            dr = searchCommand.ExecuteReader();

            Console.WriteLine("Employee_ID \t Name \t\t EmailId \t\t ContactNo \t Address \t Salary \t Dept_ID \t Dept_Name \t Job_Name");
            while (dr.Read())
            {
                Console.WriteLine("{0} \t\t|| {1} \t|| {2} \t|| {3} \t|| {4} \t|| {5} \t|| {6} \t|| {7} \t\t|| {8}",
               dr["Employee_ID"], dr["Name"], dr["EmailId"], dr["ContactNo"], dr["Address"], dr["Salary"], dr["Dept_ID"], dr["Dept_Name"], dr["Job_Name"]);
            }
            dr.Close();

            Console.WriteLine();
            Console.WriteLine("Search Successfelly");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine();

            con.Close();



        }


        //Dirsplay all records in EmployeeDetails Table
        public static void DisplayEmpData()
        {
            con.Open();
            string query = "Select * from EmployeeDetails";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("Employee_ID \t Name \t\t EmailId \t\t ContactNo \t\t\t Address \t\t Salary");
            while (dr.Read())
            {
                Console.WriteLine("{0} \t\t {1} \t  {2} \t {3} \t\t\t {4} \t\t\t{5}",
               dr["Employee_ID"], dr["Name"], dr["EmailId"], dr["ContactNo"], dr["Address"], dr["Salary"]);
            }
            dr.Close();

            string cmdcount = "select count(*) from EmployeeDetails ";
            cmd = new SqlCommand(cmdcount, con);
            int count = (int)cmd.ExecuteScalar();
            Console.WriteLine();
            Console.Write("{0} Records in the table", count);
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine();

            con.Close();

        }



        
        //Display updated record in employee table
        public static void DisplayEmpUpdatedData()
        {
            con.Open();
            string query = "select * from EmployeeDetails";
            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("Name | Employee_ID |  Address | Salary");
            while (dr.Read())
            {
                Console.WriteLine("{0} \t {1} \t {2} \t {3}", dr["Name"], dr["Employee_ID"], dr["Address"], dr["Salary"]);
                
            }
            dr.Close();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            con.Close();
        }

        
        //Insert records into DepartmentDetails

        public static void InsertDeptData(string Dept_ID, string Dept_Name, string Job_Name, string Employee_ID)
        {

            con.Open();

            string qu = "insert into DepartmentDetails values(@dpid,@dn,@jn,@ei)";
            cmd = new SqlCommand(qu, con);
            cmd.Parameters.Add(new SqlParameter("dpid", Dept_ID));
            cmd.Parameters.Add(new SqlParameter("dn", Dept_Name));
            cmd.Parameters.Add(new SqlParameter("jn", Job_Name));
            cmd.Parameters.Add(new SqlParameter("ei", Employee_ID));
            var r = cmd.ExecuteNonQuery();
            Console.WriteLine();
            Console.WriteLine("Total rows affected are {0} ", r);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            con.Close();

        }

        //Display DepartmentDetails table
        public static void DisplayDeptData()
        {
            con.Open();
            string queri = "select * from DepartmentDetails ";
            cmd = new SqlCommand(queri, con);
            dr = cmd.ExecuteReader();
            Console.WriteLine("Dept_ID \t Employee_ID \t Dept_Name \t Job_Name ");
            while (dr.Read())
            {
                Console.WriteLine("{0} \t\t {1} \t {2} \t {3} ",
                dr["Dept_ID"], dr["Employee_ID"], dr["Dept_Name"], dr["Job_Name"]);


            }
            dr.Close();

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine();
            con.Close();

        }


        //show list of employee for given departement
        public static void DisplayEmpDataDept(string Dept_Name)
        {
            con.Open();
            SqlCommand empdeptCommand = new SqlCommand("select ed.Name, ed.EmailId, dd.Dept_Name, dd.Job_Name from EmployeeDetails ed join DepartmentDetails dd on ed.Employee_ID = dd.Employee_ID where dd.Dept_Name = @dn ", con);
            empdeptCommand.Parameters.Add(new SqlParameter("dn", Dept_Name));
            dr = empdeptCommand.ExecuteReader();

            Console.WriteLine(" Name \t\t EmailId \t Dept_Name \t Job_Name ");
            while (dr.Read())
            {
                Console.WriteLine("{0} \t\t {1} \t {2} \t {3} ",
                dr["Name"], dr["EmailId"], dr["Dept_Name"], dr["Job_Name"]);
            }
            dr.Close();
            Console.WriteLine();
            Console.WriteLine("Display list of employee successfully " , empdeptCommand.ExecuteNonQuery());
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine();

            con.Close();
        }

        public static void CountDeptEmpData(string Dept_Name)
        {
            int count = 0;
            con.Open();
            //string dn = Dept_Name;
            string queri = "Select Dept_Name from DepartmentDetails where Dept_Name = '"+Dept_Name+"';" ;
            cmd = new SqlCommand(queri, con);
           
            dr = cmd.ExecuteReader();
            Console.WriteLine("Dept_Name");
            while (dr.Read())
            {
                count++;
                Console.WriteLine("{0} ",  dr[1]);
            }
            
            dr.Close();
            
            Console.WriteLine("Number of department in company are :" +count);
            Console.WriteLine("Commands executed... ");
            Console.WriteLine("Press enter to move to the next step ->");
            Console.WriteLine("___________________________________________________________");
            con.Close();
        }






        public static void ExitEmpApp()
        {
            Environment.Exit(0);
        }

    }
}
