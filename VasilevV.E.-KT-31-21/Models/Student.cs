using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace VasilevV.E._KT_31_21.Models
{
    public class Student
    {
        [JsonIgnore]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int GroupId { get; set; }
        [JsonIgnore]
        public virtual Group? Group {get; set;}
        public bool IsValidName()
        {
            var namePattern = @"^[A-Za-zА-Яа-яЁё\s-]+$";
            return Regex.IsMatch(FirstName, namePattern) && Regex.IsMatch(LastName, namePattern) && Regex.IsMatch(MiddleName, namePattern);
        }
    }
    
}
