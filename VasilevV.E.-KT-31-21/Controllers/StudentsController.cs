using VasilevV.E._KT_31_21.Interfaces.StudentsInterfaces;
using VasilevV.E._KT_31_21.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace VasilevV.E._KT_31_21.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetStudents(CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsAsync(cancellationToken);
            return Ok(students);
        }


        [HttpPost("add-students", Name="AddStudents")]
        public async Task<IActionResult> AddStudent([FromBody] Student student, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var addedStudent = await _studentService.AddStudentAsync(student, cancellationToken);
            return CreatedAtAction(nameof(GetStudents), new { id = addedStudent.StudentId }, addedStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await _studentService.UpdateStudentAsync(id, student, cancellationToken);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id, CancellationToken cancellationToken)
        {
            await _studentService.DeleteStudentAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
