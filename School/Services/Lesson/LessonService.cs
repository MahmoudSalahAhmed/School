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
    public class LessonService
    {
        UnitOfWork unitOfWork;
        Generic<Lesson> LessonRepo;
        public LessonService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            LessonRepo = unitOfWork.LessonRepo;
        }
        public LessonEditViewModel Add(LessonEditViewModel LessonEditViewModel)
        {
            Lesson Lesson = LessonRepo.Add(LessonEditViewModel.ToModel());
            unitOfWork.commit();
            return Lesson.ToEditableViewModel();
        }
        public LessonEditViewModel Update(LessonEditViewModel LessonEditViewModel)
        {
            Lesson Lesson = LessonRepo.Update(LessonEditViewModel.ToModel());
            unitOfWork.commit();
            return Lesson.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            LessonRepo.Remove(LessonRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<LessonViewModel> Get(int id)
        {
            return LessonRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<LessonViewModel> GetAll()
        {
            return LessonRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public LessonViewModel GetByID(int id)
        {
            return LessonRepo.GetByID(id).ToViewModel();
        }
    }
}
