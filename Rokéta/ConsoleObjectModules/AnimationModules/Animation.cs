using Roketa.ConsoleObjectModules;
using Rokéta.ConsoleObjectModules.AnimationModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.ConsoleObjectModules.Animation
{
	public class Animation
	{
		private int CurrentTick = 0;
		public bool IsPaused = true;
		private ConsoleObject Parent;
		private Dictionary<int, AnimationObject> AnimationFrames;
		public Animation(string filePath, ConsoleObject parent) 
		{
			Parent = parent;
			StreamReader sr = new StreamReader(filePath);
			int ticks, height;
			while (!sr.EndOfStream)
			{
				string[] line = sr.ReadLine().Split(' ');
				ticks = int.Parse(line[0]);
				height = int.Parse(line[1]);
				AnimationFrames.Add(ticks, ReadAnim(height, sr));
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
				charInfos[0, j] = new CharInfo(background: Colors.colorDictionary[line[j]]);
			}
			for (int i = 1; i < height; i++)
			{
				line = sr.ReadLine().Split(' ');
				for (int j = 0; j < width; j++)
				{
					charInfos[i, j] = new CharInfo(background: Colors.colorDictionary[line[i]]);
				}
			}
			AnimationObject animationObject = new AnimationObject(Parent, charInfos);
			return animationObject;
		}
		private AnimationObject? GetCurrentObject()
		{
			if(!IsPaused)
			{
				foreach (int tick in AnimationFrames.Keys)
				{
					if (CurrentTick > tick)
					{
						return AnimationFrames[tick];
					}
				}
			}
			return null;
		}
		public void Render(ref CharInfo[,] pixels)
		{
			AnimationObject? anim = GetCurrentObject();
			if (anim != null)
			{
				anim.insertToMatrix(ref pixels);
			}
		}
	}
}
