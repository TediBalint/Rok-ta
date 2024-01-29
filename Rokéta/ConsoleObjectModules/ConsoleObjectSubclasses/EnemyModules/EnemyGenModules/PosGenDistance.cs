using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
    public class PosGenDistance : IPosGenStrategy
    {
        Random random = new Random();
        public int GetX(Enemy enemy, Player player)
        {
            return 0;
        }
        public int GetY(Enemy enemy, Player player)
        {
            return 0;
        }
    }
}
