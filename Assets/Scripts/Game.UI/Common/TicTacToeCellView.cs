using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Common
{
	public class TicTacToeCellView : MonoBehaviour
	{
		[SerializeField]
		private Button button;
		[SerializeField]
		private Image image;
		[SerializeField]
		private TextMeshProUGUI label;

		public Observable<Unit> ButtonClickedObservable => button.OnClickAsObservable();

		public void SetVisual(Sprite sprite)
		{
			image.sprite = sprite;
		}
		
		public void SetLabel(string label)
		{
			this.label.text = label;
		}
	}
}