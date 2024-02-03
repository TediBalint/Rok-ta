using Roketa.ConsoleObjectModules;
using System.Diagnostics;

namespace Rokéta.GameObjectModules
{
	public abstract class GameObject
	{
		public bool IsDisposed { get; set; } = false;
		public double X { get; protected set; }
		public double Y { get; protected set; }
		// X = 0, Y = 0 a bal felső pont
		public int Z_Index { get; protected set; }
		public int Width { get; protected set; }
		public int Height { get; protected set; }
		protected CharInfo?[,] CharInfos { get; set; }
		public string? FilePath { get; protected set; }

		public int Top => (int)Y;
		public int Left => (int)X;
		public int Bot => (int)(Y + Height);
		public double Right => (int)(X+Width);
		public double[] Mid => new double[] {(int)(X+Width/2), (int)(Y+Height/2) };
		public GameObject(double x, double y, int zIndex, int? width, int? height, string? filePath)
		{
			X = x;
			Y = y;
			Z_Index = zIndex;
			
			if (filePath != null && File.Exists(filePath))
			{
				FilePath = filePath;
				int[] sizes = getWidthHeightFromFile();
				Width = sizes[0];
				Height = sizes[1];
				CharInfos = new CharInfo?[Height, Width];
				readFile();
			}
			else if (width == null || height == null)
			{
				throw new Exception("ConsoleObject has no width,height and filepath");
			}
			else
			{
				Width = width.Value;
				Height = height.Value;
				CharInfos = new CharInfo?[height.Value, width.Value];
			}
		}
		protected bool IsXOverlapping(GameObject otherObject)
		{
			return Left <= otherObject.Right && Right >= otherObject.Left;
		}
		protected bool IsYOverlapping(GameObject otherObject)
		{
			return Top <= otherObject.Bot && Bot >= otherObject.Top;
		}
		public bool IsXOverlapping(GameObject otherObject, int Offset)
		{
			return Left - Offset <= otherObject.Right && Right + Offset >= otherObject.Left;
		}
		public bool IsYOverlapping(GameObject otherObject, int Offset)
		{
			return Top - Offset <= otherObject.Bot && Bot + Offset >= otherObject.Top;
		}
		private int[] getWidthHeightFromFile()
		{
			// filepath not null
			int height = 1;
			StreamReader sr = new StreamReader(FilePath);
			int width = sr.ReadLine().Split(' ').Length;
			while (!sr.EndOfStream)
			{
				sr.ReadLine();
				height++;
			}
			sr.Close();
			return new int[2] { width, height };
		}
		protected void readFile()
		{

			StreamReader sr;
			try
			{
				sr = new StreamReader(FilePath);
			}
			catch (FileNotFoundException)
			{
				throw new Exception("File not found");
			}
			int index = 0;
			while (!sr.EndOfStream)
			{
				string[] line = sr.ReadLine().Trim().Split(' ');

				for (int i = 0; i < line.Length; i++)
				{
					if (!(Colors.colorDictionary[line[i]] == null))
					{
						CharInfo newCharInfo = new CharInfo(background: Colors.colorDictionary[line[i]]);
						CharInfos[index, i] = newCharInfo;
					}
					else
					{
						CharInfos[index, i] = null;
					}
				}
				index++;
			}
		}
		public virtual void Update(ref CharInfo[,] pixels)
		{
			insertToMatrix(ref pixels);
		}
		public void Fill(ConsoleColor color = ConsoleColor.Black)
		{
			CharInfo filledChar = new CharInfo(background: color);
			for (int i = 0; i < CharInfos.GetLength(0); i++)
			{
				for (int j = 0; j < CharInfos.GetLength(1); j++)
				{
					CharInfos[i, j] = filledChar;
				}
			}
		}
		public double GetDistance(int[] pos)
		{
			double distanceX = Math.Abs(pos[0] - X);
			double distanceY = Math.Abs(pos[1] - Y);
			return Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
		}
		public double GetDistance(GameObject gameObject)
		{
			return GetDistance(new int[] { (int)gameObject.X, (int)gameObject.Y });
		}
		private void insertToMatrix(ref CharInfo[,] pixels)
		{
			//ehhez lehet kell algoritmus amitol gyorsabb lesz????
			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					try
					{
						if (CharInfos[i, j] != null)
						{
							pixels[i + (int)Y, j + (int)X] = CharInfos[i, j].Value;
						}
					}
					catch (IndexOutOfRangeException)
					{
						Debug.WriteLine("Out of map");
					}
				}
			}
		}
	}
}
