using UnityEngine;

namespace Game.UI
{
	public interface IScreen
	{
		Transform RootTransform { get; }
		
		void SetActive(bool isActive);
	}
}