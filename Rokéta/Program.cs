using System.Diagnostics;
using Roketa.Renderer;
using Roketa.ConsoleObject;
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
	ConsoleObject background = consoleObjectManager.BuildConsoleObject(0,0,0, width, height);
	background.Fill(ConsoleColor.Red);
	ConsoleObject obj1 = consoleObjectManager.BuildConsoleObject(20, 20, 2, 5, 5, filePath:"SafeFiles\\Objects\\Obj1.txt");
	ConsoleObject obj2 = consoleObjectManager.BuildConsoleObject(40, 20, 1, 5, 5, filePath:"SafeFiles\\Objects\\Obj2.txt");
    consoleObjectManager.RenderObjects();
	renderer.Buffer = matrixToVector(consoleObjectManager.pixels);
	renderer.Render();
	


	// thread for inputs
	Thread thread2 = new Thread(() =>
	{
		while (true)
		{
			ConsoleKeyInfo keyPress = Console.ReadKey(true);
			if (keyPress.KeyChar == 'w')
			{
				obj1.Move(0, 1);
			}
			else if (keyPress.KeyChar == 's')
			{
				obj1.Move(0, -1);
			}
			else if (keyPress.KeyChar == 'd')
			{
				obj1.Move(1, 0);
			}
			else if (keyPress.KeyChar == 'a')
			{
				obj1.Move(-1, 0);
			}
		}

	});
	thread2.Start();

	bool obj2State = true;
	while (true)
	{
		if (obj2State)
		{
			if (obj2.canMoveX(1)) obj2.Move(1, 0);
			else obj2State = false;
		}
		else
		{
			if (obj2.canMoveX(-1)) obj2.Move(-1, 0);
			else obj2State = true;
		}
		consoleObjectManager.RenderObjects();
		renderer.Buffer = matrixToVector(consoleObjectManager.pixels);
		renderer.Render();
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

