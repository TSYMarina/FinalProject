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
    }
}
