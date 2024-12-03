using Xunit;
using VasilevV.E._KT_31_21.Models;
namespace VasilevV.E._KT_31_21.Tests
{
    public class StudentsTests
    {
        [Fact]
        public void IsValidName_Ivan_True()
        {
            var student = new Student
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович"
            };

            // Act
            var result = student.IsValidName();

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsValidName_Ivanova_Petrova_True()
        {
            var student = new Student
            {
                FirstName = "Людмила",
                LastName = "Иванова-Петрова",
                MiddleName = "Ивановна"
            };

            // Act
            var result = student.IsValidName();

            // Assert
            Assert.True(result);
        }
    }
 }
