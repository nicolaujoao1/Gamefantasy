using GameFantasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFantasy.Application.Interfaces;

public interface IChampionShipService
{
    Task<List<ChampionShip>> GenerateScorePlateAsync();

}
