using Game.Main;
using VContainer.Unity;

namespace Game.Installers
{
	public class Bootstrap : IInitializable
	{
		private readonly ISceneLoader sceneLoader;

		public Bootstrap(ISceneLoader sceneLoader)
		{
			this.sceneLoader = sceneLoader;
		}
		
		public void Initialize()
		{
			sceneLoader.LoadScene(SceneId.GAME);
		}
	}
}