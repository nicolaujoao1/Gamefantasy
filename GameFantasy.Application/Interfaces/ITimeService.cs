using GameFantasy.Application.DTOs;
using GameFantasy.Domain.Entities;
using GameFantasy.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFantasy.Application.Interfaces
{
    public interface ITimeService
    {

        Task<IEnumerable<TimeDTO>> GetAsync();
        Task<TimeDTO> GetByIdAsync(int id);
        Task<TimeDTO> CreateAsync(TimeDTO time);
        Task<TimeUpdateDTO> UpdateAsync(TimeUpdateDTO time);
        Task RemoveAsync(int id);
        Task<bool> ExistTimeAsync(TimeDTO timeDTO);
        (IEnumerable<TimeDTO>,PagedList<Time>) GetAll(TimeParameters timeParameters);
    }
}
