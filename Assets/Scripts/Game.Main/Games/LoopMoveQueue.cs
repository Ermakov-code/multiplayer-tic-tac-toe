namespace Game.Main.Games
{
	public class LoopMoveQueue : IMoveQueue
	{
		private readonly string[] id;
		private int pointer = 0;
		
		public LoopMoveQueue(params string[] id)
		{
			this.id = id;
		}

		public string GetCurrent()
		{
			return id[pointer];
		}
		
		public void Move()
		{
			pointer = (pointer + 1) % id.Length;
		}
	}

	public interface IMoveQueue
	{
		string GetCurrent();
		
		void Move();
	}
}