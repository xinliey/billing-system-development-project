using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatexApp0
{
    public sealed class AppState
    {
        
        public static AppState Instance { get; } = new AppState();

        private AppState() { }

        
        public List<int> PercentPrices { get; } = new List<int>();

    }
}
