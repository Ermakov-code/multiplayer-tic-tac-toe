namespace Game.UI.Implementation
{
	public class AbstractScreenController<TScreen> : IScreenController<TScreen> where TScreen : IScreen
	{
		public TScreen Screen { get; private set; }

		public virtual void OnCreate() { }
		public virtual void OnShow() { }
		public virtual void OnHide() { }
		
		public void SetScreen(TScreen screen)
		{
			Screen = screen;
		}
	}
}