using Cysharp.Threading.Tasks;

namespace Game.Main
{
	public interface IApplicationStarter
	{
		UniTask Start();
	}
}