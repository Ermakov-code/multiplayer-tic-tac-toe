using Cysharp.Threading.Tasks;
using Game.UI;
using Game.UI.Screens;

namespace Game.Main
{
	public class GameStarter : IGameStarter
	{
		private readonly IScreensSystem screensSystem;

		public GameStarter(IScreensSystem screensSystem)
		{
			this.screensSystem = screensSystem;
		}
		
		public async UniTask Start()
		{
			await screensSystem.Push<MainScreenController>();
		}
	}
}