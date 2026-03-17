using Game.Main;
using VContainer;
using VContainer.Unity;

namespace Game.Installers.Scopes
{
	public class RootLifetimeScope : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<SceneLoader>(Lifetime.Singleton).As<ISceneLoader>();
			builder.Register<ApplicationStarter>(Lifetime.Singleton).As<IApplicationStarter>();
			
			builder.Register<Bootstrap>(Lifetime.Singleton).As<IPostInitializable>();
		}
	}
}