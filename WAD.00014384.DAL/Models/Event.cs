using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD._00014384.DAL.Models
{
    public class Event : BaseModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
    }
}
