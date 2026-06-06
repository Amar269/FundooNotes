using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entity
{
    public class Label
    {
        [Key]
        public int LabelId { get; set; }
        public string LabelName { get; set; }

        public DateTime  CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User user { get; set; }


    }
}
