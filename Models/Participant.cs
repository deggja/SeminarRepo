using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seminarapi.Models
{
    public class Participant
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
