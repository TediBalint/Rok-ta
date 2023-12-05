using System.Diagnostics;
using Roketa.Renderer;
using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules;
using Rokéta.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses;
using Rokéta.ConsoleObjectModules.ConsoleObjectSubclasses.EnemyModules;

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
	
	Renderer renderer = new Renderer(width,height);

	// ConsoleObjectList sorted by Zindex for render 
	ConsoleObjectManager consoleObjectManager = new ConsoleObjectManager(width,height);
	ConsoleObjectFactory consoleObjectFactory = new ConsoleObjectFactory(consoleObjectManager);
	Background background = consoleObjectFactory.CreateBackground(ConsoleColor.Red);
	Player player1 = consoleObjectFactory.CreatePlayer("Kindian", 20, 20, 2, 5, 5, filePath: "SafeFiles\\Objects\\Obj1.txt");
	Enemy enemy = new Enemy(r.Next(120 - 5 + 1), 0, 2, 3, 3, filePath: $"SafeFiles\\Objects\\Enemy{r.Next(3 + 1)}.txt");
	consoleObjectManager.consoleObjectList.Add(enemy);
	consoleObjectManager.RenderObjects();
	renderer.Buffer = matrixToVector(consoleObjectManager.pixels);
	renderer.Render();



	// thread for inputs
	Thread thread2 = new Thread(inputThread);
	
	thread2.Start();

	bool obj2State = true;
	bool obj2State2 = true;
	int gameThicks = 0;
	int currentGameThicks = 2000;
	Stopwatch timer = Stopwatch.StartNew();
	double speed = 50;

	//gameloop
	while (true)
	{
		consoleObjectManager.HandleCollisions();
		consoleObjectManager.RenderObjects();
		renderer.Buffer = matrixToVector(consoleObjectManager.pixels);
		renderer.Render();
		gameThicks++;
		if(timer.Elapsed.TotalSeconds >= 1)
		{
			timer.Restart();
			currentGameThicks = gameThicks;
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
				player1.MoveRaw(0, 1.5);
			}
			else if (keyPress.KeyChar == 's')
			{
				player1.MoveRaw(0, -1.5);
			}
			else if (keyPress.KeyChar == 'd')
			{
				player1.MoveRaw(1.5 ,0);
			}
			else if (keyPress.KeyChar == 'a')
			{
				player1.MoveRaw(-1.5, 0);
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


