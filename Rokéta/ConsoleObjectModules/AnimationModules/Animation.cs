using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.AnimationModules
{
	public class Animation
	{
		private bool repeat = false;
		private int CurrentTick = 0;
		public bool IsPaused = true;
		private ConsoleObject Parent;
		private Dictionary<int, AnimationObject> AnimationFrames;
		private AnimationObject currObj;
		public Animation(string filePath, ConsoleObject parent) 
		{
			Parent = parent;
			StreamReader sr = new StreamReader(filePath);
			int ticks = 0;
			AnimationFrames = new Dictionary<int, AnimationObject>();
			int height;
			while (!sr.EndOfStream)
			{
				
				string[] line = sr.ReadLine().Split(' ');
				height = int.Parse(line[1]);
				AnimationFrames.Add(ticks, ReadAnim(height, sr));
				ticks += int.Parse(line[0]);
			}
			currObj = AnimationFrames.Values.First();

        }
		private AnimationObject ReadAnim(int height, StreamReader sr)
		{

			if (height == 0) throw new Exception($"height is 0, could be error in the file ({GetType()}) typed object");
			
			string[] line = sr.ReadLine().Split(' ');
			int width = line.Length;
			CharInfo?[,] charInfos = new CharInfo?[height, width];
			for (int j = 0; j < width; j++)
			{
				if (Colors.colorDictionary[line[j]] != null) charInfos[0, j] = new CharInfo(background: Colors.colorDictionary[line[j]]);
				else charInfos[0, j] = null;
			}
			for (int i = 1; i < height; i++)
			{
				line = sr.ReadLine().Split(' ');
				for (int j = 0; j < width; j++)
				{
					if (Colors.colorDictionary[line[j]] != null) charInfos[i, j] = new CharInfo(background: Colors.colorDictionary[line[j]]);
					else charInfos[i, j] = null;

				}
			}
			AnimationObject animationObject = new AnimationObject(Parent, charInfos);
			return animationObject;
		}
		private AnimationObject? GetCurrentObject()
		{
			
			
			foreach (int tick in AnimationFrames.Keys)
			{
				if (CurrentTick <= tick)
				{
					return AnimationFrames[tick];
				}
			}
			
			return null;
		}
		public void Render(ref CharInfo[,] pixels)
		{
			if(IsPaused)
			{
				return;
			}
			//if(CurrentTick < AnimationFrames.Last().Key)
			//{
			//	Debug.WriteLine("sad");
			//}
			AnimationObject? animationObject = GetCurrentObject();
			if (animationObject != null)
			{
				animationObject.X = Parent.X;
				animationObject.Y = Parent.Y - Parent.Height/2;	
				//Debug.WriteLine(CurrentTick);

				animationObject.insertToMatrix(ref pixels);
			}
			CurrentTick++;

		}
		
	}
}
