﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKA.Cupido.Entities
{
    public class PairEntity
    {
        public int Id { get; set; }
        public DateOnly WhenPaired { get; set; }
        public PersonEntity FirstPerson { get; set; }
        public PersonEntity SecondPerson { get; set; }
    }
}
