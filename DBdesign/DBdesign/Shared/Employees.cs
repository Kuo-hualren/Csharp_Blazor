using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBdesign.Shared
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public List<Punchs1>? Punch1 { get; set; }
        public List<Punchs2>? Punch2 { get; set; }

        public int PunchId { get; set; }
    }
}
