using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Notes
{
    public class NoteResponse  // outgoing layer
    {
        public int NotesId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Reminder { get; set; }

        public string Colour { get; set; }

        public string Image { get; set; }

        public bool IsArchive { get; set; }

        public bool IsPin { get; set; }

        public bool IsTrash { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int UserId { get; set; }
    }
}
