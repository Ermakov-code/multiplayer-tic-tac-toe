using System;
using Game.UI;
using Game.UI.Implementation;
using VContainer;
using VContainer.Unity;

namespace Game.Installers.StaticInstaller
{
	public static class ScreenSystemInstaller
	{
		public static void Install(IContainerBuilder builder)
		{
			builder.Register<ScreensManager>(Lifetime.Singleton).As<IScreensManager, IDisposable>();
			builder.Register<ScreensSystem>(Lifetime.Singleton).As<IScreensSystem>();
			
			builder.Register<ScreenSystemInitializable>(Lifetime.Singleton).As<IInitializable>();
			builder.Register<CanvasInitializable>(Lifetime.Singleton).As<IInitializable>();
		}
	}
}