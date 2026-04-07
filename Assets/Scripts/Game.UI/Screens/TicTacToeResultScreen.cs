using Game.UI.Implementation;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Screens
{
	public class TicTacToeResultScreen : AbstractScreen
	{
		[SerializeField] 
		private TextMeshProUGUI winerName;
		
		[SerializeField]
		private Button continueButton;

		public Observable<Unit> ContinueButtonObservable => continueButton.OnClickAsObservable();

		public void SetWinerName(string winerName)
		{
			this.winerName.text = winerName;
		}
	}
}