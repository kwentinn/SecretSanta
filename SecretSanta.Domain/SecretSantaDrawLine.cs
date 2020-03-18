using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SecretSanta.DomainTest")]
namespace SecretSanta.Domain
{
	/// <summary>
	/// Represents a secret santa draw line
	/// </summary>
	internal class SecretSantaDrawLine
	{
		public Guid Id { get; private set; }
		public User From { get; private set; }
		public User To { get; private set; }

		internal SecretSantaDrawLine(Guid id, User from, User to)
		{
			Id = id;
			From = from;
			To = to;
		}

		internal static SecretSantaDrawLine Create(User from, User to)
		{
			return new SecretSantaDrawLine(Guid.NewGuid(), from, to);
		}
	}
}
