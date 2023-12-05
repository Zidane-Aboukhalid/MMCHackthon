using Domain.DB;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TypeRepository;

class CategorieRepository : GenericRepository<Categorie>, ICategorieRepository
{
    public CategorieRepository(DBContext context) : base(context)
    {
    }
    

}




