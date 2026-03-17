using Cysharp.Threading.Tasks;

namespace Game.Main
{
	public interface IGameStarter
	{
		UniTask Start();
	}
}