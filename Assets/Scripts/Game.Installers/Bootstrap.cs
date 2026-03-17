using Cysharp.Threading.Tasks;
using Game.Main;
using VContainer.Unity;

namespace Game.Installers
{
	public class Bootstrap : IPostInitializable
	{
		private readonly IApplicationStarter applicationStarter;

		public Bootstrap(IApplicationStarter applicationStarter)
		{
			this.applicationStarter = applicationStarter;
		}

		public void PostInitialize()
		{
			applicationStarter.Start().Forget();
		}
	}
}