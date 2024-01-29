using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
    public interface IPosGenStrategy
    {
        int GetX(Enemy enemy, Player player);
        int GetY(Enemy enemy, Player player);
    }
}
