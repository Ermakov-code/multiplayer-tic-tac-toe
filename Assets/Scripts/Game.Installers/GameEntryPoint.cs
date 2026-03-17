using Game.Main;
using VContainer.Unity;

namespace Game.Installers
{
	public class GameEntryPoint : IStartable
	{
		private readonly IGameStarter gameStarter;

		public GameEntryPoint(IGameStarter gameStarter)
		{
			this.gameStarter = gameStarter;
		}
		
		public void Start()
		{
			gameStarter.Start();
		}
	}
}