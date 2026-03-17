using Game.Installers.StaticInstaller;
using Game.Main;
using Game.UI;
using Game.UI.Implementation;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Installers.Scopes
{
	public class GameLifetimeScope : LifetimeScope
	{
		[SerializeField]
		private Camera gameCamera;
		[SerializeField]
		private ScreensManagerConfig screensManagerConfig;
		[SerializeField]
		private Canvas screenSystemCanvas;

		protected override void Configure(IContainerBuilder builder)
		{
			builder.RegisterInstance(screensManagerConfig).As<IScreensManagerConfig>();
			builder.RegisterInstance(gameCamera).As<Camera>();
			builder.RegisterComponentInNewPrefab(screenSystemCanvas, Lifetime.Singleton);
			
			ScreenSystemInstaller.Install(builder);
			ScreenControllersInstaller.Install(builder);
			
			builder.Register<GameStarter>(Lifetime.Singleton).As<IGameStarter>();
			builder.RegisterEntryPoint<GameEntryPoint>();
		}
	}
}