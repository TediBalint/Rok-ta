using ConsoleRenderer2.Renderer;
using System.Diagnostics;


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
		renderer.Buffer = matrixToVoid(pixels);
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
	CharInfo[,] pixels = new CharInfo[height, width];
	Renderer renderer = new Renderer(width,height);
    while (true)
    {
		renderer.Render();
		ConsoleKeyInfo keyPress = Console.ReadKey();
		if(keyPress.KeyChar == 'w')
		{

		}
		// KeyInputChecks go here

    }
	
}
CharInfo[] matrixToVoid(CharInfo[,] charInfos)
{
	CharInfo[] output = new CharInfo[charInfos.Length];
	int index = 0;
    foreach (CharInfo chr in output)
    {
		output[index++] = chr;   
    }
	return output;
}
Performance_BenchMark();