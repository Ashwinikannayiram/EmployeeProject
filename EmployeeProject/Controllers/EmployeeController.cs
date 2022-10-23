using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeProject.Model;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        db dbop = new db();
        string msg = string.Empty;
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            Employee emp = new Employee();
            emp.type = "get";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Email = dr["Email"].ToString(),
                    Emp_Name = dr["Emp_Name"].ToString(),
                    Designation = dr["Designation"].ToString()

                });
            }

            return list;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public List<Employee> Get(int id)

        {
            Employee emp = new Employee();
            emp.ID = id;
            emp.type = "getid";
            DataSet ds = dbop.EmployeeGet(emp, out msg);
            List<Employee> list = new List<Employee>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new Employee
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Email = dr["Email"].ToString(),
                    Emp_Name = dr["Emp_Name"].ToString(),
                    Designation = dr["Designation"].ToString()

                });
            }
            return list;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                msg = dbop.EmployeeOpt(emp);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("(id")]
        public string Put(int id, [FromBody] Employee emp)
        {
            string msg = string.Empty;
            try
            {
                emp.ID = id;
                msg = dbop.EmployeeOpt(emp);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                Employee emp = new Employee();
                emp.ID = id;
                emp.type = "delete";
                msg = dbop.EmployeeOpt(emp);

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
