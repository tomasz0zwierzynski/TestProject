using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Workers.Models
{
    public class Position
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PositionID { get; set; }
        public string Name { get; set; }

        public int Amount { get; set; }

        public ICollection<Salary> Salaries { get; set; }
    }
}
