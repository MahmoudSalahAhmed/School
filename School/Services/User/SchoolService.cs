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
    public class UserService
    {
        UnitOfWork unitOfWork;
        Generic<User> UserRepo;
        public UserService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            UserRepo = unitOfWork.UserRepo;
        }
        public UserEditViewModel Add(UserEditViewModel UserEditViewModel)
        {
            User User = UserRepo.Add(UserEditViewModel.ToModel());
            unitOfWork.commit();
            return User.ToEditableViewModel();
        }
        public UserEditViewModel Update(UserEditViewModel UserEditViewModel)
        {
            User User = UserRepo.Update(UserEditViewModel.ToModel());
            unitOfWork.commit();
            return User.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            UserRepo.Remove(UserRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<UserViewModel> Get(int id)
        {
            return UserRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<UserViewModel> GetAll()
        {
            return UserRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public User GetByID(int id)
        {
            return UserRepo.GetByID(id);
        }
    }
}
