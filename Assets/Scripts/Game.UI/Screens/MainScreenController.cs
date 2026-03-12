using Game.UI.Implementation;
using R3;
using UnityEngine;

namespace Game.UI.Screens
{
	public class MainScreenController : AbstractScreenController<MainScreen>
	{
		public override void OnCreate()
		{
			Screen.StartButtonObservable.Subscribe(_ => StartButtonClicked()).AddTo(Screen);
		}

		private void StartButtonClicked()
		{
			Debug.Log("---------START---------");
		}
	}
}