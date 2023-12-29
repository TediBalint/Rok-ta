using System.Diagnostics;
using Roketa.Renderer;
using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.Statics;
using Rokéta.SoundModules;

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
	
	Player player;
	Background background;
	if (!consoleObjectFactory.loadedGameState)
	{
		background = consoleObjectFactory.CreateBackground(filePath: "SaveFiles\\Objects\\Background\\bg2.txt");
		player = consoleObjectFactory.CreatePlayer(20, 20, 2, 5, 11, filePath: "SaveFiles\\Objects\\Players\\Player2.txt");
	}
	else player = consoleObjectFactory.CreatePlayer(20, 20, 2, 5, 11, filePath: "SaveFiles\\Objects\\Players\\Player2.txt");
	EnemyGenerator enemyGenerator = new EnemyGenerator(consoleObjectFactory, player);
	
	SoundManager.PlaySound("Music1");
	Stopwatch bulletTimer = Stopwatch.StartNew();

	Thread thread2 = new Thread(inputThread);
	// thread for inputs
	thread2.Start();


	int gameThicks = 0;
	Stopwatch timer = Stopwatch.StartNew();
	
	//gameloop
	while (true)
	{
		
		consoleObjectManager.HandleCollisions();

		//Rendering
		consoleObjectManager.RenderObjects();
		renderer.Buffer = matrixToVector(consoleObjectManager.pixels);
		renderer.Render();
		enemyGenerator.Generate();

		//Set Game Thicks
		gameThicks +=100;
		if (timer.Elapsed.TotalSeconds >= 0.01)
		{
			timer.Restart();
			Globals.currentGameThicks = gameThicks;
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
				player.MoveRaw(0, 1+Globals.kills/1000);
			}
			else if (Defaults.keyBinds["Down"].Contains(keyPress.Key))
			{
				player.MoveRaw(0, -(1 + Globals.kills / 1000));
			}
			else if (Defaults.keyBinds["Right"].Contains(keyPress.Key))
			{
				player.MoveRaw(1 + Globals.kills / 1000, 0);
			}
			else if (Defaults.keyBinds["Left"].Contains(keyPress.Key))
			{
				player.MoveRaw(-(1 + Globals.kills / 1000), 0);
			}
			else if (Defaults.keyBinds["Shoot"].Contains(keyPress.Key) && player.IsVissible)
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
			else if (Defaults.keyBinds["Load"].Contains(keyPress.Key))
			{
				player = consoleObjectFactory.loadGameState(player);
			}
			else if(Defaults.keyBinds["Cheat"].Contains(keyPress.Key))
			{
				Globals.kills = 1600;
			}
			else if(keyPress.Key == ConsoleKey.X)
			{
				Globals.kills += 50;
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




main();


