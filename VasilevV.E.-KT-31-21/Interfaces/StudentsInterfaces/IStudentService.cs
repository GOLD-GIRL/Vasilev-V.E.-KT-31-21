using VasilevV.E._KT_31_21.Database;
using VasilevV.E._KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using NLog.Filters;
using System.Threading;

namespace VasilevV.E._KT_31_21.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        Task<Student[]> GetStudentsAsync(CancellationToken cancellationToken);
        Task<Student> AddStudentAsync(Student student, CancellationToken cancellationToken);
        Task<Student> UpdateStudentAsync(int id, Student student, CancellationToken cancellationToken);
        Task DeleteStudentAsync(int id, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student[]> GetStudentsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Students.ToArrayAsync(cancellationToken);
        }

        public async Task<Student> AddStudentAsync(Student student, CancellationToken cancellationToken)
        {
            await _dbContext.Students.AddAsync(student, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return student;
        }

        public async Task<Student> UpdateStudentAsync(int id, Student student, CancellationToken cancellationToken)
        {
            var existingStudent = await _dbContext.Students.FindAsync(id);
            if (existingStudent == null) return null;

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.MiddleName = student.MiddleName;
            existingStudent.GroupId = student.GroupId;

            _dbContext.Students.Update(existingStudent);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return existingStudent;
        }

        public async Task DeleteStudentAsync(int id, CancellationToken cancellationToken)
        {
            var student = await _dbContext.Students.FindAsync(new object[] { id }, cancellationToken);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
