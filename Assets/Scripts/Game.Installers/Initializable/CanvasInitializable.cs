using UnityEngine;
using VContainer.Unity;

namespace Game.Installers
{
	public class CanvasInitializable : IInitializable
	{
		private readonly Canvas canvas;
		private readonly Camera gameCamera;

		public CanvasInitializable(Canvas canvas, Camera gameCamera)
		{
			this.canvas = canvas;
			this.gameCamera = gameCamera;
		}
		
		public void Initialize()
		{
			canvas.rootCanvas.worldCamera = gameCamera;
		}
	}
}