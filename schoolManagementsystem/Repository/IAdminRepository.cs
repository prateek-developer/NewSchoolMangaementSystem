using schoolManagementsystem.Models;
using schoolManagementsystem.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace schoolManagementsystem.Repository
{
    public interface IAdminRepository
    {

        Task<List<TeachersDetailViewModel>> GetAllTeacherAsync();

        Task<TeachersDetailViewModel> GetTeacherIdAsync(int TeacherId);
        
        Task<TeachersDetailViewModel> GetTeacherNameAsync(string Name);
        Task<TeachersDetail> AddTeacherAsync(TeachersDetailViewModel teacher);

        Task UpdateTeacherAsync(int teacherId, TeachersDetailViewModel teacher);
        // Task UpdateTeacherByNameAsync(string Name, TeachersDetailViewModel teacher);



        Task DeleteTeacherAsync(string email);




        //***************** Notice ******************//

        Task<List<NoticeViewModel>> GetAllNoticeAsync();
        Task<NoticeViewModel> GetNoticeIdAsync(int noticeId);
        Task<int> AddNoticeAsync(NoticeViewModel Notice);

        Task DeleteNoticeAsync(int Id);



        //**** student***********//
       Task<List<StudentDetailViewModel>> GetAllStudentAsync();
        Task<StudentDetailViewModel> GetStudentIdAsync(int StudentId);

        Task<StudentDetailViewModel> GetStudentClassIdAsync(int ClassId);

       Task<StudentDetailViewModel> GetStudentemailAsync(string Email);

        Task<StudentDetail> AddStudentAsync(StudentDetailViewModel student);


        Task DeleteStudentAsync(string email);
        Task UpdateStudentAsync(string email, StudentDetailViewModel student);

        Task<bool> checkEmailAsync(string username);
        Task<bool> checkTeacherEmail(string username);


    }
}
