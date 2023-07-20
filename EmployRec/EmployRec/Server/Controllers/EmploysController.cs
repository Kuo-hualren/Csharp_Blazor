using EmployRec.Client.Pages;
using EmployRec.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EmployRec.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmploysController : ControllerBase
    {

        //public static List<Emplo> employees = new List<Emplo>
        //{
        //    new Emplo { Id = 1, Name = "Ben", Phone = "0966666666", Email = "sss@gmail.com", Position = "engineer", Punch1 = punch1, PunchId = 1},
        //    new Emplo { Id = 2, Name = "Alan", Phone = "0977777777", Email = "sssaaa@gmail.com", Position = "engineer", Punch2 = punch2, PunchId = 2}

        //};
        //public static List<Puns1> punch1 = new List<Puns1>
        //{
        //    new Puns1 { Id = 1, Name = "Ben", PunchId = 1, Time = "ss", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" }

        //};
        //public static List<Puns2> punch2 = new List<Puns2>
        //{
        //    new Puns2 { Id = 1, Name = "Alan", PunchId = 2, Time = "ss", PunchIn = DateTime.Now, PunchOut = DateTime.Now, Hours = "" }

        //};

        private readonly DataContext _context;
        public EmploysController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<List<Emplo>>> GetEmployees()
        {
            var emps = await _context.Employees.ToListAsync();
            return Ok(emps);
        }

        [HttpGet("ps1")]
        public async Task<ActionResult<List<Puns1>>> GetPunch1()
        {
            var ps1 = await _context.Punchs1.ToListAsync();
            Console.WriteLine(ps1);
            return Ok(ps1);
        }

        [HttpGet("ps2")]
        public async Task<ActionResult<List<Puns1>>> GetPunch2()
        {
            var ps2 = await _context.Punchs2.ToListAsync();
            return Ok(ps2);
        }

        [HttpGet("ps1/{id}")]
        public async Task<ActionResult<Puns1>> GetSingleEmpPun1(int id)
        {

            var ps1 = await _context.Punchs1
                .FirstOrDefaultAsync(h => h.Id == id);
            if (ps1 == null)
            {
                return NotFound("找不到");
            }
            return Ok(ps1);
        }

        [HttpGet("ps2/{id}")]
        public async Task<ActionResult<Puns1>> GetSingleEmpPun2(int id)
        {

            var ps2 = await _context.Punchs2
                .FirstOrDefaultAsync(h => h.Id == id);
            if (ps2 == null)
            {
                return NotFound("找不到");
            }
            return Ok(ps2);
        }

        [HttpPost("ps1")]
        public async Task<ActionResult<List<Puns1>>> CreatePunIn1(Puns1 punch)
        {
            // punchRecs<list> 把 punch(單筆) 加進來 return 回去            
            _context.Punchs1.Add(punch);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPunRec1());
        }

        private async Task<List<Puns1>> GetDbPunRec1()
        {
            return await _context.Punchs1.ToListAsync();
        }

        [HttpPost("ps2")]
        public async Task<ActionResult<List<Puns2>>> CreatePunIn2(Puns2 punch)
        {
            // punchRecs<list> 把 punch(單筆) 加進來 return 回去            
            _context.Punchs2.Add(punch);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPunRec2());
        }

        private async Task<List<Puns2>> GetDbPunRec2()
        {
            return await _context.Punchs2.ToListAsync();
        }

        [HttpPut("ps1/{id}")]
        public async Task<ActionResult<List<Puns1>>> UpdatePunch1(Puns1 puns1, int id)
        {
            var dbPun = await _context.Punchs1
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbPun == null)
                return NotFound("Sorry");

            dbPun.PunchOut = puns1.PunchOut;
            dbPun.Hours = puns1.Hours;

            await _context.SaveChangesAsync();

            return Ok(await GetDbPunRec1());
        }

        [HttpPut("ps2/{id}")]
        public async Task<ActionResult<List<Puns1>>> UpdatePunch2(Puns2 puns2, int id)
        {
            var dbPun = await _context.Punchs2
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbPun == null)
                return NotFound("Sorry");

            dbPun.PunchOut = puns2.PunchOut;
            dbPun.Hours = puns2.Hours;

            await _context.SaveChangesAsync();

            return Ok(await GetDbPunRec2());
        }

    }
}
