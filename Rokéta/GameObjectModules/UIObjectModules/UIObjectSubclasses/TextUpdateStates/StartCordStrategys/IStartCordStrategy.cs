namespace Rokéta.GameObjectModules.UIObjectModules.UIObjectSubclasses.TextUpdateStates.StartCordStrategys
{
	public interface IStartCordStrategy
	{
		public int[] GetStartCords(int height, int width, Padding padding, int textLength);
	}
}
