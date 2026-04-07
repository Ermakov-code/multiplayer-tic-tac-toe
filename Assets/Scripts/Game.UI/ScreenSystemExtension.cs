using Cysharp.Threading.Tasks;

namespace Game.UI
{
	public static class ScreenSystemExtension
	{
		public static UniTask<T> PushAsync<T>(this IScreensSystem screensSystem) where T : IScreenController
		{
			return screensSystem.Push<T, object>(null);
		}
		
		public static void Push<T>(this IScreensSystem screensSystem) where T : IScreenController
		{
			screensSystem.Push<T, object>(null).Forget();
		}
	}
}