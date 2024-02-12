using Rokéta.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.Statics;
using System.Diagnostics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules
{
    public class ConsoleObjectFactory
    {
        private ConsoleObjectManager ConsoleObjectManager { get; set; }
        public bool loadedGameState = false;

        public ConsoleObjectFactory(ConsoleObjectManager consoleObjectManager)
        {
            ConsoleObjectManager = consoleObjectManager;
        }
        public Player loadGameState(Player player, string? _filePath = null)
        {
            string filePath;
            if (_filePath != null && File.Exists(_filePath)) filePath = _filePath;
            else filePath = ConsoleObjectManager.SaveFilePath;
            Globals.enemyCount = 0;
            ConsoleObjectManager.ConsoleObjects.Clear();
            Globals.canGenerate = false;
            if (File.Exists(filePath))
            {
                loadedGameState = true;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string[] firstLine = Encrypter.Decrypt(reader.ReadLine()).Split(';');
                    Globals.isMusicEnabled = bool.Parse(firstLine[0]);
                    Globals.isGameSoundEnabled = bool.Parse(firstLine[1]);
                    Globals.kills = int.Parse(firstLine[2]);
                    Globals.lastHealthBonus = double.Parse(firstLine[3]);
                    while (!reader.EndOfStream)
                    {

                        string[] line = Encrypter.Decrypt(reader.ReadLine()).Split(';');
                        string ObjType = line[0];
                        double Objx = double.Parse(line[1]);
                        double Objy = double.Parse(line[2]);
                        int ObjzIndex = int.Parse(line[3]);
                        int Objwidth = int.Parse(line[4]);
                        int Objheight = int.Parse(line[5]);
                        string ObjFilePath = line[6];
                        if (ObjType == "Player")
                        {
                            double[] movementSpeed = new double[2] { double.Parse(line[7]), double.Parse(line[8]) };
                            string boosterName = line[9];
                            player = CreatePlayer(Objx, Objy, ObjzIndex, Objwidth, Objheight, movementSpeed,BoosterManager.GetBooster(boosterName), ObjFilePath);
                        }
                        else if (ObjType == "Enemy")
                        {
                            double[] velocity = new double[] { double.Parse(line[7]), double.Parse(line[8]) };
                            double health = double.Parse(line[9]);
                            CreateEnemy(Objx, Objy, ObjzIndex, Objwidth, Objheight, ObjFilePath, velocity, health);
                        }
                        else if (ObjType == "Background")
                        {
                            CreateBackground(filePath: ObjFilePath);
                        }
                        else
                        {
                            Debug.WriteLine($"No such type as {ObjType} LoadGameState(ConsoleObjectFactory.cs)");
                        }
                    }
                }
            }
            else
            {
                Debug.WriteLine("SaveFile Doesnt exist");
            }
            Globals.canGenerate = true;
            return player;
        }
        
        public Player CreatePlayer(double x, double y, int zIndex, int width, int height, double[] movementSpeed,Booster booster, string? filePath = null)
        {
            Player newPlayer = new Player(x, y, zIndex, width, height, filePath, movementSpeed, booster);
            ConsoleObjectManager.ConsoleObjects.Insert(findConsoleObjectPlace(newPlayer), newPlayer);
            handleAnimation(newPlayer);
            return newPlayer;
        }
        public Enemy CreateEnemy(double x, double y, int zIndex, int? width, int? height, string? filePath, double[] velocity, double health)
        {
            Globals.enemyCount++;
            Enemy newEnemy = new Enemy(x, y, zIndex, width, height, filePath, velocity, health);
            ConsoleObjectManager.ConsoleObjects.Insert(findConsoleObjectPlace(newEnemy), newEnemy);
            handleAnimation(newEnemy);
			return newEnemy;
        }
        public void AddBullet(Bullet bullet, double angle, double[] spawnPos)
        {
            Bullet newBullet = bullet.DeepCopy();
            newBullet.angle = angle;
            newBullet.SetPos(spawnPos);
            handleAnimation(newBullet);
            ConsoleObjectManager.ConsoleObjects.Insert(findConsoleObjectPlace(newBullet), newBullet);
        }
        public Background CreateBackground(ConsoleColor? color = null, string? filePath = null)
        {
            Background newBackgrond = new Background(color, filePath);
            ConsoleObjectManager.ConsoleObjects.Insert(findConsoleObjectPlace(newBackgrond), newBackgrond);
            return newBackgrond;
        }
        private void handleAnimation(ConsoleObject consoleObject)
        {
            foreach (Animation anim in consoleObject.Animations)
            {
                ConsoleObjectManager.ConsoleObjects.Insert(findConsoleObjectPlace(anim), anim);
            }
        }
        private int findConsoleObjectPlace(ConsoleObject consoleObj)
        {
            int len = ConsoleObjectManager.ConsoleObjects.Count;
            int thisIndex = consoleObj.Z_Index;
            //szelsoesetek
            if (len == 0)
            {
                return 0;
            }
            if (thisIndex >= ConsoleObjectManager.ConsoleObjects.Last().Z_Index)
            {
                return len;
            }
            if (thisIndex <= ConsoleObjectManager.ConsoleObjects.First().Z_Index)
            {
                return 0;
            }

            int left = 0;
            int right = len - 1;
            while (left < right)
            {
                int middle = (left + right) / 2;
                if (ConsoleObjectManager.ConsoleObjects[middle].Z_Index <= thisIndex && ConsoleObjectManager.ConsoleObjects[middle + 1].Z_Index >= thisIndex)
                {
                    return middle + 1;
                }
                else if (ConsoleObjectManager.ConsoleObjects[middle].Z_Index <= thisIndex)
                {
                    left = middle + 1;
                }
                else if (ConsoleObjectManager.ConsoleObjects[middle].Z_Index <= thisIndex)
                {
                    right = middle - 1;
                }
            }
            return len;
        }
    }
}
