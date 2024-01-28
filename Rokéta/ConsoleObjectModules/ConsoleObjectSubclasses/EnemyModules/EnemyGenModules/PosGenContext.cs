using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void GetPos()
        {

        }

    }
}
