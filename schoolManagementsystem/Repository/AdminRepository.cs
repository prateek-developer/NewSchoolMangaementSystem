using Microsoft.EntityFrameworkCore;
using schoolManagementsystem.helpers;
using schoolManagementsystem.Models;
using schoolManagementsystem.ViewModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace schoolManagementsystem.Repository
{
    public class AdminRepository : IAdminRepository
    {

        private readonly SchoolManagementContext db;


        public AdminRepository(SchoolManagementContext _dbContext)
        {
            db = _dbContext;


        }
        //TEACHER RELATED FUNCTIONALITIES
        public async Task<List<TeachersDetailViewModel>> GetAllTeacherAsync()
        {
            //return await db.TeachersDetail.ToListAsync();

            return await (from t in db.TeachersDetails
                        

                          select new TeachersDetailViewModel
                          {
                              TeacherId = t.TeacherId,
                              Name = t.Name,
                              Email=t.Email,
                            
                              SubjectTaught = t.SubjectTaught,
                              Salary = t.Salary,
                              Dob = t.Dob,


                          }).ToListAsync();

            

        }


        public async Task<TeachersDetailViewModel> GetTeacherIdAsync(int TeacherId)
        {


            var records = await db.TeachersDetails.Where(x => x.TeacherId == TeacherId).Select(x => new TeachersDetailViewModel()
            {

                TeacherId = x.TeacherId,
                Name = x.Name,
                Salary = x.Salary,
                SubjectTaught = x.SubjectTaught,
                Dob = x.Dob,
            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<TeachersDetailViewModel> GetTeacherNameAsync(string Name)
        {


            var records = await db.TeachersDetails.Where(x => x.Name == Name).Select(x => new TeachersDetailViewModel()
            {

                TeacherId = x.TeacherId,
                Name = x.Name,
                Salary = x.Salary,
                SubjectTaught = x.SubjectTaught,
                Dob = x.Dob,
            }).FirstOrDefaultAsync();
            return records;
        }



        public async Task<TeachersDetail> AddTeacherAsync(TeachersDetailViewModel teacher )
        {
            var teachers = new TeachersDetail()
            {

                Name = teacher.Name,
                Salary = (int)teacher.Salary,
                SubjectTaught = teacher.SubjectTaught,
                Dob = (System.DateTime)teacher.Dob,
                Email = teacher.Email,
                Password = teacher.Password,
                
            };


            db.TeachersDetails.Add(teachers);

            await db.SaveChangesAsync();



            teacher.Password = PasswordHasher.HashPassword(teacher.Password);



            var User = new LoginDetail()
            {
                Username = teacher.Email,
                Password = teacher.Password,
                IsApproved = true,
                UserRole = "teacher",
                Token = "1",
                TokenExpired = 0,

            };
           teacher.Password = PasswordHasher.HashPassword(teacher.Password);
         

            db.LoginDetails.Add(User);
            await db.SaveChangesAsync();
            return teachers;


        }



        public async Task UpdateTeacherAsync(int teacherId, TeachersDetailViewModel teacher)
        {


            var teachers = new TeachersDetail()
            {
                TeacherId = teacherId,
                Name = teacher.Name,
                Salary = (int)teacher.Salary,
                SubjectTaught = teacher.SubjectTaught,
                Dob = (System.DateTime)teacher.Dob,
                Email= teacher.Email,
                Password= teacher.Password,
            };

            teacher.Password = PasswordHasher.HashPassword(teacher.Password);
            db.TeachersDetails.Update(teachers);

            await db.SaveChangesAsync();


            var User = new LoginDetail()
            {
                Username = teacher.Email,
                Password = teacher.Password,
                IsApproved = true,
                UserRole = "teacher",
                Token = "1",
                TokenExpired = 0,

            };

            teacher.Password = PasswordHasher.HashPassword(teacher.Password);

            db.LoginDetails.Add(User);
            await db.SaveChangesAsync();
            
           


        }


        public async Task DeleteTeacherAsync(string email)
        {
            var teachers = db.TeachersDetails.Where(x => x.Email == email).FirstOrDefault();
            db.TeachersDetails.Remove(teachers);
            var user = db.LoginDetails.Where(x => x.Username == email).FirstOrDefault();
            db.LoginDetails.Remove(user);
            await db.SaveChangesAsync();

        }

    



        //Notice Functions



        public async Task<List<NoticeViewModel>> GetAllNoticeAsync()
        {

            return await (from n in db.Notices
                          from l in db.LoginDetails
                          where n.IssuedBy == l.LoginId
                          select new NoticeViewModel
                          {
                              NoticeId = n.NoticeId,
                              NoticeDetails = n.NoticeDetails,


                              IssuedOn = n.IssuedOn,
                              IssuedBy = n.IssuedBy

                          }).ToListAsync();



        }


        public async Task<NoticeViewModel> GetNoticeIdAsync(int noticeId)
        {


            var records = await db.Notices.Where(x => x.NoticeId == noticeId).Select(x => new NoticeViewModel()
            {
                NoticeId = x.NoticeId,
                NoticeDetails = x.NoticeDetails,

                IssuedOn = x.IssuedOn,
                IssuedBy = x.IssuedBy,
            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<int> AddNoticeAsync(NoticeViewModel Notice)
        {
            var new_notice =
                              new Notice()
                              {
                                  NoticeDetails = Notice.NoticeDetails,

                                  IssuedOn = (System.DateTime)Notice.IssuedOn,
                                  IssuedBy = (int)Notice.IssuedBy,

                              };
            db.Notices.Add(new_notice);

            await db.SaveChangesAsync();

            return Notice.NoticeId;


        }


        public async Task DeleteNoticeAsync(int Id)
        {
            var notice = db.Notices.Where(x => x.NoticeId == Id).FirstOrDefault();
            db.Notices.Remove(notice);
            await db.SaveChangesAsync();

        }




        //********************** STUDENT RELATED FUNCTIONS ************************//



        public async Task<List<StudentDetailViewModel>> GetAllStudentAsync()
        {


            return await (from s in db.StudentDetails
                         

                          select new StudentDetailViewModel
                          {
                              StudentId = s.StudentId,
                              Email = s.Email,
                              Password = s.Password,
                              Dob = s.Dob,
                              DateOfJoining = s.DateOfJoining,
                              ClassId = s.ClassId,
                              PhoneNo = s.PhoneNo,
                              Status = s.Status,
                              LoginId = s.LoginId,
                              Name = s.Name


                          }).ToListAsync();



        }


        public async Task<StudentDetailViewModel> GetStudentIdAsync(int StudentId)
        {


            var records = await db.StudentDetails.Where(x => x.StudentId == StudentId).Select(x => new StudentDetailViewModel()
            {
                StudentId = x.StudentId,
                Email = x.Email,
                Password = x.Password,
                Dob = x.Dob,
                PhoneNo = x.PhoneNo,
                DateOfJoining = x.DateOfJoining,
                ClassId = x.ClassId,
            }).FirstOrDefaultAsync();
            return records;
        }


        public async Task<StudentDetailViewModel> GetStudentClassIdAsync(int ClassId)
        {


            var records = await db.StudentDetails.Where(x => x.ClassId == ClassId).Select(x => new StudentDetailViewModel()
            {
                StudentId = x.StudentId,
                Email = x.Email,
                Password = x.Password,
                Dob = x.Dob,
                PhoneNo = x.PhoneNo,
                DateOfJoining = x.DateOfJoining,
                ClassId = x.ClassId,
            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<StudentDetailViewModel> GetStudentemailAsync(string Email)
        {


            var records = await db.StudentDetails.Where(x => x.Email == Email).Select(x => new StudentDetailViewModel()
            {
                StudentId = x.StudentId,
                Email = x.Email,
                ClassId = x.ClassId,
                PhoneNo = x.PhoneNo,
                DateOfJoining = x.DateOfJoining,
                Dob = x.Dob,
            }).FirstOrDefaultAsync();
            return records;
        }



        public async Task<StudentDetail> AddStudentAsync(  StudentDetailViewModel student)
        {
            var Students = new StudentDetail()
            {
                Name=student.Name,
                StudentId=student.StudentId,
                Email = student.Email,
                ClassId = (int)student.ClassId,
                Password=student.Password,
                PhoneNo = (int)student.PhoneNo,
                DateOfJoining = (System.DateTime)student.DateOfJoining,
                Dob = (System.DateTime)student.Dob,
                Status= (int)student.Status


            };
            student.Password = PasswordHasher.HashPassword(student.Password);


            db.StudentDetails.Add(Students);

            await db.SaveChangesAsync();


            var User = new LoginDetail()
            {
                
                Username =student.Email,
                Password = student.Password,
                IsApproved=true,
                UserRole="student",
                Token="1",
                TokenExpired= 0,

            };
            student.Password = PasswordHasher.HashPassword(student.Password);
            db.LoginDetails.Add(User);




            await db.SaveChangesAsync();


            return Students;




        }


        //chech username i.e email
        public async Task<bool> checkEmailAsync(string username)
        {
            return await db.StudentDetails.AnyAsync(x => x.Email == username);
            
           }


        public async Task<bool> checkTeacherEmail(string username)
        {
            return await db.TeachersDetails.AnyAsync(x=> x.Email == username);
        }


        public async Task DeleteStudentAsync(string email)
        {
            var student = db.StudentDetails.Where(x => x.Email == email).FirstOrDefault();
            db.StudentDetails.Remove(student);
            var user = db.LoginDetails.Where(x => x.Username == email).FirstOrDefault();
            db.LoginDetails.Remove(user);
            await db.SaveChangesAsync();

        }



        public async Task UpdateStudentAsync(string email, StudentDetailViewModel student)
        {

            
            var students = new StudentDetail()
            {
                
                Email = student.Email,
                LoginId = (int)student.LoginId,
                Password= student.Password,
                DateOfJoining= (System.DateTime)student.DateOfJoining,
                Dob= (System.DateTime)student.Dob,
                Status= (int)student.Status,
                PhoneNo= (int)student.PhoneNo,
               



            };
            student.Password = PasswordHasher.HashPassword(student.Password);
            db.StudentDetails.Update(students);

            await db.SaveChangesAsync();

            var User = new LoginDetail()
            {

                Username = student.Email,
                Password = student.Password,
                IsApproved = true,
                UserRole = "student",
                Token = "1",
                TokenExpired = 0,

            };

            student.Password = PasswordHasher.HashPassword(student.Password);

            db.LoginDetails.Add(User);




            await db.SaveChangesAsync();


        }


      




    }
}
