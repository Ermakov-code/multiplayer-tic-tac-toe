using UnityEngine;

namespace Game.UI.Implementation
{
	public abstract class AbstractScreen : MonoBehaviour, IScreen
	{
		[field: SerializeField]
		public Transform RootTransform { get; private set; }

		public void SetActive(bool isActive)
		{
			RootTransform.gameObject.SetActive(isActive);
		}
	}
}