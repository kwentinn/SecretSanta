using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SecretSanta.DomainTest")]
namespace SecretSanta.Domain
{
	/// <summary>
	/// Represents a Secret santa draw
	/// </summary>
	internal class SecretSantaDraw
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }

		private DateTime _createdAt;

		private List<SecretSantaDrawLine> _secretSantaDrawLines = new List<SecretSantaDrawLine>();

		internal SecretSantaDraw(Guid id, string name, DateTime? createdAt = null)
		{
			if (createdAt == null) createdAt = DateTime.UtcNow;

			_createdAt = createdAt.Value;
			Id = id;
			Name = name;
		}

		internal List<SecretSantaDrawLine> Draw(List<User> users)
		{
			if (users is null) throw new ArgumentNullException(nameof(users));

			int count = users.Count;


			return _secretSantaDrawLines;
		}
	}
}
