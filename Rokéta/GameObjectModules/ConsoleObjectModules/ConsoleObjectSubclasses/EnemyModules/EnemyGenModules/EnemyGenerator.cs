using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.Statics;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules
{
    public class EnemyGenerator
    {
        private Random random = new Random();
        private Player player;
        private ConsoleObjectFactory consoleObjectFactory;
        private Stopwatch stopwatch;

        private PosGenQuick posGenQuick = new PosGenQuick();
        private PosGenDistance posGenDistance = new PosGenDistance();

        private PosGenContext posGenContext;
        public EnemyGenerator(ConsoleObjectFactory _consoleObjectFactory, Player _player)
        {
            player = _player;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            consoleObjectFactory = _consoleObjectFactory;

            posGenContext = new PosGenContext(posGenDistance);

        }
        public void Generate()
        {
            if (stopwatch.Elapsed.Seconds > getTimeUntilNextGen())
            {
                if (Globals.canGenerate)
                {
                    GenerateEnemy();
                    stopwatch.Restart();
                }

            }
        }
        private double getTimeUntilNextGen()
        {
            double pow = 10;
            if (Globals.kills > 1100) pow = 1000;
            if (Globals.kills < 110) pow = 100;
            else if (Globals.kills < 15) pow = 10;

            if (Globals.kills < 1600)
            {
                return 2 + Math.Min(1 / Math.Pow(2, Globals.kills / pow), 5) + Math.Min(Globals.enemyCount / Globals.kills * 100, 3);
            }
            else if (Globals.kills < 1610)
            {
                if (Globals.enemyCount > 0) return double.PositiveInfinity;
                else return 0;
            }
            else
            {
                return Math.Min(1 / Math.Pow(2, Globals.kills / pow), 5) + Math.Min(Globals.enemyCount / Globals.kills * 100, 3);
            }
        }

        public void test(int n)
        {
            for (int i = 0; i < n; i++)
            {
                GenerateEnemy();
            }
        }
        private void GenerateEnemy()
        {
            Globals.lastHealthBonus += random.NextDouble() * Globals.kills / 100;
            Enemy enemy = GetEnemy();
            int[] pos = posGenContext.GetPos(enemy, player);
            double[] velocity = new double[] { 3 + random.NextDouble() * Globals.kills / 100, 3 + random.NextDouble() * Globals.kills / 100 };
            for (int i = 0; i < velocity.Length; i++) velocity[i] *= Math.Sign(random.Next(-1, 1) + 0.1);
            if (Globals.kills > 2000) enemy.Health = 50000;
            double health = enemy.Health + Globals.lastHealthBonus;
            consoleObjectFactory.CreateEnemy(pos[0], pos[1], enemy.Z_Index, enemy.Width, enemy.Height, enemy.FilePath, velocity, health);
        }
        private Enemy GetEnemy()
        {
            foreach (int killCount in Defaults.enemies.Keys)
            {
                if (Globals.kills >= killCount) return Defaults.enemies[killCount][random.Next(0, Defaults.enemies[killCount].Length)];
            }
            return Defaults.enemies.Last().Value.Last();
        }
    }
}
