using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Notes
{
    public class CreateNoteRequest // incoming layer 
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Reminder { get; set; }

        public string Colour { get; set; }

        public string Image { get; set; }
    }
}
