using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.GameObjectModules
{
	public class GameObject
	{
		public double X { get; set; }
		public double Y { get; set; }

		// X = 0, Y = 0 a bal felső pont
		public int Z_Index { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		protected CharInfo?[,] CharInfos { get; set; }
		public string? FilePath { get; set; }

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
		public virtual void insertToMatrix(ref CharInfo[,] pixels)
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
