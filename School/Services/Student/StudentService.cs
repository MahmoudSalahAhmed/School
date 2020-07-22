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
    public class StudentService
    {
        UnitOfWork unitOfWork;
        Generic<Student> StudentRepo;
        Generic<User> UserRepo;
        public StudentService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            StudentRepo = unitOfWork.StudentRepo;
            UserRepo = unitOfWork.UserRepo; 
        }
        public StudentEditViewModel Add(StudentEditViewModel StudentEditViewModel)
        {
            Student Student = StudentRepo.Add(StudentEditViewModel.ToModel());
            unitOfWork.commit();
            return Student.ToEditableViewModel();
        }
        public StudentEditViewModel Update(StudentEditViewModel StudentEditViewModel)
        {
            Student Student = StudentRepo.Update(StudentEditViewModel.ToModel());
            UserRepo.Update(Student.User);
            unitOfWork.commit();
            return Student.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            Student stu = StudentRepo.GetByID(id);
            UserRepo.Remove(stu.User);
            StudentRepo.Remove(stu);
            unitOfWork.commit();
        }
        public IEnumerable<StudentViewModel> Get(int id)
        {
            return StudentRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<StudentViewModel> GetAll()
        {
            return StudentRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public StudentViewModel GetByID(int id)
        {
            return StudentRepo.GetByID(id).ToViewModel();
        }
    }
}
