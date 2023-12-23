using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.SoundModules
{
	public static class SoundManager
	{
		public static Dictionary<string, int> SoundNodeFreqPairs = GetPairs("SafeFiles\\Sound\\SoundSetup.txt");
		public static Dictionary<string, Sound> Sounds = GetSounds("SafeFiles\\Sound\\GameSounds");
		public static List<Thread> MusicThreads = new List<Thread>();
		public static List<Thread> GameSoundThreads = new List<Thread>();
		public static void PlaySound(string SoundName)
		{
			try
			{
				if (SoundName.ToLower().Contains("music") && Globals.isMusicEnabled) Sounds[SoundName].Play();
				else if (!SoundName.ToLower().Contains("music") && !Globals.isGameSoundEnabled) Sounds[SoundName].Play(); 
			}
			catch(KeyNotFoundException e) 
			{ 
			
			}
			catch (Exception e)
			{
				Debug.WriteLine($"Error in SoundManager PlaySound[{SoundName}]:\n{e.Message}");
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
			Debug.WriteLine(Directory.GetFiles(pathToSounds).Length);
			Dictionary<string, Sound> sounds = new Dictionary<string, Sound>();
            foreach (string path in Directory.GetFiles(pathToSounds))
            {
				Debug.WriteLine(path);
				string name = path.Split("\\").Last().Split('.').First();
				Debug.WriteLine(name);
				sounds.Add(name,new Sound(path));
            }
			return sounds;
        }
	}
}
