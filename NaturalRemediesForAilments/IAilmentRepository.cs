using System;
using NaturalRemediesForAilments.Models;

namespace NaturalRemediesForAilments
{
	public interface IAilmentRepository
	{
        public void DeleteAilment(Ailment ailment);
        public IEnumerable<Ailment> GetAllAilments();
        public Ailment GetAilment(int id);
        public void UpdateAilment(Ailment ailmentToUpdate );
        public void InsertAilment(Ailment AilmentToInsert);
        public Ailment GetTheAilments();
        
        
	}
}

