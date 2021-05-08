using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace students_back
{
    public class PredmetQuery
    {
        public AppDb Db { get; }

        public PredmetQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Predmet> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `nazev` FROM `predmet` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Predmet>> FindAllAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `nazev` FROM `predmet`";
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result;
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `predmet`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Predmet>> ReadAllAsync(DbDataReader reader)
        {
            var predmety = new List<Predmet>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var predmet = new Predmet(Db)
                    {
                        id = reader.GetInt32(0),
                        nazev = reader.GetString(1)
                    };
                    predmety.Add(predmet);
                }
            }
            return predmety;
        }
    }
}