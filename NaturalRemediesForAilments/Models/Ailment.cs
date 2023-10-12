using System;
namespace NaturalRemediesForAilments.Models
{
	public class Ailment
	{

        
        public int Id { get; set; }
		public string? Name { get; set; }
		public string? Remedies { get; set; }
		public decimal Price { get; set; }
        public IEnumerable<Ailment>? GetAilments { get; set; }
        


    }

	
}

