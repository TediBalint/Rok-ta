using Roketa.ConsoleObjectModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules
{
    public class Enemy : ConsoleObject
    {
        public Enemy(double x, double y, int zIndex, int? width, int? height, string? filePath)
        : base(x, y, zIndex, width, height, filePath)
        {
            //width: console.windowwidth
        }
        public override void OnCollision(ConsoleObject otherObject)
        {
            if(otherObject.GetType().Name == "Bullet")
            {
                IsDisposed = true;
            }
        }
    }
}
