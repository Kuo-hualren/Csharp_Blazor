using DBdesign.Shared;

namespace DBdesign.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployController : ControllerBase
    {
        //public static List<Employees> employees = new List<Employees>
        //{
        //    new Employees { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", Punch1 = punch1, Punch2 = punch2, PunchId = 1},
        //     new Employees { Id = 2, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", Punch1 = punch1, Punch2 = punch2, PunchId = 2}

        //};
        //public static List<Punchs1> punch1 = new List<Punchs1>
        //{
        //    new Punchs1 { Id = 1, Name = "Ben", PunchId = 1, Time = "ss", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", Employee = employees[0] }

        //};
        //public static List<Punchs2> punch2 = new List<Punchs2>
        //{
        //    new Punchs2 { Id = 1, Name = "Ben", PunchId = 2, Time = "ss", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "", Employee = employees[1] }

        //};

        private readonly DataContext _context;
        public EmployController(DataContext context)
        {
            _context = context;

        }

        
        [HttpGet]
        public async Task<ActionResult<List<Employees>>> GetEmployees()
        {
            //return Ok(employees);
            var emps = await _context.Employees
                .ToListAsync();
            return Ok(emps);
        }

        [HttpGet("pr1")]
        public async Task<ActionResult<List<Punchs1>>> GetPunch1()
        {
            var ps1 = await _context.Punchs1
                .ToListAsync();
            return Ok(ps1);
        }


    }
}
