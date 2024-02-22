namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys
{
	public class TopStrategy : IStartCordStrategy
	{
		public int[] GetStartCords(int height, int width, Padding padding, int textLength)
		{
			return new int[] { padding.Right, padding.Top };
		}
	}
}
