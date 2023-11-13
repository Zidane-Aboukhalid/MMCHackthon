using Domain.DB;
using Domain.Models;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TypeRepository;

class PayRepository : GenericRepository<Pay>, IPayRepository
{
    public PayRepository(DBContext context) : base(context)
    {
    }
}
