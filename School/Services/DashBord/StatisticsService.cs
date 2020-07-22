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
    public class StatisticsService
    {
        UnitOfWork unitOfWork;
        Generic<Lesson> LessonRepo;
        Generic<ClassRoom> ClassRoomRepo;
        Generic<Teacher> TeacherRepo;
        Generic<Student> StudentRepo;
        Generic<Subject> SubjectRepo;

        public StatisticsService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            LessonRepo = unitOfWork.LessonRepo;
            ClassRoomRepo = unitOfWork.ClassRoomRepo;
            TeacherRepo = unitOfWork.TeacherRepo;
            StudentRepo = unitOfWork.StudentRepo;
            SubjectRepo = unitOfWork.SubjectRepo;
        }



        public StatisticsViewModel GetStatistics()
        {
            StatisticsViewModel report = new StatisticsViewModel();
            report.Lessons = LessonRepo.GetAll().Count();
            report.ClassRooms = ClassRoomRepo.GetAll().Count();
            report.Teachers = TeacherRepo.GetAll().Count();
            report.Students = StudentRepo.GetAll().Count();
            report.Subjects = SubjectRepo.GetAll().Count();
            return report;
        }
    }
}
