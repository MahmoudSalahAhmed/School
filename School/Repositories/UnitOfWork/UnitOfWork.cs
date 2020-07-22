using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork
    {
        private EntitiesContext context;
        public Generic<User> UserRepo { get; set; }
        public Generic<Admin> AdminRepo { get; set; }
        public Generic<Teacher> TeacherRepo { get; set; }
        public Generic<Student> StudentRepo { get; set; }
        public Generic<ClassRoom> ClassRoomRepo { get; set; }
        public Generic<Lesson> LessonRepo { get; set; }
        public Generic<Subject> SubjectRepo { get; set; }
        public Generic<Day> DayRepo { get; set; }
        public Generic<Schedule> ScheduleRepo { get; set; }
        public Generic<ScheduleLesson> ScheduleLessonRepo { get; set; }

        /////////////////
        public UnitOfWork(
         EntitiesContext _context,
         Generic<User> userRepo,
         Generic<Admin> adminRepo,
         Generic<Teacher> teacherRepo,
         Generic<Student> studentRepo,
         Generic<ClassRoom> classRoomRepo,
         Generic<Subject> subjectRepo,
         Generic<Day> dayRepo,
         Generic<Lesson> lessonRepo,
         Generic<Schedule> scheduleRepo,
         Generic<ScheduleLesson> scheduleLessonRepo

         )
        {
            context = _context;

            UserRepo = userRepo;
            UserRepo.Context = context;

            StudentRepo = studentRepo;
            StudentRepo.Context = context;

            AdminRepo = adminRepo;
            AdminRepo.Context = context;

            TeacherRepo = teacherRepo;
            TeacherRepo.Context = context;

            ClassRoomRepo = classRoomRepo;
            ClassRoomRepo.Context = context;

            SubjectRepo = subjectRepo;
            SubjectRepo.Context = context;

            DayRepo = dayRepo;
            DayRepo.Context = context;

            LessonRepo = lessonRepo;
            LessonRepo.Context = context;

            ScheduleRepo = scheduleRepo;
            ScheduleRepo.Context = context;

            ScheduleLessonRepo = scheduleLessonRepo;
            ScheduleLessonRepo.Context = context;
        }

        public int commit()
        {
            return context.SaveChanges();
        }
    }
}
