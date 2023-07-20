using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBdesign.Shared
{
    public class Punchs1
    {
        public int Id { get; set; }
        public int PunchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
        public string Hours { get; set; } = string.Empty;
        //public Employees? Employee { get; set; }
    }

    public class Punchs2
    {
        public int Id { get; set; }
        public int PunchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
        public string Hours { get; set; } = string.Empty;
        //public Employees? Employee { get; set; }
    }

}
