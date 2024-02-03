using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.UIObjectModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules
{
    public class GameObjectManager
    {
        public CharInfo[,] Pixels;
        public List<GameObject> GameObjects;

		public ConsoleObjectManager ConsoleObjectManager;
		public UIObjectManager UIObjectManager;
        public GameObjectManager(int width, int height)
        {
			Pixels = new CharInfo[height, width];
            GameObjects = new List<GameObject>();
        }
		
	}
}
