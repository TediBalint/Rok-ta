using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
    public class PosGenQuick : IPosGenStrategy
    {
        Random random = new Random();
        public int[] GetPos(Enemy enemy, Player player)
        {
            return new int[] { GetX(enemy, player), GetY(enemy) };
        }
        private int GetX(Enemy enemy, Player player)
        {
            int x;
            if (enemy.Width >= (int)(player.X - player.Width - enemy.Width / 2)) x = random.Next((int)(player.X + player.Width + enemy.Width / 2), Console.WindowWidth - enemy.Width);
            else if ((int)(player.X + player.Width * 2 + enemy.Width / 2) >= Console.WindowWidth - enemy.Width) x = random.Next(enemy.Width, (int)(player.X - player.Width * 2 - enemy.Width / 2));
            else
            {
                x = new int[] {
                    random.Next(enemy.Width, (int)(player.X-player.Width - enemy.Width/2)),
                    random.Next((int)(player.X + player.Width * 2 + enemy.Width/2), Console.WindowWidth - enemy.Width)}[random.Next(0, 2)];
            }
            return x;
        }
        private int GetY(Enemy enemy)
        {
            return random.Next(enemy.Height, Console.WindowHeight - enemy.Height);
        }
    }
}
