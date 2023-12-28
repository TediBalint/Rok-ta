using Rokéta.Statics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokéta.SoundModules
{
	public class Sound
	{
		private bool repeat;
		public List<SoundNode> sounds;

		public Sound(string _path)
		{
			sounds = new List<SoundNode>();
			ReadFile(_path);
		}
		public void Play()
		{
			Thread SoundThread = new Thread(() =>
			{
				do
				{
					foreach (SoundNode soundNode in sounds)
					{
						if (sounds.Count > 20 && Globals.isMusicEnabled) PlaySound(soundNode);
						else if (sounds.Count < 20 && Globals.isGameSoundEnabled) PlaySound(soundNode);
					}
				}
				while (repeat);
			});
			SoundThread.Start();
        }
		private void PlaySound(SoundNode soundNode)
		{
			if (!soundNode.isSleep()) soundNode.Play();
			else Thread.Sleep(soundNode.Duration);
		}
		private void ReadFile(string path)
		{
			try
			{
				StreamReader sr = new StreamReader(path);
				if(bool.Parse(sr.ReadLine())) repeat = true;
				else repeat = false;

				while (!sr.EndOfStream)
				{
					string[] line = sr.ReadLine().Split();
					if (line.Count() == 0) continue;
					int frequency;
					if (!int.TryParse(line[0], out frequency))
					{
						if (SoundManager.SoundNodeFreqPairs.ContainsKey(line[0]))
						{
							frequency = SoundManager.SoundNodeFreqPairs[line[0]];
						}
						else
						{
							Debug.WriteLine($"Error in Sound.cs: \n${line[0]} not in SoundManager.SoundNodeFreqPairs and not int");
						}
					}
					 
					int duration = int.Parse(line[1]);
					sounds.Add(new SoundNode(frequency, duration));
				}
			}
			catch(FileNotFoundException) 
			{
				Debug.WriteLine($"No File {path}");
			}
			catch (Exception e)
			{
				Debug.WriteLine($"Error in Sound.cs ReadFile :\n{e.Message}");
			}
			
		}
	}
}
