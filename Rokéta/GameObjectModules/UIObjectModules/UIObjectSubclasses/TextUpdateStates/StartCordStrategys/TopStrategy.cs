namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys
{
	public class TopStrategy : IStartCordStrategy
	{
		public int[] GetStartCords(int width, int height, int textLength, Padding padding)
		{
			return new int[] { padding.Right, padding.Top };
		}
	}
}
