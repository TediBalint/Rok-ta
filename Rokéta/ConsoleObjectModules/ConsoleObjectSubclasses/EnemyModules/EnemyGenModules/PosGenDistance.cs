using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
    public class PosGenDistance : IPosGenStrategy
    {
        Random random = new Random();
        public int[] GetPos(Enemy enemy, Player player)
        {
            int[] pos;
            do
            {
                pos = new int[] { random.Next(0, Console.WindowWidth - enemy.Width - 1), random.Next(0, Console.WindowHeight - enemy.Height+1) };
            } while (player.GetDistance(pos) / 3 <= player.Width);
            return pos;
        }
    }
}