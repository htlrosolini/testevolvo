using SQLiteORM.Attributes;
using System.Text.Json.Serialization;

namespace VolvoApp.Models.Entities.Volvo
{
    [Table("Caminhoes")]
    public class Caminhao
    {
        [PrimaryKey]
        [AutoIncrement]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Modelo { get; set; }
        public int AnoFab { get; set; }
        public int AnoMod { get; set; }
    }
}
