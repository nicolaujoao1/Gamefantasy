using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFantasy.Domain.Entities
{
    public sealed class ChampionShip
    {
        public List<Match> Match { get; set; }
        public string FirstPlace { get;  set; }
        public string SecondPlace { get;  set; }
        public string ThirdPlace { get;  set; }
       
    }
}
