using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
using Rokéta.Statics;
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
		private bool repeat;
		private double CurrentTick = 0;
		public bool IsPaused = true;
		private ConsoleObject Parent;
		private Dictionary<double, AnimationObject> AnimationFrames;
		public Animation(string filePath, ConsoleObject parent, bool _repeat = false) 
		{
			repeat = _repeat;
			Parent = parent;
			StreamReader sr = new StreamReader(filePath);
			double ticks = 0;
			AnimationFrames = new Dictionary<double, AnimationObject>();
			int height;
			while (!sr.EndOfStream)
			{
				
				string[] line = sr.ReadLine().Split(' ');
				height = int.Parse(line[1]);
				AnimationFrames.Add(ticks, ReadAnim(height, sr));
				ticks +=  double.Parse(line[0]) / Globals.currentGameThicks;
			}
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
			line = sr.ReadLine().Split(' ');
			AnimationObject animationObject = new AnimationObject(Parent, charInfos);
			
			animationObject.xOffset = double.Parse(line[0]);
			animationObject.yOffset = double.Parse(line[1]);
			return animationObject;
		}
		private AnimationObject? GetCurrentObject()
		{
			foreach (double tick in AnimationFrames.Keys)
			{

				if (CurrentTick/Globals.currentGameThicks <= tick)
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
			AnimationObject? animationObject = GetCurrentObject();
			if (animationObject != null)
			{
				animationObject.X = Parent.X + animationObject.xOffset;
				animationObject.Y = Parent.Y - Parent.Height/2 - animationObject.yOffset;
				animationObject.insertToMatrix(ref pixels);
			}
			else if(repeat) CurrentTick = 0;
			CurrentTick++;
		}
		
	}
}
