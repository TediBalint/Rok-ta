using System.Diagnostics;

namespace Rokéta.SoundModules
{
	public static class SoundManager
	{
		public static Dictionary<string, int> SoundNodeFreqPairs = GetPairs("SaveFiles\\Sound\\SoundSetup.txt");
		public static Dictionary<string, Sound> Sounds = GetSounds("SaveFiles\\Sound\\GameSounds");
		public static void PlaySound(string SoundName)
		{
			try
			{
				Sounds[SoundName].Play();
			}
			catch (KeyNotFoundException e)
			{
				Debug.WriteLine($"No Key {SoundName} in Sounds.keys (SoundManager.cs) Error:\n{e.Message}");
			}
			catch (Exception e)
			{
				Debug.WriteLine($"Error in PlaySound (SoundManager.cs) Error: \n{e.Message}");
			}
		}
        private static Dictionary<string,int> GetPairs(string setupPath)
		{
			Dictionary<string, int> _soundNodeFreqPairs = new Dictionary<string, int>();
			StreamReader sr = new StreamReader(setupPath);
			while(!sr.EndOfStream)
			{
				string[] line = sr.ReadLine().Split(' ');
				_soundNodeFreqPairs.Add(line[0], int.Parse(line[1]));
			}
			return _soundNodeFreqPairs;
		}
		private static Dictionary<string, Sound> GetSounds(string pathToSounds)
		{
			Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();
            foreach (string path in Directory.GetFiles(pathToSounds))
            {
				string name = path.Split("\\").Last().Split('.').First();
				sounds.Add(name,new Sound(path));
            }
			return sounds;
        }
	}
}
