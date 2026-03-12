using System;

namespace Game.UI
{
	public interface IScreenController
	{
		Type ScreenType { get; }
		IScreen ScreenView { get; }

		void OnCreate();
		void OnShow();
		void OnHide();
		
		void SetScreen(IScreen screen);
	}
	
	public interface IScreenController<TScreen> : IScreenController where TScreen : IScreen
	{
		Type IScreenController.ScreenType => typeof(TScreen);
		TScreen Screen { get; }
		IScreen IScreenController.ScreenView => Screen;
		
		void SetScreen(TScreen screen);

		void IScreenController.SetScreen(IScreen screen)
		{
			if (screen is not TScreen tScreen)
			{
				throw new ArgumentException($"{screen.GetType()} is not a {typeof(TScreen)}");
			}
			
			SetScreen(tScreen);
		}
	}
}