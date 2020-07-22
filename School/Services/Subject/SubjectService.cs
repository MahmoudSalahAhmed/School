using Entities.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services
{
    public class SubjectService
    {
        UnitOfWork unitOfWork;
        Generic<Subject> SubjectRepo;
        public SubjectService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            SubjectRepo = unitOfWork.SubjectRepo;
        }
        public SubjectEditViewModel Add(SubjectEditViewModel SubjectEditViewModel)
        {
            Subject Subject = SubjectRepo.Add(SubjectEditViewModel.ToModel());
            unitOfWork.commit();
            return Subject.ToEditableViewModel();
        }
        public SubjectEditViewModel Update(SubjectEditViewModel SubjectEditViewModel)
        {
            Subject Subject = SubjectRepo.Update(SubjectEditViewModel.ToModel());
            unitOfWork.commit();
            return Subject.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            SubjectRepo.Remove(SubjectRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<SubjectViewModel> Get(int id)
        {
            return SubjectRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<SubjectViewModel> GetAll()
        {
            return SubjectRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public SubjectViewModel GetByID(int id)
        {
            return SubjectRepo.GetByID(id).ToViewModel();
        }
    }
}
