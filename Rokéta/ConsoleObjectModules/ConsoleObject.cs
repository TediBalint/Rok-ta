using Microsoft.Win32.SafeHandles;
using Rokéta.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
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
        public bool isMovable { get; protected set; } = true;
        public bool IsDisposed { get; set; } = false;
        public bool IsVissible { get; protected set; } = true;
        public bool canCollide { get; protected set; } = true;
        public double X { get; set; }
        public double Y { get; set; }
		
		// X = 0, Y = 0 a bal felső pont
		public int Z_Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CharInfo?[,] CharInfos { get; set; }
        public string? FilePath;
        public List<Animation> Animations { get; set; }
		public abstract void OnCollision(ConsoleObject otherObject);

		public ConsoleObject(double x, double y, int zIndex, int? width, int? height,string? filePath = null)
        {
            Animations = new List<Animation>();
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
        public virtual void MoveRaw(double x, double y)
        {
            if(isMovable)
            {
				X += x;
				//azert -= mert kulonben +ra le menne
				Y -= y;
				Snap();
			}
			
		}
        public virtual void MoveMotion(double x, double y, int currentGameThicks)
        {     
            if(isMovable)
            {
				X += x / currentGameThicks;
				Y -= y / currentGameThicks;
				Snap();
			}
            
        }
        public void Rotate(double angle)
        {
			


		}
        public virtual void Snap()
        {
            X = Math.Min(X, Console.WindowWidth-Width);
            X = Math.Max(X, 0);
            Y = Math.Min(Y, Console.WindowHeight-Height+1);
            Y = Math.Max(Y, 0);
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
        public virtual void insertToMatrix(ref CharInfo[,] pixels)
        {
			Snap();

			//ehhez lehet kell algoritmus amitol gyorsabb lesz????
            if(IsVissible)
            {
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
							Debug.WriteLine(i + " " + j);
						}


					}
				}
			}
			

            // render animations
            foreach (Animation anim in Animations)
            {
                anim.Render(ref pixels);
            }
        }
        protected virtual string getSaveString()
        {
            // double x, double y, int zIndex, int? width, int? height,string? filePath
            return $"{GetType().Name};{Math.Round(X,2)};{Math.Round(Y)};{Z_Index};{Width};{Height};{FilePath}";
        }
        public void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Encrypter.Encrypt(getSaveString()));
            Debug.WriteLine(Encrypter.Decrypt(Encrypter.Encrypt(getSaveString())));
        }
        public virtual bool isCollision(ConsoleObject otherObject)
        {
            if(!canCollide) return false;
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
