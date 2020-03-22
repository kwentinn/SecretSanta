using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SecretSanta.DomainTest")]
namespace SecretSanta.Domain
{
	[DebuggerDisplay("{Firstname} {Lastname} {Email}")]
	internal class User
	{
		public string Firstname { get; private set; }
		public string Lastname { get; private set; }
		public string Email { get; private set; }

		internal User(string firstname, string lastname, string email)
		{
			Firstname = firstname;
			Lastname = lastname;
			Email = email;
		}
	}
}
