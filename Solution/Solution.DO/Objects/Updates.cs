using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Objects
{
    public class Updates
    {
        public int UpdateId { get; set; }

        public string? Updatemsg { get; set; }

        public double? Status { get; set; }

        public int GoalId { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
