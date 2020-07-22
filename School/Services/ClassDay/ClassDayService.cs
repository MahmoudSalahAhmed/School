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
    public class ScheduleService
    {
        UnitOfWork unitOfWork;
        Generic<Schedule> ScheduleRepo;
        public ScheduleService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            ScheduleRepo = unitOfWork.ScheduleRepo;
        }
        public ScheduleEditViewModel Add(ScheduleEditViewModel ScheduleEditViewModel)
        {
            Schedule Schedule = ScheduleRepo.Add(ScheduleEditViewModel.ToModel());
            unitOfWork.commit();
            return Schedule.ToEditableViewModel();
        }
        public ScheduleEditViewModel Update(ScheduleEditViewModel ScheduleEditViewModel)
        {
            Schedule Schedule = ScheduleRepo.Update(ScheduleEditViewModel.ToModel());
            unitOfWork.commit();
            return Schedule.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            ScheduleRepo.Remove(ScheduleRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<ScheduleViewModel> Get(int id)
        {
            return ScheduleRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<ScheduleViewModel> GetAll()
        {
            return ScheduleRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public ScheduleViewModel GetByID(int id)
        {
            return ScheduleRepo.GetByID(id).ToViewModel();
        }
    }
}
