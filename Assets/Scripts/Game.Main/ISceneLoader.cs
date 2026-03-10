using Cysharp.Threading.Tasks;

namespace Game.Main
{
	public interface ISceneLoader
	{
		UniTask LoadScene(string sceneName);
	}
}