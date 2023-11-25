using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRenderer2.ConsoleObject
{
    public class ConsoleObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z_Index { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CharInfo[,] CharInfos { get; set; }

        public ConsoleObject(int x, int y, int zIndex, int width, int height, string? filePath = null)
        {
            X = x;
            Y = y;
            Z_Index = zIndex;
            Width = width;
            Height = height;
            CharInfos = new CharInfo[height, width];
            if (filePath != null)
            {
                readFile(filePath);
            }
        }
        void readFile(string filePath)
        {

        }
        public void Move(int x, int y)
        {
            X += x;
            Y += y;
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
    }
}
