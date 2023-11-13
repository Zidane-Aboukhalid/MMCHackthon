using Domain.DB;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TypeRepository;

class SponseurRepository : GenericRepository<Sponseur>, ISponseurRepository
{
    public SponseurRepository(DBContext context) : base(context)
    {
    }
}
