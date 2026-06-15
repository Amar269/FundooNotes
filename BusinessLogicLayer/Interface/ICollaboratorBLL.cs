using ModelLayer.DTO.Collaborator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface ICollaboratorBLL
    {
        CollaboratorResponse AddCollaborator( int ownerUserId,int noteId,string email);

        List<GetCollaboratorResponse> GetCollaborators(int noteId);

        bool RemoveCollaborator(int collaboratorId);

        CollaboratorResponse UpdatePermission(int collaboratorId, string permission);

    }
}
