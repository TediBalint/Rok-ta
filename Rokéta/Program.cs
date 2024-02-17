using System.Diagnostics;
using Roketa.Renderer;
using Rokéta.Statics;
using Rokéta.SoundModules;
using Rokéta.GameObjectModules.ConsoleObjectModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules.EnemyGenModules;
using Rokéta.GameObjectModules.UIObjectModules;

void main()
{
	int width = 150;
	int height = 50;
	Console.CursorVisible=false;
	Console.Title = "Rokéta";
	Console.WindowWidth = width;
	Console.WindowHeight = height;

	Renderer renderer = new Renderer(width,height);

	ConsoleObjectManager consoleObjectManager = new ConsoleObjectManager(width,height, "SaveFiles\\GameStates\\game1.txt");
	ConsoleObjectFactory consoleObjectFactory = new ConsoleObjectFactory(consoleObjectManager);

	UIObjectManager uiObjectManager = new UIObjectManager(consoleObjectManager.Pixels);
	UIObjectFactory uiObjectFactory = new UIObjectFactory(uiObjectManager);
	uiObjectManager.Activate();
	uiObjectFactory.CreateButton(5,5,15,5,padTop:1,padBot:0, padLeft:0, padRight:0, text:"button1fadsfasfsafdasfasfasdasdsad", textAlign:"CL",foreground:ConsoleColor.Green, background:ConsoleColor.Red);

	Player player = consoleObjectFactory.CreatePlayer(20, 20, 2, 5, 11,Defaults.DefaultSpeed, BoosterManager.GetBooster(Defaults.DefaultBoosterName), filePath: "SaveFiles\\Objects\\Players\\Player2.txt");
	Background background = consoleObjectFactory.CreateBackground(filePath: "SaveFiles\\Objects\\Background\\bg1.txt");
	EnemyGenerator enemyGenerator = new EnemyGenerator(consoleObjectFactory, player);
	//enemyGenerator.test(1000);
	SoundManager.PlaySound("Music1");

	Thread thread2 = new Thread(inputThread);
	// thread for inputs
	thread2.Start();


	int gameThicks = 0;
	Stopwatch timer = Stopwatch.StartNew();
	
	//gameloop
	while (true)
	{
		
		consoleObjectManager.UpdateObjects();
		if (uiObjectManager.IsActive) uiObjectManager.UpdateObjects(); 
		Render();

		//Set Game Thicks
		gameThicks +=100;
		if (timer.Elapsed.TotalSeconds >= 0.01)
		{
			timer.Restart();
			//Debug.WriteLine("FPS: " + gameThicks);
			Globals.currentGameThicks = gameThicks;
			gameThicks = 0;
		}
	}
	void Render()
	{
		renderer.Buffer = consoleObjectManager.Pixels;
		renderer.Render();
		enemyGenerator.Generate();
	}
	void inputThread()
	{
		while (true)
		{
			ConsoleKeyInfo keyPress = Console.ReadKey(true);
			if (Defaults.keyBinds["Up"].Contains(keyPress.Key))
			{
				player.MoveRaw(MovementMatrixes.Up);
			}
			else if (Defaults.keyBinds["Down"].Contains(keyPress.Key))
			{
				player.MoveRaw(MovementMatrixes.Down);
			}
			else if (Defaults.keyBinds["Right"].Contains(keyPress.Key))
			{
				player.MoveRaw(MovementMatrixes.Right);
			}
			else if (Defaults.keyBinds["Left"].Contains(keyPress.Key))
			{
				player.MoveRaw(MovementMatrixes.Left);
			}
			else if (Defaults.keyBinds["Shoot"].Contains(keyPress.Key) && player.IsVissible)
			{
				player.Weapon.Shoot(consoleObjectFactory);
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
			else if (Defaults.keyBinds["Restart"].Contains(keyPress.Key) && player.IsDisposed)
			{
				player = consoleObjectFactory.loadGameState(player, "SaveFiles\\GameStates\\RESTART.txt");
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


