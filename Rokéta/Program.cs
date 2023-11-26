using System.Diagnostics;
using Roketa.Renderer;
using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.PlayerModules;

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
	Console.CursorVisible=false;
	int width = Console.WindowWidth;
	int height = Console.WindowHeight;	
	
	Renderer renderer = new Renderer(width,height);

	// ConsoleObjectList sorted by Zindex for render 
	ConsoleObjectManager consoleObjectManager = new ConsoleObjectManager(width,height);
	ConsoleObject background = consoleObjectManager.BuildConsoleObject(0, 0, 0, width, height);
	background.Fill(ConsoleColor.Red);
	ConsoleObject obj2 = consoleObjectManager.BuildConsoleObject(40, 20, 1, 5, 5, filePath: "SafeFiles\\Objects\\Obj2.txt");
	ConsoleObject obj3 = consoleObjectManager.BuildConsoleObject(10, 20, 1, 5, 5, filePath: "SafeFiles\\Objects\\Obj2.txt");
	Player player1 = consoleObjectManager.BuildPlayer("Kindian", 20, 20, 2, 5, 5, filePath: "SafeFiles\\Objects\\Obj1.txt");
	ConsoleObject obj4 = consoleObjectManager.BuildConsoleObject(50, 20, 1, 5, 5, filePath: "SafeFiles\\Objects\\Obj2.txt");

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
		if (obj2State)
		{
			if (obj2.canMoveX(speed / currentGameThicks)) obj2.MoveMotion(speed, 0, currentGameThicks);
			else obj2State = false;
		}
		else
		{
			if (obj2.canMoveX(-speed/currentGameThicks)) obj2.MoveMotion(-speed, 0, currentGameThicks);
			else obj2State = true;
		}
		if (obj2State2)
		{
			if (obj2.canMoveY(speed / currentGameThicks)) obj2.MoveMotion(0, speed, currentGameThicks);
			else obj2State2 = false;
		}
		else
		{
			if (obj2.canMoveY(-speed / currentGameThicks)) obj2.MoveMotion(0, -speed, currentGameThicks);
			else obj2State2 = true;
		}
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
				player1.MoveRaw(0, 1);
			}
			else if (keyPress.KeyChar == 's')
			{
				player1.MoveRaw(0, -1);
			}
			else if (keyPress.KeyChar == 'd')
			{
				player1.MoveRaw(1, 0);
			}
			else if (keyPress.KeyChar == 'a')
			{
				player1.MoveRaw(-1, 0);
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


