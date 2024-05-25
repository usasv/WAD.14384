using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD._00014384.DAL.Models
{
    public class Attendee : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
