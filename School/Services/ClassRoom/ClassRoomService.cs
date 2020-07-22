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
    public class ClassRoomService
    {
        UnitOfWork unitOfWork;
        Generic<ClassRoom> ClassRoomRepo;
        public ClassRoomService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            ClassRoomRepo = unitOfWork.ClassRoomRepo;
        }
        public ClassRoomEditViewModel Add(ClassRoomEditViewModel ClassRoomEditViewModel)
        {
            ClassRoom ClassRoom = ClassRoomRepo.Add(ClassRoomEditViewModel.ToModel());
            unitOfWork.commit();
            return ClassRoom.ToEditableViewModel();
        }
        public ClassRoomEditViewModel Update(ClassRoomEditViewModel ClassRoomEditViewModel)
        {
            ClassRoom ClassRoom = ClassRoomRepo.Update(ClassRoomEditViewModel.ToModel());
            unitOfWork.commit();
            return ClassRoom.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            ClassRoomRepo.Remove(ClassRoomRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<ClassRoomViewModel> Get(int id)
        {
            return ClassRoomRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<ClassRoomViewModel> GetAll()
        {
            return ClassRoomRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public ClassRoomViewModel GetByID(int id)
        {
            return ClassRoomRepo.GetByID(id).ToViewModel();
        }
    }
}
