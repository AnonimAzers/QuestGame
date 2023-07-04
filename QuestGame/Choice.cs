using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

namespace QuestGame
{
    public class Choice
    {
        public string text { get; set; }
        public int nextState { get; set; }
        public Effect effects { get; set; }
    }
}
