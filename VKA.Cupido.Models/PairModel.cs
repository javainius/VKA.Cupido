using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKA.Cupido.Models
{
    public class PairModel
    {
        public PairModel(PersonModel firstPerson, PersonModel secondPerson, DateOnly whenPaired)
        {
            FirstPerson = firstPerson;
            SecondPerson = secondPerson;
            WhenPaired = whenPaired;
        }

        public int Id { get; set; }
        public DateOnly WhenPaired { get; set; }
        public PersonModel FirstPerson { get; set; }
        public PersonModel SecondPerson { get; set; }
    }
}
