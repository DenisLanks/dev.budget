﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dev.budget.Models
{
    public class ResponseTO
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }
    }
}
