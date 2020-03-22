using System;
using System.Threading;

namespace SecretSanta.Domain.Services
{
	public interface IRandom
	{
		int Next(int min, int max);
	}

	public class ThreadSafeRandom : IRandom
	{
		[ThreadStatic]
		private Random _random;

		public Random ThisThreadRandom =>
			_random
			??
			(_random = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId)));

		public int Next(int min, int max) => ThisThreadRandom.Next(min, max);
	}
}
