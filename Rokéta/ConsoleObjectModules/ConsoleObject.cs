using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roketa.ConsoleObjectModules
{
    public class ConsoleObject
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Z_Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CharInfo[,] CharInfos { get; set; }
        public string? FilePath;

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
        public void MoveRaw(int x, int y)
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
        public void MoveMotion(double x, double y, int currentGameThicks)
        {

			if (canMoveX(x/currentGameThicks))
            {
                X += x / currentGameThicks;
            }
            if (canMoveY(y/currentGameThicks))
            {
                //azert -= mert kulonben +ra le menne
                Y -= y / currentGameThicks;
            }
        }
        public bool canMoveX(double x)
        {
            int offset;
            if(int.TryParse(x.ToString(), out _)) offset = 0;
			else offset = 1;
			if (x + X + Width-offset <= Console.WindowWidth && x + X >= 0)
            {
                return true;
            }
            return false;
		}
        public bool canMoveY(double y)
        {
			int offset;
            if (int.TryParse(y.ToString(), out _)) offset = 0;
            else offset = 1;
			if (Y + Height - y - offset <= Console.WindowHeight && Y - y >= 0)
            {
                return true;
            }
            return false;
		}
        public bool canMove(double x, double y)
        {
            if(canMoveX(x) && canMoveY(y)) return true;
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
					pixels[i + (int)Y, j + (int)X] = CharInfos[i, j];
				}
			}

		}
	}
}
