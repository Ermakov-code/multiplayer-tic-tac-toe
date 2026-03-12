using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Game.UI.Implementation
{
	public class ScreensSystem : IScreensSystem
	{
		private readonly IScreensManager screensManager;
		
		private readonly Dictionary<Type, IScreenController> screenControllersMap = new ();
		private readonly Stack<IScreenController> history = new ();
		
		public ScreensSystem(IScreensManager screensManager)
		{
			this.screensManager = screensManager;
		}

		public UniTask Initialize()
		{
			return screensManager.Initialize();
		}

		public async UniTask<T> Push<T>() where T : IScreenController
		{
			var screenController = GetScreenController<T>();
			
			var inFirstCreate = !screensManager.IsInstantiated(screenController.ScreenType);
			var screen = await screensManager.GetScreen(screenController.ScreenType);
			
			screen.SetActive(true);

			history.Push(screenController);
			
			screenController.SetScreen(screen);

			if (inFirstCreate)
			{
				screenController.OnCreate();
			}
			
			screenController.OnShow();

			return screenController;
		}
		
		public async UniTask Pop()
		{
			if (history.Count == 0)
			{
				return;
			}
			
			var screenController = history.Pop();
			var screen = await screensManager.GetScreen(screenController.ScreenType);
			
			screenController.OnHide();
			screen.SetActive(false);
		}

		public void RegisterScreenController(IScreenController screenController)
		{
			screenControllersMap.TryAdd(screenController.GetType(), screenController);
		}
		
		public void UnregisterScreenController(IScreenController screenController)
		{
			screenControllersMap.Remove(screenController.GetType());
		}

		private T GetScreenController<T>() where T : IScreenController
		{
			var controllerType = typeof(T);
			
			if (!screenControllersMap.TryGetValue(controllerType, out var screenController))
			{
				throw new ArgumentException($"Screen controller with {controllerType} not found");
			}

			return (T)screenController;
		}
	}
}