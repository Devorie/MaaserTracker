using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork0603.Data
{
    public class Income
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public Source Source { get; set; }
    }
}
