using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lagerverwaltung.Model.DatabaseModels;
using Lagerverwaltung.Model.ViewModels;

namespace Lagerverwaltung.Web.Repositories.Interfaces
{
    public interface IGeschäftsfallRepo
    {
        Task<Geschäftsfall> GeschäftsfallPerId(int? id);

        void InsertGeschäftsfall(Geschäftsfall geschäftsfall);
        void UpdateGeschäftsfall(Geschäftsfall geschäftsfall);
        void DeleteGeschäftsfall(Geschäftsfall geschäftsfall);

        Task<IEnumerable> DropdownArticle();
    }
}
