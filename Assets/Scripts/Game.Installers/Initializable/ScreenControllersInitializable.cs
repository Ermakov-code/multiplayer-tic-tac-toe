using System;
using System.Collections.Generic;
using Game.UI;
using VContainer.Unity;

namespace Game.Installers
{
	public class ScreenControllersInitializable : IInitializable, IDisposable
	{
		private readonly IEnumerable<IScreenController> screenControllers;
		private readonly IScreensSystem screensSystem;

		public ScreenControllersInitializable(IEnumerable<IScreenController> screenControllers, IScreensSystem screensSystem)
		{
			this.screenControllers = screenControllers;
			this.screensSystem = screensSystem;
		}
		
		public void Initialize()
		{
			foreach (var screenController in screenControllers)
			{
				screensSystem.RegisterScreenController(screenController);
			}
		}

		public void Dispose()
		{
			foreach (var screenController in screenControllers)
			{
				screensSystem.UnregisterScreenController(screenController);
			}
		}
	}
}