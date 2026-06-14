using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Collaborator
{
    public class CollaboratorResponse
    {
        public int CollaboratorId { get; set; }

        public string Email { get; set; }

        public int OwnerUserId { get; set; }

        public int CollaboratorUserId { get; set; }

        public int NoteId { get; set; }

        public string Permission { get; set; }
    }
}
