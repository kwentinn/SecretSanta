using System;

namespace SecretSanta.Domain.Exceptions
{
	public class DrawNotFoundException : ApplicationException
	{
		private readonly Guid _drawId;
		public override string Message => $"Tirage introuvable {_drawId.ToString()}";
		public DrawNotFoundException(Guid drawId) : base() {
			_drawId = drawId;
		}
	}
}
