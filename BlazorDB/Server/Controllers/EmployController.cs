using BlazorDB.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;


namespace BlazorDB.Server.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class EmployController : ControllerBase
    {
        //public static List<Record> records = new List<Record> {
        //    new Record { Id = 1, Name = "Ben", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "0"},
        //    new Record { Id = 2, Name = "Alan", Time = DateTime.Today.ToString("yyyy/MM/dd"), PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "0"}
        //};

        //public static List<Employee> employees = new List<Employee> {
        //    new Employee { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", Record = records[0], RecordId = 1},
        //    new Employee { Id = 2, Name = "Alan", Phone = "0977777777", Email = "sssss@gmail.com", Position = "engineer", Record = records[1], RecordId = 2}
        //};

        public static List<PunchRec> punchRecs = new List<PunchRec> {
            new PunchRec { Id = 1, Name = "Ben", Email = "sss@gmail.com", Position = "engineer", Time = "2023/07/17", PunchIn = new DateTime(2023,7,12,9,01,12), PunchOut = new DateTime(2023,7,12,18,05,23), Hours = " "}
            
        };
        

        private readonly DataContext _context;
        public EmployController(DataContext context)
        {
            _context = context;
            
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var emps = await _context.Employees.Include(sh => sh.Record).ToListAsync();
            return Ok(emps);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            
            var emp = await _context.Employees
                .Include(h => h.Record)
                .FirstOrDefaultAsync(h => h.Id == id);
            if ( emp== null)
            {
                return NotFound("找不到");
            }
            return Ok(emp);
        }


        [HttpGet("records")]
        public async Task<ActionResult<List<Record>>> GetRecords()
        {
            var records = await _context.Records.ToListAsync();
            return Ok(records);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
        {
            employee.Record = null;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee, int id)
        {
            var dbEmploy = await _context.Employees
                .Include(sh => sh.Record)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbEmploy == null)
                return NotFound("Sorry");

            dbEmploy.Name = employee.Name;
            dbEmploy.Phone = employee.Phone;
            dbEmploy.Email = employee.Email;
            dbEmploy.Position = employee.Position;
            dbEmploy.RecordId = employee.Id;

            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var dbEmploy = await _context.Employees
                .Include(sh => sh.Record)
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbEmploy == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.Employees.Remove(dbEmploy);
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmployees());
        }


        private async Task<List<Employee>> GetDbEmployees()
        {
            return await _context.Employees.Include(sh => sh.Record).ToListAsync();
        }




        //------------------------------------------------------------------------------
        //[HttpPost]
        //public async Task<ActionResult<List<Record>>> CreateRecord(Record record)
        //{

        //    _context.Records.Add(record);
        //    await _context.SaveChangesAsync();
        //    var res = await _context.Records.ToListAsync();
        //    return Ok(res);
        //}



        //---------------------------------------Punch Test---------------------------------------
        [HttpGet("punchtime")]
        public async Task<ActionResult<List<PunchRec>>> GetPunchRec()
        {
            //var records = await _context.Records.ToListAsync();
            //return Ok(records);
            return Ok(punchRecs);
        }

        [HttpPost("punchtime")]
        public async Task<ActionResult<List<PunchRec>>> CreatePunch(PunchRec punch)
        {
            // punchRecs<list> 把 punch(單筆) 加進來 return 回去
            punchRecs.Add(punch);
            return Ok(punchRecs);

        }


        [HttpGet("punchtime/{id}")]
        public async Task<ActionResult<PunchRec>> GetSinglePunch(int id)
        {
            var p = punchRecs.FirstOrDefault(sh => sh.Id == id);
            
            if (p == null)
            {
                return NotFound("找不到");
               
            }
            return Ok(p);
        }


        [HttpPut("punchtime/{id}")]
        public async Task<ActionResult<List<PunchRec>>> UpdatePunch(PunchRec punch, int id)
        {
            var update = punchRecs.FirstOrDefault(sh => sh.Id == id);
            
            if (update == null)
                return NotFound("Sorry");

            update.Name = punch.Name;
            update.PunchOut = punch.PunchOut;
            update.Hours = punch.Hours;

            return Ok(update);
        }

    }
}
