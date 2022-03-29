using System;
using System.Collections.Generic;
using FinalProject.Models;
using System.Data;

namespace FinalProject

{
    public interface IAffirmationRepo
    {
        public IEnumerable<Affirmation> GetAllAffirmations();
        public Affirmation GetAffirmation(int id);
        public void UpdateAffirmationTxt(Affirmation affirmation);
        public void DeleteAffirmation(Affirmation affirmation);
        public void InsertAffirmation(Affirmation affirmToInsert);
        public IEnumerable<Category> GetCategories();
        public Affirmation AssignCategory();
    }
}
