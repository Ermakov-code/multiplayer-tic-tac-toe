using Cysharp.Threading.Tasks;
using Game.UI;
using Game.UI.Screens;

namespace Game.Main
{
	public class ApplicationStarter : IApplicationStarter
	{
		private readonly ISceneLoader sceneLoader;
		private readonly IScreensSystem screensSystem;

		public ApplicationStarter(ISceneLoader sceneLoader, IScreensSystem screensSystem)
		{
			this.sceneLoader = sceneLoader;
			this.screensSystem = screensSystem;
		}
		
		public async UniTask Start()
		{
			var screenTask = screensSystem.Push<MainScreenController>();
			var sceneTask = sceneLoader.LoadScene(SceneId.GAME);
			
			await UniTask.WhenAll(screenTask, sceneTask);
		}
	}
}