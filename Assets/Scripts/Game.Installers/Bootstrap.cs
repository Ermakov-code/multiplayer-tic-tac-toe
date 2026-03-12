using Cysharp.Threading.Tasks;
using Game.Main;
using Game.UI;
using VContainer.Unity;

namespace Game.Installers
{
	public class Bootstrap : IPostInitializable
	{
		private readonly IApplicationStarter applicationStarter;
		private readonly IScreensSystem screensSystem;

		public Bootstrap(IApplicationStarter applicationStarter, IScreensSystem screensSystem)
		{
			this.applicationStarter = applicationStarter;
			this.screensSystem = screensSystem;
		}

		public async void PostInitialize()
		{
			await screensSystem.Initialize();
			
			applicationStarter.Start().Forget();
		}
	}
}