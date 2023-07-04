using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame
{
    internal class State
    {
        public int id { get; set; }
        public string text { get; set; }
        public List<Choice> choices { get; set; }
    }
}
