using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers.Models
{
    public class Salary
    {
        public int SalaryID { get; set; }

        public int WorkerID { get; set; }

        public int PositionID { get; set; }

        public int Bonus { get; set; }

        public Worker Worker { get; set; }
        public Position Position { get; set; }
    }
}
