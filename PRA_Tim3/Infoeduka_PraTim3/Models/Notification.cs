using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoeduka_PraTim3.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int CreatorId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime PublishDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
