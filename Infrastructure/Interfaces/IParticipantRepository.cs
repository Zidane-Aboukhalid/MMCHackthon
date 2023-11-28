using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IParticipantRepository : IGenericRepository<Participant>
    {
        Participant Find(Guid id);
        Participant GetById(Guid id);
    }
}
