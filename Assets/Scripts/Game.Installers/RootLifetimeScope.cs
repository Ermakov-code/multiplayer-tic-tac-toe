using Game.Main;
using Game.UI;
using Game.UI.Implementation;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Installers
{
	public class RootLifetimeScope : LifetimeScope
	{
		[SerializeField]
		private ScreensManagerConfig screensManagerConfig;
		[SerializeField]
		private Canvas screenSystemCanvas;
		
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<SceneLoader>(Lifetime.Singleton).As<ISceneLoader>();
			builder.Register<ApplicationStarter>(Lifetime.Singleton).As<IApplicationStarter>();
			
			builder.RegisterInstance(screensManagerConfig).As<IScreensManagerConfig>();
			builder.RegisterComponentInNewPrefab(screenSystemCanvas, Lifetime.Singleton).DontDestroyOnLoad();
			
			ScreenSystemInstaller.Install(builder);
			ScreenControllersInstaller.Install(builder);
			
			builder.Register<Bootstrap>(Lifetime.Singleton).As<IPostInitializable>();
		}
	}
}