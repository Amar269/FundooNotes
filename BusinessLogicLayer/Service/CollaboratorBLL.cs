using BusinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Collaborator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CollaboratorBLL : ICollaboratorBLL
    {
        private readonly ICollaboratorDAL _collaboratorDAL;

        public CollaboratorBLL(ICollaboratorDAL collaboratorDAL)
        {
            _collaboratorDAL = collaboratorDAL;
        }
        public CollaboratorResponse AddCollaborator(int ownerUserId, int noteId, string email)
        {
            return _collaboratorDAL.AddCollaborator(ownerUserId, noteId, email);
        }

        public List<GetCollaboratorResponse> GetCollaborators(int noteId)
        {
            if (noteId <= 0)
            {
                throw new Exception("Invalid Note Id");
            }

            return _collaboratorDAL.GetCollaborators(noteId);
        }

        public bool RemoveCollaborator(int collaboratorId)
        {
            return _collaboratorDAL.RemoveCollaborator(collaboratorId);
        }
    }
}
