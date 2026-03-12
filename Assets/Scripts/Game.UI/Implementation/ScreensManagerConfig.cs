using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.UI.Implementation
{
	[CreateAssetMenu(fileName = "ScreensManagerConfig", menuName = "Configs/ScreensManagerConfig")]
	public class ScreensManagerConfig : ScriptableObject, IScreensManagerConfig
	{
		private Dictionary<Type, AbstractScreen> screenPrefabsMap;
		
		[SerializeField]
		private List<AbstractScreen> screenPrefabs;

		public IReadOnlyDictionary<Type, AbstractScreen> ScreenPrefabsMap
		{
			get
			{
				screenPrefabsMap ??= screenPrefabs.ToDictionary(p => p.GetType(), p => p);
				
				return screenPrefabsMap;
			}
		}
	}
}