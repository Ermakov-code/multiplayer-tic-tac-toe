using Game.UI.Implementation;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Screens
{
	public class MainScreen : AbstractScreen
	{
		[SerializeField]
		private Button gameButton;

		public Observable<Unit> StartButtonObservable => gameButton.OnClickAsObservable();
	}
}