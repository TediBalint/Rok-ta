using Roketa.ConsoleObjectModules;
using Rokéta.GameObjectModules.ConsoleObjectModules;
using System.Diagnostics;

namespace Rokéta.ConsoleObjectModules.AnimationModules
{
    public class Animation : ConsoleObject
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
				IsVissible = !value;
				if (!value && !Sw.IsRunning)
				{
					Sw.Start(); 
				}
			}
		}
		private ConsoleObject Parent;
		private Dictionary<double, AnimationObject> AnimationFrames;
		public AnimationObject? currObject { get; private set; }
		public Animation(string filePath, ConsoleObject parent,bool _repeat = false) : base(parent.X, parent.Y, parent.Z_Index, 0, 0, null)
		{
			repeat = _repeat;
			Parent = parent;
			StreamReader sr = new StreamReader(filePath);
			IsPaused = bool.Parse(sr.ReadLine());
			IsVissible = !IsPaused;
			double ticks = 0;
			AnimationFrames = new Dictionary<double, AnimationObject>();
			while (!sr.EndOfStream)
			{
				string[] line = sr.ReadLine().Split(' ');
				Height = int.Parse(line[1]);
				AnimationFrames.Add(ticks, ReadAnim(Height, sr));
				ticks += double.Parse(line[0]);
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
			
			animationObject.Xoffset = double.Parse(line[0]);
			animationObject.Yoffset = double.Parse(line[1]);
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
			else IsDisposed = true;
			return null;
		}
		public override void Update(ref CharInfo[,] pixels)
		{
			if(IsVissible)
			{
				AnimationObject? animationObject = GetCurrentObject();
				
				if (animationObject != null)
				{
					Height = animationObject.Height;
					Width = animationObject.Width;
					double x = Parent.X + animationObject.Xoffset;
					double y = Parent.Y - Parent.Height / 2 - animationObject.Yoffset;
					X = x;
					Y = y;
					animationObject.SetPos(x, y);
					animationObject.Update(ref pixels);
				}
			}
		}
        public override bool IsCollision(ConsoleObject otherObject)
        {
			if (currObject!= null) return currObject.IsCollision(otherObject);
			return false;
        }
        public override void OnCollision(ConsoleObject otherObject)
		{
			return;
		}
	}
}
