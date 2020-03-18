using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SecretSanta.DomainTest")]
namespace SecretSanta.Domain
{
	internal class SecretSantaGroup
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }

		private List<User> _users = new List<User>();
		private List<SecretSantaDraw> _secretSantaDraws = new List<SecretSantaDraw>();

		public SecretSantaGroup(Guid id, string name)
		{
			Id = id;
			Name = name;
		}

		public User AddUser(User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			_users.Add(user);
			return user;
		}
		public bool RemoveUser(User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			return _users.Remove(user);
		}

		public SecretSantaDraw CreateDraw(string name)
		{
			if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(nameof(name));
			if (_users.Count % 2 != 0) throw new ApplicationException("Un nombre impair d'utilisateurs est nécessaire!");

			var newDraw = new SecretSantaDraw(Guid.NewGuid(), name);
			_secretSantaDraws.Add(newDraw);
			return newDraw;
		}
		public void Draw(Guid drawId)
		{
			SecretSantaDraw draw = _secretSantaDraws.Find(d => d.Id == drawId);

			if (draw is null) throw new ApplicationException($"Draw not found (id: {drawId})");

			draw.Draw(_users);
		}
	}
}
