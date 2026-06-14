using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entity
{
     public  class Collaborator
    {
        [Key]
        public int CollaboratorId { get; set; }

        [Required]
        public int OwnerUserId { get; set; }

        [Required]
        public int CollaboratorUserId { get; set; }

        [Required]
        public int NoteId { get; set; }

        public string Email { get; set; }
        public string Permission { get; set; } = "VIEW";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("OwnerUserId")]
        public virtual User OwnerUser { get; set; }

        [ForeignKey("CollaboratorUserId")]
        public virtual User CollaboratorUser { get; set; }

        [ForeignKey("NoteId")]
        public virtual Notes Note { get; set; }
    }
}
