using Roketa.ConsoleObjectModules;
using Rokéta.Statics;
using System.Diagnostics;

namespace Rokéta.ConsoleObjectModules.AnimationModules
{
	public class Animation
	{
		private bool repeat;
		private Stopwatch Sw = new Stopwatch();
		public bool IsPaused
		{
			get
			{
				return !Sw.IsRunning;
			}
			set
			{
				if (!value && !Sw.IsRunning)
				{
					Sw.Start(); 
				}
			}
		}
		private ConsoleObject Parent;
		private Dictionary<double, AnimationObject> AnimationFrames;
		private bool destroyParent;
		public AnimationObject? currObject { get; private set; }
		public Animation(string filePath, ConsoleObject parent, bool _repeat = false, bool _destroyParent = false) 
		{
			destroyParent = _destroyParent;
			repeat = _repeat;
			Parent = parent;
			StreamReader sr = new StreamReader(filePath);
			IsPaused = bool.Parse(sr.ReadLine());
			double ticks = 0;
			AnimationFrames = new Dictionary<double, AnimationObject>();
			int height;
			while (!sr.EndOfStream)
			{
				
				string[] line = sr.ReadLine().Split(' ');
				height = int.Parse(line[1]);
				AnimationFrames.Add(ticks, ReadAnim(height, sr));
				ticks +=  double.Parse(line[0]);
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

				if (Sw.ElapsedMilliseconds <= tick)
				{
					currObject = AnimationFrames[tick];
					return AnimationFrames[tick];
				}
			}
			if (repeat)
			{
				Sw.Restart();
				currObject = AnimationFrames.Values.ToArray()[2];
				return currObject;
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
				animationObject.Snap();
				animationObject.insertToMatrix(ref pixels);
			}
			else if(destroyParent)
			{
				Parent.IsDisposed = true;
			}
		}
		
	}
}
