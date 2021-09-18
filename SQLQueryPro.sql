
/*
create table EmployeeDetails
(
Employee_ID varchar(50) not null,
Name varchar(50) not null,
EmailId varchar(50) not null,
ContactNo varchar(20) not null,
Address varchar(50) not null,
Salary Decimal(18,2) not null
PRIMARY KEY(Employee_ID)
)

insert into EmployeeDetails values ('E001','Janvi','jan12@gmail.com','7774885023','Jalindar','30000') 


insert into EmployeeDetails values ('E002','Vaishnavi','pawarvaishnavi777@gmail.com','8446260396','Latur','28000') 

delete from EmployeeDetails where Name='Vaishnavi'


insert into EmployeeDetails values ('E003','Ankita','ankitay@gmail.com','8745246578','Goa','35000') 


insert into EmployeeDetails values ('E006','Pooja','pooja65@gmail.com','8778967548','Mumbai','20000')


insert into EmployeeDetails values ('E007','Utkrsh','landge@gmail.com','9875845578','Latur','25000')

insert into EmployeeDetails values ('E008','Vijyamala','sarge@gmail.com','7778456889','Pune','45000')

insert into EmployeeDetails values ('E009','Mohini','kardile@gmail.com','9858677978','Nanded','38000')


drop table EmployeeDetails

create table DepartmentDetails
(
Dept_ID varchar(50) not null PRIMARY KEY,
Dept_Name varchar(50) not null,
Job_Name varchar(50) not null,
Employee_ID varchar(50) not null FOREIGN KEY
REFERENCES EmployeeDetails(Employee_ID)
)

//drop table DepartmentDetails

insert into DepartmentDetails values ('D001','Marketing','Manager','E004')

insert into DepartmentDetails values ('D002','Finance','Clerk','E003')

insert into DepartmentDetails values ('D007','IT','IT_PROG','E005')

insert into DepartmentDetails values ('D006','IT','IT_PROG','E007')

insert into DepartmentDetails values ('D009','Sales','Manager','E008')

select * from DepartmentDetails

select * from EmployeeDetails


select ad.*
from EmployeeDetails ed
join (select Name, EmailId, COUNT(*) 
from EmployeeDetails 
Group by Name,EmailId Having COUNT(*)>1) 

Select EmployeeDetails.Name, DepartmentDetails.Dept_ID from EmployeeDetails FULL OUTER JOIN 
DepartmentDetails ON EmployeeDetails.Employee_ID = DepartmentDetails.Employee_ID order by EmployeeDetails.Name

   
select EmployeeDetails.Name, DepartmentDetails.Dept_ID 
from EmployeeDetails
FULL OUTER JOIN 
DepartmentDetails ON 
EmployeeDetails.Employee_ID=DepartmentDetails.Employee_ID 
order by EmployeeDetails.Name



select DepartmentDetails.Dept_Name,  COUNT(Dept_Name)
from  
EmployeeDetails 
inner join DepartmentDetails 
on EmployeeDetails.Employee_ID=DepartmentDetails.Employee_ID
 Group by Dept_Name
 Having COUNT(Dept_Name)>1

select  COUNT(Dept_Name)
from DepartmentDetails 
 Group by Dept_Name
 Having COUNT(Dept_Name)>1
 
 
 select ed.*,dd.*
 from EmployeeDetails ed
 join DepartmentDetails dd
 on ed.Employee_ID=dd.Employee_ID
 where ed.Employee_ID='E001'

 select * from EmployeeDetails

 select ed.Name,ed.EmailId,dd.Dept_Name,dd.Job_Name 
 from EmployeeDetails ed
 join DepartmentDetails dd
 on ed.Employee_ID=dd.Employee_ID
 where dd.Dept_Name='Marketing';

 select EmployeeDetails.Name, DepartmentDetails.Employee_ID, 
 EmployeeDetails.Address,EmployeeDetails.Salary, DepartmentDetails.Dept_ID 
 from EmployeeDetails FULL OUTER JOIN DepartmentDetails 
 ON EmployeeDetails.Employee_ID = DepartmentDetails.Employee_ID 
 order by EmployeeDetails.Name


 select ed.*,dd.* 
 from EmployeeDetails ed 
 FULL JOIN DepartmentDetails dd 
 ON ed.Employee_ID =dd.Employee_ID 
 order by ed.Name*/

select * from DepartmentDetails

select * from EmployeeDetails


 select ed.*, dd.*
 from EmployeeDetails ed FULL OUTER JOIN DepartmentDetails dd
 ON ed.Employee_ID = dd.Employee_ID 
 order by ed.Employee_ID

 select ed.*,dd.*
 from EmployeeDetails ed
 join DepartmentDetails dd
 on ed.Employee_ID=dd.Employee_ID
 where dd.Dept_Name = 'IT'

 select EmailId
 from EmployeeDetails 
 join (select Name, Employee_ID
 from EmployeeDetails dd having count(*)>1) DepartmentDetails on EmployeeDetails.Employee_ID=DepartmentDetails.Employee_ID

 
 /*select DISTINCT COUNT(EmployeeDetails.Name) AS EmployeeDetails.Name from EmployeeDetails Right join Depa*/

 select COUNT(*) AS Name, s.Employee_ID from ed.EmployeeDetails   AS s where exists (select * from DepartmentDetails AS t where s.


Select Dept_ID,  Dept_Name, Job_Name,COUNT(*)
 AS Total from DepartmentDetails where Dept_Name='IT'
 Group by Dept_ID,Dept_Name,Job_Name

 
Select COUNT(*)
 AS CountEmpDeptName from DepartmentDetails where Dept_Name='IT'

Select COUNT(*)
  from DepartmentDetails where Dept_Name='IT'
