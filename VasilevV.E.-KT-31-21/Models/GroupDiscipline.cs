using System.Text.Json.Serialization;

namespace VasilevV.E._KT_31_21.Models
{
    public class GroupDiscipline
    {
        public int GroupId { get; set; }      
        public Group Group { get; set; }       

        public int DisciplineId { get; set; }

        [JsonIgnore]
        public Discipline Discipline { get; set; }
    }
}
