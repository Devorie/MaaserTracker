﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HomeWork0603.Data
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public List<Income> Incomes { get; set; }
    }
}
