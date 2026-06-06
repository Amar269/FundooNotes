using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using ModelLayer.DTO.Label;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repository
{
    public class LabelDAL : ILabelDAL
    {

        private readonly UserDbContext _dbcontext;
        public LabelDAL (UserDbContext dbcontext)     
        {
            _dbcontext = dbcontext;
        }

        public bool CreateLabel(int userId, CreateLabelRequest request)
        {
            Label label = new Label()
            {
                LabelName = request.LabelName,
                UserId = userId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _dbcontext.Labels.Add(label);
            _dbcontext.SaveChanges();


            NoteLabel noteLabel = new NoteLabel
            {
                LabelId = label.LabelId,
                NoteId = request.NoteId,
                CreatedAt = DateTime.Now

            };
            _dbcontext.NoteLabels.Add(noteLabel);
            _dbcontext.SaveChanges();
             return true;

        }
    }
}
