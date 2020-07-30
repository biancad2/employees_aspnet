using Employees_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employees_CRUD.Controllers
{
    public class EmployeeController : Controller
    {
        #region Metodo para listar funcionario - READ
        [HttpGet]
        public JsonResult GetEmployee()
        {
            using (var db = new EmployeesEntities())
            {
                List<Employee> listEmployees = db.Employees.ToList();

                return Json(listEmployees, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Metodo para Adicionar funcionario - CREATE
        [HttpPost]
        public JsonResult AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                using (var db = new EmployeesEntities())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();

                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }
        #endregion

        #region Metodo para Adicionar funcionario - UPDATE
        [HttpPost]
        public JsonResult UpdateEmployee(Employee employee)
        {
            using (var db = new EmployeesEntities())
            {
                var updatedEmployee = db.Employees.Find(employee.EmployeeId);

                if (updatedEmployee == null)
                {
                    return Json(new { success = false });
                }
                else
                {
                    updatedEmployee.Name = employee.Name;
                    updatedEmployee.Department = employee.Department;
                    updatedEmployee.Office = employee.Office;
                    updatedEmployee.Email = employee.Email;

                    db.SaveChanges();
                    return Json(new { success = true });
                }
            }
        }
        #endregion

        #region Metodo para Adicionar funcionario - DELETE
        [HttpPost]
        public JsonResult DeleteEmployee(int id)
        {
            using (var db = new EmployeesEntities())
            {
                var employee = db.Employees.Find(id);

                if (employee == null)
                {
                    return Json(new { success = false });
                }
                else
                {
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    return Json(new { success = true });
                }
            }
        }
        #endregion
    }
}