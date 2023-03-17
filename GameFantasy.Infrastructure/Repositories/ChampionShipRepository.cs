using GameFantasy.Domain.Entities;
using GameFantasy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GameFantasy.Infrastructure.Repositories;
public class ChampionShipRepository : IChampionShipRepository
{
    private readonly ITimeScoreRepository _timeScoreRepository;
    private readonly Random _random = new Random();
    public ChampionShipRepository(ITimeScoreRepository timeScoreRepository)
    {
        _timeScoreRepository = timeScoreRepository;
    }

    public (int, int) GenerateScore() => (_random.Next(0, 5), _random.Next(0, 5));

    public async Task<List<ChampionShip>> GenerateScorePlateAsync()
    {
        List<ChampionShip> result = new List<ChampionShip>();
        List<Match> matches = new List<Match>();
        List<TimeScore> timeScores = new List<TimeScore>();

        var timeScore = await _timeScoreRepository.ListTimeScore();

        for (int i = 0; i < timeScore.Count; i++)
        {
            for (int j = i + 1; j < timeScore.Count; j++)
            {
                TimeScore timeA = timeScore.ElementAt(i);
                TimeScore timeB = timeScore.ElementAt(j);
                int scoreA = GenerateScore().Item1;
                int scoreB = GenerateScore().Item2;
                if (scoreA > scoreB)
                {
                    timeA.Score += 3;
                    var match = new Match($"{timeA.Time.Name} x {timeB.Time.Name}", $"{scoreA} x {scoreB}");
                    matches.Add(match);
                }
                else if (scoreA < scoreB)
                {
                    timeB.Score += 3;
                    var match = new Match($"{timeA.Time.Name} x {timeB.Time.Name}", $"{scoreA} x {scoreB}");
                    matches.Add(match);
                }
                else
                {
                    timeA.Score += 1;
                    timeB.Score += 1;
                    var match = new Match($"{timeA.Time.Name} x {timeB.Time.Name}", $"{scoreA} x {scoreB}");
                    matches.Add(match);
                }
            }
        }

        timeScore.Sort((a, b) => b.Score.CompareTo(a.Score));

        result.Add(new ChampionShip
        {
            Match = matches,
            FirstPlace = timeScore[0].Time.Name,
            SecondPlace = timeScore[1].Time.Name,
            ThirdPlace = timeScore[2].Time.Name
        });
        return result;
    }

}
