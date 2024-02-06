using System.Diagnostics;

namespace Rokéta.GameObjectModules.ConsoleObjectModules.ConsoleObjectSubclasses.PlayerModules
{
    public static class BoosterManager
    {
        public static List<Booster> Boosters = GetBoosters("SaveFiles\\Objects\\Boosters");
        private static List<Booster> GetBoosters(string parentFolder)
        {
            List<Booster> booster = new List<Booster>();
            if (File.Exists(parentFolder)) Debug.WriteLine($"Error in BoosterManager {parentFolder} Not found"); 
            else
            {
                foreach (string path in Directory.GetFiles(parentFolder))
                {
                    booster.Add()
                }
            }
        }
        
    }
}
