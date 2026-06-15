using ModelLayer.DTO.Collaborator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public interface ICollaboratorDAL
    {
        
            CollaboratorResponse AddCollaborator(int ownerUserId,int noteId,string email);

             List<GetCollaboratorResponse> GetCollaborators(int noteId);

    }
}
