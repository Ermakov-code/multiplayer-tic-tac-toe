namespace Game.Main.Modes
{
	public interface IGameMode
	{
		void Start();
		void Complete();

		void RegisterSystem(IGameModeSystem system);
		void UnregisterSystem(IGameModeSystem system);
	}
}