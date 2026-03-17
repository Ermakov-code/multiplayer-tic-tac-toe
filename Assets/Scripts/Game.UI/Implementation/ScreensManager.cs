using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.UI.Implementation
{
	public class ScreensManager : IScreensManager, IDisposable
	{
		private readonly Dictionary<Type, IScreen> instantiatedScreens = new ();
		
		private readonly IScreensManagerConfig config;
		private readonly Canvas canvas;

		public ScreensManager(IScreensManagerConfig config,  Canvas canvas)
		{
			this.config = config;
			this.canvas = canvas;
		}
		
		public UniTask Initialize()
		{
			return UniTask.CompletedTask;
		}
		
		public async UniTask<IScreen> GetScreen(Type screenType)
		{
			if (instantiatedScreens.TryGetValue(screenType, out var screen))
			{
				return screen;
			}

			var createdScreen = await CreateScreen(screenType);

			instantiatedScreens.Add(screenType, createdScreen);
			
			return createdScreen;
		}

		public bool IsInstantiated(Type screenType)
		{
			return instantiatedScreens.ContainsKey(screenType);
		}

		private UniTask<IScreen> CreateScreen(Type screenType)
		{
			if (!config.ScreenPrefabsMap.TryGetValue(screenType, out var screenPrefab))
			{
				throw new ArgumentException($"Screen with type {screenType} not found");
			}

			var result = Object.Instantiate(screenPrefab, canvas.transform);
			
			return UniTask.FromResult<IScreen>(result);
		}
		
		public void Dispose()
		{
			foreach (var (type, screen) in instantiatedScreens)
			{
				if (screen.RootTransform != null)
				{
					Object.DestroyImmediate(screen.RootTransform.gameObject);
				}
			}
			
			instantiatedScreens.Clear();
		}
	}
}