using GameFantasy.Domain.Entities;
using GameFantasy.Domain.Pagination;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameFantasy.Domain.Interfaces
{
    public interface ITimeRepository
    {
        PagedList<Time> GetAll(TimeParameters timeParameters);
        Task<IEnumerable<Time>> GetAsync();
        IQueryable<Time> Get();
        Task<Time> GetByIdAsync(int id);
        Task<Time> CreateAsync(Time time);
        Task<Time> UpdateAsync(Time time);
        Task<Time> RemoveAsync(Time time);
        Task<bool> ExistTime(Time time);
    }
}
