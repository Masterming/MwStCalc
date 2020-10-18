using System;
using SQLConnection;

namespace Services
{
    public class Service : IService
    {
        private static SQL db;
        public double GetMwStPerc(int id)
        {
            db = new SQL(source: "file.sql", destination: "data.db");
            return db.GetData(id);
        }
    }
}
