using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFantasy.Domain.Entities
{
    public sealed class Match
    {
        public Match(string times, string results)
        {
            Times = times;
            Results = results;
        }

        public string Times { get; private set; }
        public string Results { get; private set; }
    }
}
