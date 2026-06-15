using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.DTO.Collaborator
{
    public  class GetCollaboratorResponse
    {
        public int CollaboratorId { get; set; }

        public int CollaboratorUserId { get; set; }

        public string Email { get; set; }

        public string Permission { get; set; }
    }
}
