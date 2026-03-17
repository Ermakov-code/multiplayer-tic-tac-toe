using Cysharp.Threading.Tasks;

namespace Game.Main
{
	public class ApplicationStarter : IApplicationStarter
	{
		private readonly ISceneLoader sceneLoader;

		public ApplicationStarter(ISceneLoader sceneLoader)
		{
			this.sceneLoader = sceneLoader;
		}
		
		public async UniTask Start()
		{
			var sceneTask = sceneLoader.LoadScene(SceneId.GAME);
			
			await UniTask.WhenAll(sceneTask);
		}
	}
}