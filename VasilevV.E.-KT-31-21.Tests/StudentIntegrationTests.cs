using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VasilevV.E._KT_31_21.Database;
using VasilevV.E._KT_31_21.Interfaces.StudentsInterfaces;
using VasilevV.E._KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class StudentIntegrationTests
{
    public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

    public StudentIntegrationTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
    }

    [Fact]
    public async Task CanAddStudent_TwoObjects()
    {
        // Arrange
        using (var context = new StudentDbContext(_dbContextOptions))
        {
            var studentService = new StudentService(context);
            var groups = new List<Group>
            {
                new Group { GroupName = "KT-31-21" },
                new Group { GroupName = "KT-41-21" }
            };

            await context.Set<Group>().AddRangeAsync(groups);
            await context.SaveChangesAsync();

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Иван",
                    LastName = "Иванов",
                    MiddleName = "Иванович",
                    GroupId = 1
                },
                new Student
                {
                    FirstName = "Людмила",
                    LastName = "Иванова-Петрова",
                    MiddleName = "Ивановна",
                    GroupId = 2
                }
            };

            var cancellationToken = CancellationToken.None; 

            // Act
            foreach (var student in students)
            {
                await studentService.AddStudentAsync(student, cancellationToken);
            }
        }

        // Assert
        using (var context = new StudentDbContext(_dbContextOptions))
        {
            var addedStudents = await context.Set<Student>().ToListAsync();

            Assert.Equal(2, addedStudents.Count);
            Assert.Contains(addedStudents, s => s.FirstName == "Иван" && s.LastName == "Иванов");
            Assert.Contains(addedStudents, s => s.FirstName == "Людмила" && s.LastName == "Иванова-Петрова");
        }
    }
}
