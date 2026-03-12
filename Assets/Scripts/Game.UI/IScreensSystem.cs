using Cysharp.Threading.Tasks;

namespace Game.UI
{
	public interface IScreensSystem
	{
		UniTask Initialize();
		
		UniTask<T> Push<T>() where T : IScreenController;
		UniTask Pop();
		
		void RegisterScreenController(IScreenController screenController);
		void UnregisterScreenController(IScreenController screenController);
	}
}