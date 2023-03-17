using AutoMapper;
using GameFantasy.Application.DTOs;
using GameFantasy.Application.Interfaces;
using GameFantasy.Domain.Entities;
using GameFantasy.Domain.Interfaces;
using GameFantasy.Domain.Pagination;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace GameFantasy.Application.Services
{
    public class TimeService : ITimeService
    {
        private readonly ITimeRepository _timeRepository;
        private readonly IMapper _mapper;
        public TimeService(ITimeRepository timeRepository, IMapper mapper)
        {
            _timeRepository = timeRepository;
            _mapper = mapper;
        }

        public async Task<TimeDTO> CreateAsync(TimeDTO time)
        {
            var timeEntity = _mapper.Map<Time>(time);
            await _timeRepository.CreateAsync(timeEntity);
            return time;
        }
        public async Task<bool> ExistTimeAsync(TimeDTO timeDTO)
        {
            var timeEntity = _mapper.Map<Time>(timeDTO);
           return  await _timeRepository.ExistTime(timeEntity);
        }

        public async Task<IEnumerable<TimeDTO>> GetAsync()
        {
            var timeEntity = await _timeRepository.GetAsync();
            return _mapper.Map<IEnumerable<TimeDTO>>(timeEntity);
        }

        public async Task<TimeDTO> GetByIdAsync(int id)
        {
            var timeEntity = await _timeRepository.GetByIdAsync(id);
            return _mapper.Map<TimeDTO>(timeEntity);
        }

        public async Task RemoveAsync(int id)
        {
            var timeEntity = _timeRepository.GetByIdAsync(id).Result;
            await _timeRepository.RemoveAsync(timeEntity);
        }

        public async Task<TimeUpdateDTO> UpdateAsync(TimeUpdateDTO time)
        {
            var timeEntity = _mapper.Map<Time>(time);
            await _timeRepository.UpdateAsync(timeEntity);
            return time;
        }
        public (IEnumerable<TimeDTO>, PagedList<Time>) GetAll(TimeParameters timeParameters)
        {
            var timesEntity= _timeRepository.GetAll(timeParameters);
            var times = _mapper.Map<IEnumerable<TimeDTO>>(timesEntity);
            return (times,timesEntity);
        }
    }
}
