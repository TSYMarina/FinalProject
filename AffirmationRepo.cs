using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using FinalProject.Models;
using System.Collections.Generic;

namespace FinalProject
{
    public class AffirmationRepo : IAffirmationRepo
    {

        private readonly IDbConnection _conn;

        public AffirmationRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        IEnumerable<Affirmation> IAffirmationRepo.GetAllAffirmations()
        {
            return _conn.Query<Affirmation>("SELECT * FROM affirmations;");
        }

        public Affirmation GetAffirmation(int id)
        {
            return _conn.QuerySingleOrDefault<Affirmation>("SELECT * FROM affirmations WHERE ID = @id;", new { id = id });
        }

        public void UpdateAffirmationTxt(Affirmation affirmation)
        {
            _conn.Execute("UPDATE affirmations SET AffirmationText = @affirmTxt WHERE ID = @id",
                 new { affirmationTxt = affirmation.AffirmationText, id = affirmation.ID });
        }

    }
}
