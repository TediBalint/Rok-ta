namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys
{
	public interface IStartCordStrategy
	{
		public int[] GetStartCords(int width, int height, int textLength, Padding padding);
	}
}
