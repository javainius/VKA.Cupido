using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKA.Cupido.Entities
{
    public class PairEntity
    {
        public int Id { get; set; }
        public ContactEntity FirstPerson { get; set; }
        public ContactEntity SecondPerson { get; set; }
    }
}
