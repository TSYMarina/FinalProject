using System;
using System.Collections.Generic;
using FinalProject.Models;
using System.Data;

namespace FinalProject

{
    public interface IAffirmationRepo
    {
        public IEnumerable<Affirmations> GetAllAffirmations();
        public Affirmations GetAffirmation(int id);
        public void UpdateAffirmationTxt(Affirmations affirmation);
        public void DeleteAffirmation(Affirmations affirmation);
        public void InsertAffirmation(Affirmations affirmToInsert);
        public IEnumerable<Category> GetCategories();
        public Affirmations AssignCategory();
    }
}
