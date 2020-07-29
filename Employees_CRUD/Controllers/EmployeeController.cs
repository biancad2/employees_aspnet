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
            using(var db = new EmployeesEntities())
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
            if(employee != null)
            {
                using(var db = new EmployeesEntities())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();

                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }
        #endregion
    }
}