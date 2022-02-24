using Practice1.Models;
using Practice1.DatabaseContent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace Practice1.Controllers
{
    public class EmloyeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DepartmentsController> _logger;

        public EmloyeesController(ILogger<DepartmentsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Employees()
        {
            ViewData["Results"] = JoinDisplay();
            var tickets = await _context.HospitalDepartments.ToListAsync();
            return View(tickets);
        }

        public async Task<IActionResult> StaffThree()
        {
            ViewData["Results"] = JoinDisplay();
            var tickets = await _context.HospitalDepartments.ToListAsync();
            return View(tickets);
        }
        public static List<Join> JoinDisplay()
        {
            List<Join> Js = new List<Join>();
            string connection = "Data Source=.;Initial Catalog=Gspark;Integrated Security=True";

            using (SqlConnection sqlconn = new SqlConnection(connection))
            {
                using (SqlCommand sqlcomm = new SqlCommand("select HospitalDept.DepartmentId, HospitalDept.Department, Employee.FirstName, Employee.LastName from HospitalDept join Employee on HospitalDept.EmployeeId = Employee.EmployeeId"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sqlcomm.Connection = sqlconn;
                        sqlconn.Open();
                        sda.SelectCommand = sqlcomm;

                        SqlDataReader sdr = sqlcomm.ExecuteReader();
                        while (sdr.Read())
                        {
                            Join Jsobj = new Join();
                            Jsobj.DepartmentId = Convert.ToInt32(sdr["DepartmentId"]);
                            Jsobj.Department = sdr["Department"].ToString();
                            Jsobj.FirstName = sdr["FirstName"].ToString();
                            Jsobj.LastName = sdr["LastName"].ToString();
                            Js.Add(Jsobj);
                        }
                        return Js;
                    }
                }
            }
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HospitalDepartment obj)
        {
            if (ModelState.IsValid)
            {
                _context.HospitalDepartments.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var ticket = await _context.HospitalDepartments.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HospitalDepartment obj)
        {
            if (ModelState.IsValid)
            {
                _context.HospitalDepartments.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(obj);
        }
        public async Task<IActionResult> Details(int? ticketId)
        {
            var ticket = await _context.HospitalDepartments.FindAsync(ticketId);

            if (ticketId == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var ticket = await _context.HospitalDepartments.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            else if (id <= 3)
            {
                return RedirectToAction("Index");
            }
            else
                return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.HospitalDepartments.FindAsync(id);
            _context.HospitalDepartments.Remove(ticket);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
