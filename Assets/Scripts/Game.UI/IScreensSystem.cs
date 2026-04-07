using Cysharp.Threading.Tasks;

namespace Game.UI
{
	public interface IScreensSystem
	{
		UniTask Initialize();
		
		UniTask<T> Push<T, TData>(TData data) where T : IScreenController;
		UniTask Pop();
		void PopAll();
		
		void RegisterScreenController(IScreenController screenController);
		void UnregisterScreenController(IScreenController screenController);
	}
}