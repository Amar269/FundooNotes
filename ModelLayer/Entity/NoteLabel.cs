using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entity
{
    public class NoteLabel
    {
        [Key]
        public int NoteLabelId { get; set; }

        [ForeignKey("Notes")]
        public int NoteId { get; set; }

        public Notes notes { get; set; }

        [ForeignKey("Label")]
        public int LabelId { get; set; }

        public Label label { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
