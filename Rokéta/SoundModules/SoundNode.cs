namespace Rokéta.SoundModules
{
	public class SoundNode
	{
		private int Frequency { get; set; }
		public int Duration { get; private set; }
        public SoundNode(int _frequency, int _duration)
        {
			Frequency = _frequency;
			Duration = _duration;
        }
        public void Play()
		{
			Console.Beep(Frequency,Duration);			
		}
		public bool isSleep()
		{
			if (Frequency < 37) return true;
			return false;
		}
	}
}
