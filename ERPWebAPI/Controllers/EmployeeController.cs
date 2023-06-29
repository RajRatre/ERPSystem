using ERPWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERPWebAPI.Controllers
{

    [Route("api/EmployeeApi/")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeContext _dbcontext;
        public EmployeeController(EmployeeContext employeeContext)
        {
            _dbcontext = employeeContext;
        }

        [HttpGet(Name = "GetAllEmployee")]
        public ActionResult<List<Employee>> GetAllEmployee()
        {
            var data = _dbcontext.Employees.ToList();

            return Ok(data);
        }
        // [HttpGet(Name ="Get")]
        //  public IActionResult  Get(int id)
        //  {
        //     var data =  _dbcontext.Employees.Find(id);

        //     return Ok(data) ;
        //  }
    }
}