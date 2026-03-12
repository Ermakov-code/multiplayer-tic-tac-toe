using Game.UI;
using Game.UI.Screens;
using VContainer;

namespace Game.Installers
{
	public static class ScreenControllersInstaller
	{
		public static void Install(IContainerBuilder builder)
		{
			builder.Register<MainScreenController>(Lifetime.Singleton).As<IScreenController>();
		}
	}
}