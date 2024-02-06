using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public static class BoosterManager
    {
        private static Dictionary<string,Booster> Boosters = GetBoosters("SaveFiles\\Objects\\Boosters");
        private static Dictionary<string, Booster> GetBoosters(string parentFolder)
        {
            Dictionary<string, Booster> boosters = new Dictionary<string, Booster>();
            if (File.Exists(parentFolder)) Debug.WriteLine($"Error in BoosterManager {parentFolder} Not found"); 
            else
            {
                foreach (string path in Directory.GetFiles(parentFolder))
                {
                    boosters.Add(getBoosterName(path) ,makeBooster(path));
                }
            }
            return boosters;
        }
		private static Booster makeBooster(string filePath)
		{
			using (StreamReader sr = new StreamReader(filePath))
			{
				string[] data = sr.ReadLine().Split(';');
                Debug.WriteLine(string.Join(";", data));
                int damage = int.Parse(data[0]);
				uint interval = uint.Parse(data[1]);
				string animpath = data[2];
				return new Booster(damage, interval, animpath);
			}
		}
        public static Booster GetBooster(string name)
        {
            Debug.WriteLine(getBoosterName(name));
            Debug.WriteLine(string.Join(", ", Boosters.Keys));
            return Boosters[getBoosterName(name)];   
        }
        private static string getBoosterName(string filePath)
        {
			if (filePath.Contains('\\'))
			{
				return filePath.Split('\\').Last().Split('.').First();
			}
            return filePath.Split('.').First();
            
		}
	}
}
