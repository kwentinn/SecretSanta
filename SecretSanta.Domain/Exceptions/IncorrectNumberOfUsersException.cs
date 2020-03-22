using System;

namespace SecretSanta.Domain.Exceptions
{
	public class IncorrectNumberOfUsersException : ApplicationException
	{
		// TODO : utiliser un fichier de ressources
		public override string Message => "Un nombre impair d'utilisateurs est nécessaire!";

		public IncorrectNumberOfUsersException() : base()
		{
		}
	}
}