﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutGame.Models.Domain
{
    public class StudentClass
    {
        public String ClassName { get; set; }
        public IEnumerable<Student> Students { get; set; }
      
    }
}
