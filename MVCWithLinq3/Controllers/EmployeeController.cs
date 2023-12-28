using MVCWithLinq3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithLinq3.Controllers
{
    public class EmployeeController : Controller
    {
        #region instance of dal Class
        EmployeeDAL dal = new EmployeeDAL();
        #endregion

        #region  DisplayEmployees
        public ViewResult DisplayEmployees()
        {
            return View(dal.GetEmployees());
        }
        #endregion

        #region AddEmployee
        [HttpGet]
        public ViewResult AddEmployee()
        {
            EmpDept emp = new EmpDept();
            emp.Departments = dal.GetDepartments();
            return View(emp);

        }
        [HttpPost]
        public RedirectToRouteResult AddEmployee(EmpDept emp)
        {
            dal.Employee_Insert(emp);
            return RedirectToAction("DisplayEmployees");
        }
        #endregion


        #region  DisplayEmployee
        public ViewResult DisplayEmployee(int eid)
        {
            return View(dal.GetEmployee(eid));
        }
        #endregion

        #region Update Employee
        public RedirectToRouteResult UpdateEmployee(EmpDept emp)
        {
            dal.Employee_Update(emp);
            return RedirectToAction("DisplayEmployees");
        }
        #endregion

        #region Delete Employee
        public RedirectToRouteResult DeleteEmployee(int emp)
        {
            dal.Employee_Delete(emp);
            return RedirectToAction("DisplayEmployees");
        }

        #endregion
    }
}