using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Models;
using MvcApplication1.ViewModels;
using MvcApplication1.DataAccessLayer;

namespace MvcApplication1.Controllers
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
            
        }

        public List<Employee> GetEmployeesqiyong()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            emp.FirstName = "johnson";
            emp.LastName = "fernandes";
            emp.Salary = 14000;
            employees.Add(emp);




            emp = new Employee();
            emp.FirstName = "michael";
            emp.LastName = "jackson";
            emp.Salary = 16000;
            employees.Add(emp);


            emp = new Employee();
            emp.FirstName = "robert";
            emp.LastName = "pattinson";
            emp.Salary = 20000;
            employees.Add(emp);


            return employees;
        }
    }
}