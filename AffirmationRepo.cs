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

        IEnumerable<Affirmations> IAffirmationRepo.GetAllAffirmations()
        {
            return _conn.Query<Affirmations>("SELECT * FROM affirms;");
        }

        public Affirmations GetAffirmation(int id)
        {
            return _conn.QuerySingle<Affirmations>("SELECT * FROM affirms WHERE ID = @id;", new { id = id });
        }

        public void UpdateAffirmationTxt(Affirmations affirmation)
        {
            _conn.Execute("UPDATE affirms SET AffirmationText = @affirmationText WHERE ID = @id",
                 new { affirmationText = affirmation.AffirmationText, id = affirmation.ID });
        }

        public void DeleteAffirmation(Affirmations affirmation)
        {
            _conn.Execute("DELETE FROM affirms WHERE ID = @id;",
                                     new { id = affirmation.ID });
        }


        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }

        public Affirmations AssignCategory()
        {
            var categoryList = GetCategories();
            var affirm = new Affirmations();
            affirm.Categories = categoryList;

            return affirm;
        }

        public void InsertAffirmation(Affirmations affirm)
        {
            _conn.Execute("INSERT INTO affirms (AffirmationText, Category) VALUES (@AffirmationText, @Category);",
                    new { AffirmationText = affirm.AffirmationText, Category = affirm.Category });
        }
    }
}
