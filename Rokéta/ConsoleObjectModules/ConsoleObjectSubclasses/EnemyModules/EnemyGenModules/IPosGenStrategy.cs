using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;

namespace Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
    public interface IPosGenStrategy
    {
        int[] GetPos(Enemy enemy, Player player);
    }
}
