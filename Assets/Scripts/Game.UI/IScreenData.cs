using System;

namespace Game.UI
{
	public interface IScreenData
	{
		void SetData(object data);
	}

	public interface IScreenData<in T> : IScreenData
	{
		void IScreenData.SetData(object data)
		{
			if (data is not T tData)
			{
				throw new ArgumentException();
			}
			
			SetData(tData);
		}
		
		void SetData(T data);
	}
}