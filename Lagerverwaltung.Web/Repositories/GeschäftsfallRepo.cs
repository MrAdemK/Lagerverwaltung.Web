using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Lagerverwaltung.Model.DatabaseModels;
using Lagerverwaltung.Model.ViewModels;
using Lagerverwaltung.Web.Models;
using Lagerverwaltung.Web.Repositories.Interfaces;
using System.Data.Entity;

namespace Lagerverwaltung.Web.Repositories
{
    public class GeschäftsfallRepo /*: IGeschäftsfallRepo*/
    {
        /*private readonly ApplicationDbContext _dbContext;

        public GeschäftsfallRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GeschäftsfallLagerartikelVM>> AlleGeschäftsfälle()
        {
            var temp = await (from g in _dbContext.Geschäftsfalls
                    .Include(v => v.Vorgangstyp)
                    .Include(l => l.Vorgangstyp.Lagerbewegung)
                              select new GeschäftsfallLagerartikelVM
                              {
                                  GeschäftsfallId = g.GeschäftsfallId,
                                  Datum = g.Datum,
                                  Vorgang = g.Vorgangstyp.Vorgang,
                                  B_Bezeichnung = g.Vorgangstyp.Lagerbewegung.B_Bezeichnung,
                                  B_Preis = g.Vorgangstyp.Lagerbewegung.B_Preis,
                                  B_Menge = g.Vorgangstyp.Lagerbewegung.B_Menge,
                                  B_Mengeneinheit = g.Vorgangstyp.Lagerbewegung.B_Mengeneinheit
                              }).ToListAsync();

            return temp;
        }

        public async Task<Geschäftsfall> GeschäftsfallPerId(int? id)
        {
            return await _dbContext.Geschäftsfalls.FindAsync(id);
        }

        public void InsertGeschäftsfall(Geschäftsfall geschäftsfall)
        {
            throw new NotImplementedException();
        }

        public void UpdateGeschäftsfall(Geschäftsfall geschäftsfall)
        {
            throw new NotImplementedException();
        }

        public void DeleteGeschäftsfall(Geschäftsfall geschäftsfall)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable> DropdownArticle()
        {
            throw new NotImplementedException();
        }*/
    }
}