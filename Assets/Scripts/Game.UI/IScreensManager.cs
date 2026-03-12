using System;
using Cysharp.Threading.Tasks;

namespace Game.UI
{
	public interface IScreensManager
	{
		UniTask Initialize();
		UniTask<IScreen> GetScreen(Type screenType);
		
		bool IsInstantiated(Type screenType);
	}
}