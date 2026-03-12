using System;
using System.Collections.Generic;
using Game.UI.Implementation;

namespace Game.UI
{
	public interface IScreensManagerConfig
	{
		IReadOnlyDictionary<Type, AbstractScreen> ScreenPrefabsMap { get; }
	}
}