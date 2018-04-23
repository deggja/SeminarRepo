using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seminarapi.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public List<Participant> Participants { get; set; }
        public List<Instructor> Instructors { get; set; }
        
    }
}
