using GameFantasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFantasy.Domain.Interfaces
{
    public interface ITimeScoreRepository
    {
        Task<List<TimeScore>> ListTimeScore();
        
    }
}
