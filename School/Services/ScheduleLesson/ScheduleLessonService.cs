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
    public class ScheduleLessonService
    {
        UnitOfWork unitOfWork;
        Generic<ScheduleLesson> ScheduleLessonRepo;
        public ScheduleLessonService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            ScheduleLessonRepo = unitOfWork.ScheduleLessonRepo;
        }
        public ScheduleLessonEditViewModel Add(ScheduleLessonEditViewModel ScheduleLessonEditViewModel)
        {
            ScheduleLesson ScheduleLesson = ScheduleLessonRepo.Add(ScheduleLessonEditViewModel.ToModel());
            unitOfWork.commit();
            return ScheduleLesson.ToEditableViewModel();
        }
        public ScheduleLessonEditViewModel Update(ScheduleLessonEditViewModel ScheduleLessonEditViewModel)
        {
            ScheduleLesson ScheduleLesson = ScheduleLessonRepo.Update(ScheduleLessonEditViewModel.ToModel());
            unitOfWork.commit();
            return ScheduleLesson.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            ScheduleLessonRepo.Remove(ScheduleLessonRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<ScheduleLessonViewModel> Get(int id)
        {
            return ScheduleLessonRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<ScheduleLessonViewModel> GetAll()
        {
            return ScheduleLessonRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public ScheduleLessonViewModel GetByID(int id)
        {
            return ScheduleLessonRepo.GetByID(id).ToViewModel();
        }
    }
}
