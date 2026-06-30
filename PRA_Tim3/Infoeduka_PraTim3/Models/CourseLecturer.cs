using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoeduka_PraTim3.Models
{
    public class CourseLecturer
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int LecturerId { get; set; }

    }
}
