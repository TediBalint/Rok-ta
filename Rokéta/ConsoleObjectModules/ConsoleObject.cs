using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roketa.ConsoleObjectModules
{
    public abstract class ConsoleObject
    {
        public bool IsDisposed { get; protected set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double[] TR { 
            get 
            {
                return new double[] {X + Width, Y };    
            }
        }
        public double[] TL
        {
            get
            {
                return new double[] { X, Y };
            }
        }
        public double[] BR
        {
            get
            {
                return new double[] { X + Width, Y - Height};
            }
        }
        public double[] BL
        {
            get
            {
                return new double[] { X, Y-Height};
            }
        }
        // X = 0, Y = 0 a bal felső pont
        public int Z_Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CharInfo?[,] CharInfos { get; set; }
        public string? FilePath;

		public abstract void OnCollision(ConsoleObject otherObject);

		public ConsoleObject(int x, int y, int zIndex, int? width, int? height,string? filePath = null)
        {
            X = x;
            Y = y;
            Z_Index = zIndex;
            if(filePath != null && File.Exists(filePath))
            {
				FilePath = filePath;
				int[] sizes = getWidthHeightFromFile();
                Width = sizes[0];
                Height = sizes[1];
                

				CharInfos = new CharInfo?[Height, Width];
				
				readFile();
			}
            else if(width == null || height == null)
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
            while(!sr.EndOfStream)
            {
                sr.ReadLine();
                height++;
            }
            sr.Close();
            return new int[2] { width, height };
        }
        private void readFile()
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
					string[] line = sr.ReadLine().Split(' ');

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
        public void MoveRaw(double x, double y)
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
                    if(CharInfos[i, j] != null)
                    {
					    pixels[i + (int)Y, j + (int)X] = CharInfos[i, j].Value;
					}
				}
			}
		}
        public bool isCollision(ConsoleObject otherObject)
        {
            if 
            (
                // AABB algorithm
                otherObject != this &&
                (int)X < (int)(otherObject.X + otherObject.Width) &&
                (int)(X + Width) > (int)otherObject.X &&
                (int)Y < (int)(otherObject.Y + otherObject.Height) &&
                (int)(Y + Height)> (int)otherObject.Y                 
			)
			{
                return true; 
            }

            return false;
        }
	}
}
