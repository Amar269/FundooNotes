using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Collaborator;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repository
{
    public class CollaboratorDAL : ICollaboratorDAL
    {
        private readonly UserDbContext _dbContext;

        public CollaboratorDAL(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CollaboratorResponse AddCollaborator(int ownerUserId, int noteId, string email)
        {
            var collaboratorUser = _dbContext.Users
         .FirstOrDefault(x => x.Email == email);

            if (collaboratorUser == null)
            {
                throw new Exception("User not found");
            }

            Console.WriteLine(ownerUserId + " "+ collaboratorUser.UserId);
            var collaborator = new Collaborator
            {
                OwnerUserId = ownerUserId,
                CollaboratorUserId = collaboratorUser.UserId,
                NoteId = noteId,
                CreatedAt = DateTime.Now,
                Email = email,
                Permission = "VIEW"
            };

            _dbContext.Collaborators.Add(collaborator);
            _dbContext.SaveChanges();

            return new CollaboratorResponse
            {
                CollaboratorId = collaborator.CollaboratorId,
                OwnerUserId = collaborator.OwnerUserId,
                CollaboratorUserId = collaborator.CollaboratorUserId,
                NoteId = collaborator.NoteId,
                Email = collaborator.Email,
                Permission = collaborator.Permission
            };
        }

        public List<GetCollaboratorResponse> GetCollaborators(int noteId)
        {
            return _dbContext.Collaborators
        .Where(x => x.NoteId == noteId)
        .Select(x => new GetCollaboratorResponse
        {
            CollaboratorId = x.CollaboratorId,
            CollaboratorUserId = x.CollaboratorUserId,
            Email = x.Email,
            Permission = x.Permission
        })
        .ToList();
        }

        public bool RemoveCollaborator(int collaboratorId)
        {
            var collaborator = _dbContext.Collaborators
        .FirstOrDefault(x => x.CollaboratorId == collaboratorId);

            if (collaborator == null)
            {
                throw new Exception("Collaborator not found");
            }

            _dbContext.Collaborators.Remove(collaborator);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
