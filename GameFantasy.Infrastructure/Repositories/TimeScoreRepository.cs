using GameFantasy.Domain.Entities;
using GameFantasy.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFantasy.Infrastructure.Repositories
{
    public class TimeScoreRepository : ITimeScoreRepository
    {
        private readonly ITimeRepository _timeRepository;

        public TimeScoreRepository(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public async Task<List<TimeScore>> ListTimeScore()
        {
            var times = await _timeRepository.GetAsync();
            List<TimeScore> scores = new List<TimeScore>();
            foreach (var time in times)
                scores.Add(new TimeScore() { Time = time, Score = 0 });
            return scores;
        }
    }
}
