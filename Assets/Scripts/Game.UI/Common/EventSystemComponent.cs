using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Common
{
	public class EventSystemComponent : MonoBehaviour
	{
		[SerializeField]
		private EventSystem eventSystem;

		private void Awake()
		{
			DontDestroyOnLoad(eventSystem.gameObject);
		}
	}
}