using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD._00014384.DAL.DTOs
{
    public class CreateEventDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }
}
