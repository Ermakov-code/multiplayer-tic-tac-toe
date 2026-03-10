using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Game.Main
{
	public class SceneLoader : ISceneLoader
	{
		public UniTask LoadScene(string sceneName)
		{
			return SceneManager.LoadSceneAsync(sceneName).ToUniTask();
		}
	}
}