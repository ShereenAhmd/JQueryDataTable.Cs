using JQueryDataTable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace JQueryDataTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context=context;
        }

        [HttpPost]
        public IActionResult GetAllCustomers()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);
            var searchValue = Request.Form["search[value]"];

                    var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            
              var sortColumnDirection = Request.Form["order[0][dir]"];


            IQueryable<Customer> customers = _context.Customers.Where(m => string.IsNullOrEmpty(searchValue)
            ? true
            : (m.FName.Contains(searchValue) || m.LName.Contains(searchValue) || m.Contact.Contains(searchValue) || m.Email.Contains(searchValue)));

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                customers = customers.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));

            var data = customers.Skip(skip).Take(pageSize).ToList();
            var recordsTotal = customers.Count();

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };

            return Ok(jsonData);


          
        }
    }
}
