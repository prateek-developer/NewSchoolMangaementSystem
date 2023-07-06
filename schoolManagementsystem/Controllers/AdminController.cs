using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using schoolManagementsystem.Models;
using schoolManagementsystem.Repository;
using schoolManagementsystem.ViewModel;
using System.Threading.Tasks;

namespace schoolManagementsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        //********* TEACHERS OPERATION ************//

        // GET ALL TEACHERS
        [HttpGet("teachers")]

        public async Task<IActionResult> GetAllTeacher()
        {
            var teachers = await _adminRepository.GetAllTeacherAsync();
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }



        //GET TEACHER BY ID
        [HttpGet("teacher/{id}")]

        public async Task<IActionResult> GetTeacherByID([FromRoute] int id)
        {
            var teachers = await _adminRepository.GetTeacherIdAsync(id);
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }

        [HttpGet("teachers/{Name}")]

        public async Task<IActionResult> GetTeacherByName([FromRoute] string Name)
        {
            var teachers = await _adminRepository.GetTeacherNameAsync(Name);
            if (teachers == null)
            {
                return NotFound();
            }
            return Ok(teachers);
        }




        [HttpPost("")]


        public async Task<IActionResult> AddTeacher([FromBody] TeachersDetailViewModel teacher)
        {

            if (await _adminRepository.checkTeacherEmail(teacher.Email))
                return BadRequest(new
                {
                    Message = "username already exist"
                });

            var id = await _adminRepository.AddTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherByID), new { id = id, Controller = "Admin" }, id);
        }



        [HttpPut("teacher/{teacherId}")]

        public async Task<IActionResult> updateBook([FromBody] TeachersDetailViewModel teachersViewModel, [FromRoute] int teacherId)
        {
            await _adminRepository.UpdateTeacherAsync(teacherId, teachersViewModel);
            return Ok();
        }


        /* [HttpPut("teachers/{Name}")]

          public async Task<IActionResult> updateTeacher([FromBody] TeachersDetailViewModel teachersViewModel, [FromRoute] string Name)
          {
              await _adminRepository.UpdateTeacherByNameAsync(Name, teachersViewModel);
              return Ok();
          }*/

        //DELETE TEACHER BY NAME
        [HttpDelete("{email}")]

        public async Task<IActionResult> DeleteTeacher([FromRoute] string email)
        {
            await _adminRepository.DeleteTeacherAsync($"{email}");
            return Ok();
        }





        //*************** NOTICES *******************//
        [HttpGet("Notices")]

        public async Task<IActionResult> GetAllNotice()
        {
            var notice = await _adminRepository.GetAllNoticeAsync();
            if (notice == null)
            {
                return NotFound();
            }
            return Ok(notice);
        }


        [HttpGet("Notice/{id}")]

        public async Task<IActionResult> GetNoticeByID([FromRoute] int id)
        {
            var notice = await _adminRepository.GetNoticeIdAsync(id);
            if (notice == null)
            {
                return NotFound();
            }
            return Ok(notice);
        }

        [HttpPost("Notice/")]


        public async Task<IActionResult> AddNotice([FromBody] NoticeViewModel notice)
        {
            var id = await _adminRepository.AddNoticeAsync(notice);
            return CreatedAtAction(nameof(GetNoticeByID), new { id = id, Controller = "Admin" }, id);
        }



        [HttpDelete("Notice/{id}")]

        public async Task<IActionResult> DeleteNotice([FromRoute] int id)
        {
            await _adminRepository.DeleteNoticeAsync(id);
            return Ok();
        }


        //******************** Student ***********************//

        [HttpGet("Students")]

        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _adminRepository.GetAllStudentAsync();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }




        [HttpGet("student/{id}")]

        public async Task<IActionResult> GetStudentByID([FromRoute] int id)
        {
            var students = await _adminRepository.GetStudentIdAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }


        [HttpGet("student/class/{id}")]

        public async Task<IActionResult> GetStudentByClassID([FromRoute] int id)
        {
            var students = await _adminRepository.GetStudentClassIdAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        [HttpGet("studentss/{Email}")]

        public async Task<IActionResult> GetStudentByemail([FromRoute] string Email)
        {
            var students = await _adminRepository.GetStudentemailAsync(Email);
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }




        [HttpPost("student/")]


        public async Task<IActionResult> AddStudent( [FromBody] StudentDetailViewModel student )
        {

           if(  await _adminRepository.checkEmailAsync(student.Email))
                return BadRequest(new
                { 
                    Message = "username already exist"
                });
           
            
            var id = await _adminRepository.AddStudentAsync( student);
            return CreatedAtAction(nameof(GetStudentByID), new { id = id, Controller = "Admin" }, id);
        }



        [HttpPut("student/{email}")]

        public async Task<IActionResult> updateStudent([FromRoute] string email, [FromBody] StudentDetailViewModel studentViewModel)
        {
            await _adminRepository.UpdateStudentAsync(email, studentViewModel);
            return Ok();
        }



        [HttpDelete("student/{name}")]

        public async Task<IActionResult> DeleteStudent([FromBody] string name)
        {
            await _adminRepository.DeleteStudentAsync($"{name}");
            return Ok();
        }




        //**************** LOGIN ***************//











    }
}
