using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roketa.ConsoleObject
{
    public class ConsoleObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        private int lastX = -1;
        private int lastY = -1;
        public int Z_Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CharInfo[,] CharInfos { get; set; }
        private string? FilePath;

        public ConsoleObject(int x, int y, int zIndex, int width, int height,string? filePath = null)
        {
            X = x;
            Y = y;
            Z_Index = zIndex;
            Width = width;
            Height = height;
            FilePath = filePath;
            CharInfos = new CharInfo[height, width];
            if (filePath != null)
            {
                readFile();
            }
        }
        private void readFile()
        {
            StreamReader sr = new StreamReader(FilePath);
            int index = 0;
            while(!sr.EndOfStream) 
            {
                string[] line = sr.ReadLine().Split(' ');

				for (int i = 0; i < line.Length; i++)
                {
                    CharInfo newCharInfo = new CharInfo(background: Colors.colorDictionary[line[i]]);
                    CharInfos[index, i] = newCharInfo;
                }
                index++;
            }
        }
        public void Move(int x, int y)
        {
            if (canMoveX(x))
            {
				X += x;
			}
            if(canMoveY(y))
            {
				//azert -= mert kulonben +ra le menne
				Y -= y;
			}

		}
        public bool canMoveX(int x)
        {
			if (x + X + Width <= Console.WindowWidth && x + X >= 0)
            {
                return true;
            }
            return false;
		}
        public bool canMoveY(int y)
        {
			if (Y + Height - y <= Console.WindowHeight && Y - y >= 0)
            {
                return true;
            }
            return false;
		}
        public bool canMove(int x, int y)
        {
            bool[] conditions = { x + X + Width <= Console.WindowWidth, x + X >= 0, Y + Height - y <= Console.WindowHeight, Y - y >= 0 };
			if (conditions.All(x => x))
            {
                return true;
            }
            return false;
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
        public void insertToMatrix(ref CharInfo[,] pixels)
        {
            //ehhez lehet kell algoritmus amitol gyorsabb lesz????


			for (int i = 0; i < Height; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					pixels[i + Y, j + X] = CharInfos[i, j];
				}
			}

		}
	}
}
