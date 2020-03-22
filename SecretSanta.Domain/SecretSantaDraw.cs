using SecretSanta.Domain.Exceptions;
using SecretSanta.Domain.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		public ReadOnlyCollection<SecretSantaDrawLine> SecretSantaDrawLines => _secretSantaDrawLines.AsReadOnly();

		internal SecretSantaDraw(Guid id, string name, DateTime? createdAt = null)
		{
			if (id == Guid.Empty) throw new ArgumentException(nameof(id));
			if (createdAt == null) createdAt = DateTime.UtcNow;

			_createdAt = createdAt.Value;
			Id = id;
			Name = name;
		}

		internal void Draw(ReadOnlyCollection<User> users, bool shuffleUsers, IListRandomizer listRandomizer)
		{
			if (users is null) throw new ArgumentNullException(nameof(users));
			if (listRandomizer is null) throw new ArgumentNullException(nameof(listRandomizer));
			if (users.Count < 3) throw new IncorrectNumberOfUsersException();

			List<User> tempUsers = new List<User>(users);
			if (shuffleUsers)
			{
				tempUsers = listRandomizer.Shuffle(tempUsers);
			}

			int indexTo;
			for (int indexFrom = 0; indexFrom < tempUsers.Count; indexFrom++)
			{
				indexTo = indexFrom + 1;
				if (indexTo >= tempUsers.Count)
				{
					indexTo = indexTo - tempUsers.Count;
				}
				_secretSantaDrawLines.Add(new SecretSantaDrawLine
				(
					Guid.NewGuid(),
					tempUsers[indexFrom],
					tempUsers[indexTo]
				));
			}
		}
	}
}
