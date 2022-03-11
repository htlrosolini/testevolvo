﻿using SQLiteORM.Extensions;
using SQLiteORM.Helpers;
using testevolvo.Models.Entities.Volvo;

namespace testevolvo.Models.DataAccess
{
    public class CaminhaoAccess : BaseAccess<Caminhao>
    {
        public static int Count()
        {
            using (var conn = GetDB())
            {
                conn.Open();

                return conn.CountAll<Caminhao>();
            }
        }

        public static int Count(long id)
        {
            using (var conn = GetDB())
            {
                conn.Open();

                return conn.Count<Caminhao>($"Id = {id}");
            }
        }
    }
}
