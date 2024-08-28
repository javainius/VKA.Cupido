using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKA.Cupido.Entities
{
    public class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FacebookProfileLink { get; set; }
        public string PhoneNumber { get; set; }
    }
}
