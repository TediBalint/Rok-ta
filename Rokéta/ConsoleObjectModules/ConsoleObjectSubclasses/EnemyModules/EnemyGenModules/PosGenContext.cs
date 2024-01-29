using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
    public class PosGenContext
    {
        private IPosGenStrategy posGenStrategy;

        public PosGenContext(IPosGenStrategy _posGenStrategy)
        {
            posGenStrategy = _posGenStrategy;
        }
        public void SetStrategy(IPosGenStrategy _posGenStrategy)
        {
            posGenStrategy = _posGenStrategy;
        }
        public int[] GetPos(Enemy enemy, Player player)
        {
            return posGenStrategy.GetPos(enemy, player);
        }

    }
}
