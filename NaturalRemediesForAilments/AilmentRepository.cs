﻿using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using NaturalRemediesForAilments.Models;
using NaturalRemediesForAilments.Models;

namespace NaturalRemediesForAilments
{
	public class AilmentRepository : IAilmentRepository
	{
		private readonly IDbConnection _conn;
		public AilmentRepository(IDbConnection conn)
		{
			_conn = conn;
		}

        
             

           public IEnumerable<Ailment> GetAllAilments()
        {
        	return _conn.Query<Ailment>("SELECT * FROM ailments;");
        }


              public void DeleteAilment(Ailment Ailment)
              {

                  _conn.Execute("DELETE FROM PRICE WHERE AilmentID = @id;", new { id = Ailment.GetAilments});
                  _conn.Execute("DELETE FROM Remedies WHERE AilmentID = @id;", new { id = Ailment.GetAilments });
                  _conn.Execute("DELETE FROM Ailment WHERE AilmentID = @id;", new { id = Ailment.GetAilments });

              }

              public Ailment GetAilment(int id)
              {
                  return _conn.QuerySingle<Ailment>("SELECT * FROM ailments WHERE AilmentID = @id", new { id = id });
              }

              public void InsertAilment(Ailment AilmentToInsert)
              {
                  _conn.Execute("INSERT INTO ailments (NAME, REMEDIES, PRICE) VALUES (@name, @remedies, @price);",
              new { name = AilmentToInsert.Name, price = AilmentToInsert.Price, Remedies = AilmentToInsert.Remedies });
              }



              public void UpdateAilment(Ailment Ailment)
              {
                  _conn.Execute("UPDATE ailments SET Name = @name, Price = @price WHERE AilmentID = @id",
                   new { name = Ailment.Name, price = Ailment.Price, id = Ailment.Remedies});
              }

              public Ailment GetTheAilments()
              {
                  var ailmentList = GetAllAilments();
                  var ailment = new Ailment();
                 ailment.GetAilments = ailmentList;
                  return ailment;

            }
    }
}

	


