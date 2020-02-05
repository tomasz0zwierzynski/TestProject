using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workers.Models
{
    public class Worker
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public ICollection<Salary> Salaries { get; set; }
    }
}
