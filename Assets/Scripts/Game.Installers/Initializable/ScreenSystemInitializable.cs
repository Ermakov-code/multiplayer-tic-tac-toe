using Game.UI;
using VContainer.Unity;

namespace Game.Installers
{
	public class ScreenSystemInitializable : IInitializable
	{
		private readonly IScreensSystem screensSystem;

		public ScreenSystemInitializable(IScreensSystem screensSystem)
		{
			this.screensSystem = screensSystem;
		}

		public void Initialize()
		{
			screensSystem.Initialize();
		}
	}
}