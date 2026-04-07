using System;
using System.Collections.Generic;

namespace Game.Main.Modes.Implementation
{
	public abstract class AbstractGameMode : IGameMode
	{
		public event Action Started = delegate { };
		public event Action Completed = delegate { };
		
		private readonly List<IGameModeSystem> systems = new ();

		public void Start()
		{
			systems.ForEach(system => system.Activate());
			
			OnStart();
			
			Started?.Invoke();
		}

		public void Complete()
		{
			OnComplete();
			
			Completed?.Invoke();
			
			systems.ForEach(system => system.Deactivate());
		}
		
		public void RegisterSystem(IGameModeSystem system)
		{
			systems.Add(system);
		}
		
		public void UnregisterSystem(IGameModeSystem system)
		{
			systems.Remove(system);
		}
		
		protected abstract void OnComplete();
		protected abstract void OnStart();
	}
}