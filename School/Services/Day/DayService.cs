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
    public class DayService
    {
        UnitOfWork unitOfWork;
        Generic<Day> DayRepo;
        public DayService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            DayRepo = unitOfWork.DayRepo;
        }
        public DayEditViewModel Add(DayEditViewModel DayEditViewModel)
        {
            Day Day = DayRepo.Add(DayEditViewModel.ToModel());
            unitOfWork.commit();
            return Day.ToEditableViewModel();
        }
        public DayEditViewModel Update(DayEditViewModel DayEditViewModel)
        {
            Day Day = DayRepo.Update(DayEditViewModel.ToModel());
            unitOfWork.commit();
            return Day.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            DayRepo.Remove(DayRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<DayViewModel> Get(int id)
        {
            return DayRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<DayViewModel> GetAll()
        {
            return DayRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public Day GetByID(int id)
        {
            return DayRepo.GetByID(id);
        }
    }
}
