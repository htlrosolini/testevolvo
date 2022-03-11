using testevolvo.Models.Entities.Volvo;

namespace testevolvo.Models.DataAccess
{
    public class DataCreation
    {
        public static void CreateTables()
        {
            CaminhaoAccess.CreateTableIfNotExists();
        }

        public static void CreateDataSample()
        {
            if (CaminhaoAccess.Count() <= 0)
            {
                CaminhaoAccess.Save(new Caminhao { Modelo = "FH", Name = "Caminhão 1", AnoFab = 2021, AnoMod = 2022 });
                CaminhaoAccess.Save(new Caminhao { Modelo = "FM", Name = "Caminhão 2", AnoFab = 2021, AnoMod = 2022 });
            }
        }
    }
}
