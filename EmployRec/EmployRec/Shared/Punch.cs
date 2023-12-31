﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployRec.Shared
{
    public class Puns1
    {
        public int Id { get; set; }
        public int PunchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
        public string Hours { get; set; } = string.Empty;
    }

    public class Puns2
    {
        public int Id { get; set; }
        public int PunchId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
        public string Hours { get; set; } = string.Empty;
    }
}
