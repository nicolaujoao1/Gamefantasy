using GameFantasy.Application.Interfaces;
using GameFantasy.Domain.Entities;
using GameFantasy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFantasy.Application.Services
{
    public class ChampionShipService : IChampionShipService
    { 

        private readonly IChampionShipRepository _championShipRepository;

        public ChampionShipService(IChampionShipRepository championShipRepository)
        {
            _championShipRepository = championShipRepository;
        }

        public async Task<List<ChampionShip>> GenerateScorePlateAsync()
        {
            return await _championShipRepository.GenerateScorePlateAsync();
        }
    }
}
