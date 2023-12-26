using System.Diagnostics;
using Roketa.Renderer;
using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.Statics;
using Rokéta.SoundModules;

void Performance_BenchMark()
{
	int width = Console.WindowWidth;
	Console.CursorVisible = false;

	int height = Console.WindowHeight;
	Stopwatch sw = Stopwatch.StartNew();
	Renderer renderer = new Renderer(width, height);
	double tests = 100;
	CharInfo[,] pixels = new CharInfo[height, width];
	for (int x = 0; x < tests; x++)
	{
		renderer.FillBufferRandom();
		renderer.Render();
		renderer.Buffer = matrixToVector(pixels);
		renderer.Render();
	}
	sw.Stop();
	double time = sw.Elapsed.TotalSeconds;
	Debug.WriteLine($"{time} seconds =>\n{time / tests} per test => \n{(double)1 / (time / tests)} fps");
	Console.ReadKey();
}


void main()
{
	int width = 150;
	int height = 50;
	Random r = new Random();
	Console.CursorVisible=false;
	Console.Title = "Rokéta";
	Console.WindowWidth = width;
	Console.WindowHeight = height;
	Renderer renderer = new Renderer(width,height);
	ConsoleObjectManager consoleObjectManager = new ConsoleObjectManager(width,height, "SaveFiles\\GameStates\\game1.txt");
	ConsoleObjectFactory consoleObjectFactory = new ConsoleObjectFactory(consoleObjectManager);
	Background background = consoleObjectFactory.CreateBackground(filePath: "SaveFiles\\Objects\\Background\\bg1.txt");
	
	Player player = consoleObjectFactory.CreatePlayer(20, 20, 2, 5, 5, Defaults.defaultWeapon, filePath: "SaveFiles\\Objects\\Players\\Player2.txt");
	//Enemy enemy = new Enemy(r.Next(120 - 5 + 1), 0, 2, 3, 3, filePath: $"SaveFiles\\Objects\\Enemy{r.Next(3 + 1)}.txt");
	Enemy enemy = consoleObjectFactory.CreateEnemy(50, 10, 1, 3, 3, filePath: $"SaveFiles\\Objects\\Enemy1.txt");
	SoundManager.PlaySound("Music1");
	// rendering
	consoleObjectManager.RenderObjects();
	renderer.Buffer = matrixToVector(consoleObjectManager.pixels);
	renderer.Render();

	Stopwatch bulletTimer = Stopwatch.StartNew();

	Thread thread2 = new Thread(inputThread);
	// thread for inputs
	thread2.Start();


	int gameThicks = 0;
	int currentGameThicks = 2000;
	Stopwatch timer = Stopwatch.StartNew();
	
	//gameloop
	while (true)
	{
		
		consoleObjectManager.HandleCollisions();
		consoleObjectManager.RenderObjects();
		renderer.Buffer = matrixToVector(consoleObjectManager.pixels);
		renderer.Render();
		gameThicks+=50;
		if (timer.Elapsed.TotalSeconds >= 0.02)
		{
			timer.Restart();
			currentGameThicks = gameThicks;
			Globals.currentGameThicks = currentGameThicks;
			gameThicks = 0;
		}
	}
	void inputThread()
	{
		while (true)
		{
			ConsoleKeyInfo keyPress = Console.ReadKey(true);
			if (Defaults.keyBinds["Up"].Contains(keyPress.Key))
			{
				player.MoveRaw(0, 1.5);
			}
			else if (Defaults.keyBinds["Down"].Contains(keyPress.Key))
			{
				player.MoveRaw(0, -1.5);
			}
			else if (Defaults.keyBinds["Right"].Contains(keyPress.Key))
			{
				player.MoveRaw(1.5, 0);
			}
			else if (Defaults.keyBinds["Left"].Contains(keyPress.Key))
			{
				player.MoveRaw(-1.5, 0);
			}
			else if (Defaults.keyBinds["Shoot"].Contains(keyPress.Key))
			{
				player.Weapon.Shoot(bulletTimer, consoleObjectFactory);
			}
			else if(Defaults.keyBinds["MusicToggle"].Contains(keyPress.Key))
			{
				Globals.isMusicEnabled = !Globals.isMusicEnabled;
			}
			else if(Defaults.keyBinds["GameSoundToggle"].Contains(keyPress.Key))
			{
				Globals.isGameSoundEnabled = !Globals.isGameSoundEnabled;
			}
			else if (Defaults.keyBinds["Save"].Contains(keyPress.Key))
			{
				consoleObjectManager.SaveGameState();
			}
		}
	}
}

CharInfo[] matrixToVector(CharInfo[,] charInfos)
{
	CharInfo[] output = new CharInfo[charInfos.Length];
	int index = 0;
    foreach (CharInfo chr in charInfos)
    {
		output[index++] = chr;
	}
	return output;
}
main();


