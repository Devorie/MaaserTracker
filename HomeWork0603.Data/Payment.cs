using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork0603.Data
{
    public class Payment
    {
        public int Id { get; set; }
        public string Recipient { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
