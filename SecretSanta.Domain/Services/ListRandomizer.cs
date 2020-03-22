using System.Collections.Generic;

namespace SecretSanta.Domain.Services
{
	public interface IListRandomizer
	{
		List<T> Shuffle<T>(List<T> listToShuffle);
	}

	public class ListRandomizer : IListRandomizer
	{
		private readonly IRandom _random;

		public ListRandomizer(IRandom random)
		{
			_random = random;
		}

		public List<T> Shuffle<T>(List<T> listToShuffle)
		{
			var resultList = new List<T>(listToShuffle);
			int j;
			for (int i = resultList.Count - 1; i >= 1; i--)
			{
				j = _random.Next(0, i);
				T tmp = resultList[j];
				resultList[j] = resultList[i];
				resultList[i] = tmp;
			}
			return resultList;
		}
	}
}
