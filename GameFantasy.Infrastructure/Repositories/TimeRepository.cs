using GameFantasy.Domain.Entities;
using GameFantasy.Domain.Interfaces;
using GameFantasy.Domain.Pagination;
using GameFantasy.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFantasy.Infrastructure.Repositories
{
    public class TimeRepository : ITimeRepository
    {
        private ApplicationDbContext _context;

        public TimeRepository(ApplicationDbContext categoryContext)
        {
            _context = categoryContext;
        }

        public async Task<Time> CreateAsync(Time time)
        {
            _context.Add(time);
            await _context.SaveChangesAsync();
            return time;
        }

        public async Task<bool> ExistTime(Time time)
        =>await _context.Times.AnyAsync(p => p.Name == time.Name);
        public IQueryable<Time> Get()
        {
            return _context.Times.AsQueryable();
        }
        public PagedList<Time> GetAll(TimeParameters timeParameters)
        {
            return PagedList<Time>.ToPagedList(Get().OrderBy(p=>p.Name),
                              timeParameters.PageNumber,
                              timeParameters.PageSize);
        }


        public async Task<IEnumerable<Time>> GetAsync()
        {
            return await _context.Times.AsNoTracking().ToListAsync();
        }


        public async Task<Time> GetByIdAsync(int id)
        {
            return await _context.Times.FindAsync(id);
        }

        public async Task<Time> RemoveAsync(Time time)
        {
            _context.Remove(time);
            await _context.SaveChangesAsync();
            return time;
        }

        public async Task<Time> UpdateAsync(Time time)
        {
            _context.Remove(time);
            await _context.SaveChangesAsync();
            return time;
        }
    }
}
