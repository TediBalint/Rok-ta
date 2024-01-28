using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
    public interface IPosGenStrategy
    {
        void GetX(Enemy enemy, Player player);
        void GetY(Enemy enemy, Player player);
    }
}
