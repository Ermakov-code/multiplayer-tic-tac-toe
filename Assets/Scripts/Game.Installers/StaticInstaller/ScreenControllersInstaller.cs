using System;
using Game.UI;
using Game.UI.Screens;
using VContainer;
using VContainer.Unity;

namespace Game.Installers.StaticInstaller
{
	public static class ScreenControllersInstaller
	{
		public static void Install(IContainerBuilder builder)
		{
			builder.Register<MainScreenController>(Lifetime.Singleton).As<IScreenController>();
			
			builder.Register<ScreenControllersInitializable>(Lifetime.Singleton).As<IInitializable, IDisposable>();
		}
	}
}