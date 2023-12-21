using System.Diagnostics;
using Roketa.Renderer;
using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;
using Rokéta.Statics;

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
	Random r = new Random();
	Console.CursorVisible=false;
	Console.Title = "Rokéta";
	int width = Console.WindowWidth;
	int height = Console.WindowHeight;
	Debug.WriteLine($"Width: {width} Height: {height}");
	
	Renderer renderer = new Renderer(width,height);

	// ConsoleObjectList sorted by Zindex for render 
	ConsoleObjectManager consoleObjectManager = new ConsoleObjectManager(width,height);
	ConsoleObjectFactory consoleObjectFactory = new ConsoleObjectFactory(consoleObjectManager);
	Background background = consoleObjectFactory.CreateBackground(filePath: "SafeFiles\\Objects\\Background\\bg3.txt");
	
	Player player = consoleObjectFactory.CreatePlayer("Kindian", 20, 20, 2, 5, 5, Defaults.defaultWeapon, filePath: "SafeFiles\\Objects\\Obj1.txt");
	//Enemy enemy = new Enemy(r.Next(120 - 5 + 1), 0, 2, 3, 3, filePath: $"SafeFiles\\Objects\\Enemy{r.Next(3 + 1)}.txt");
	Enemy enemy = consoleObjectFactory.CreateEnemy(50, 10, 1, 3, 3, filePath: $"SafeFiles\\Objects\\Enemy1.txt");

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
		gameThicks+=10;
		if (timer.Elapsed.TotalSeconds >= 0.1)
		{
			timer.Restart();
			currentGameThicks = gameThicks;
			StaticVars.currentGameThicks = currentGameThicks;
			//Debug.WriteLine(gameThicks);
			gameThicks = 0;
		}
	}
	void inputThread()
	{
		while (true)
		{
			ConsoleKeyInfo keyPress = Console.ReadKey(true);
			if (keyPress.KeyChar == 'w')
			{
				player.MoveRaw(0, 1.5);
			}
			else if (keyPress.KeyChar == 's')
			{
				player.MoveRaw(0, -1.5);
			}
			else if (keyPress.KeyChar == 'd')
			{
				player.MoveRaw(1.5, 0);
			}
			else if (keyPress.KeyChar == 'a')
			{
				player.MoveRaw(-1.5, 0);
			}
			else if (keyPress.KeyChar == 'k')
			{
				player.Weapon.Shoot(bulletTimer, consoleObjectFactory);
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


