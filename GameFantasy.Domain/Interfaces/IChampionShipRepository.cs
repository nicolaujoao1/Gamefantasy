using GameFantasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFantasy.Domain.Interfaces;

public interface IChampionShipRepository
{
    Task<List<ChampionShip>> GenerateScorePlateAsync();
    (int, int) GenerateScore();
}
