using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SecretSanta.Domain;
using SecretSanta.Domain.Exceptions;
using SecretSanta.Domain.Services;
using System;
using System.Collections.Generic;

namespace SecretSanta.DomainTest
{
	[TestClass]
	public class SecretSantaDrawTest
	{
		[TestMethod]
		public void Draw_PassNull()
		{
			Assert.ThrowsException<ArgumentException>(() => new SecretSantaDraw(Guid.Empty, ""));
		}

		[TestMethod]
		public void Draw_Pass3Users_ShouldThrowIncorrectNumberOfUsersException()
		{
			var mock = new Mock<IListRandomizer>();

			// arrange
			var ssd = new SecretSantaDraw(Guid.NewGuid(), "test");
			var users = new List<User>
			{
				new User("josé", "galliani", "jose@gmail.com"),
				new User("michel", "galliani", "michel@gmail.com"),
				new User("patrick", "galliani", "patrick@gmail.com"),
			}.AsReadOnly();

			// 1. jose -> michel
			// 2. michel -> patrick
			// 3. patrick -> jose

			// act
			ssd.Draw(users, false, mock.Object);

			// assert
			Assert.IsNotNull(ssd.SecretSantaDrawLines);
			Assert.AreEqual(3, ssd.SecretSantaDrawLines.Count);

			Assert.AreEqual("josé", ssd.SecretSantaDrawLines[0].From.Firstname);
			Assert.AreEqual("michel", ssd.SecretSantaDrawLines[0].To.Firstname);

			Assert.AreEqual("michel", ssd.SecretSantaDrawLines[1].From.Firstname);
			Assert.AreEqual("patrick", ssd.SecretSantaDrawLines[1].To.Firstname);

			Assert.AreEqual("patrick", ssd.SecretSantaDrawLines[2].From.Firstname);
			Assert.AreEqual("josé", ssd.SecretSantaDrawLines[2].To.Firstname);
		}

		[TestMethod]
		public void Draw_PassSixUsers_ShouldDrawAndStore6DrawLines()
		{
			var mock = new Mock<IListRandomizer>();
			var ssd = new SecretSantaDraw(Guid.NewGuid(), "test");
			var users = new List<User>
			{
				new User("josé", "galliani", "jose@gmail.com"),
				new User("michel", "galliani", "michel@gmail.com"),
				new User("patrick", "galliani", "patrick@gmail.com"),
				new User("nicolas", "galliani", "nico@gmail.com"),
				new User("juju", "galliani", "juju@gmail.com"),
				new User("fab", "galliani", "fab@gmail.com"),
			};

			ssd.Draw(users.AsReadOnly(), false, mock.Object);

			// assert
			Assert.IsNotNull(ssd.SecretSantaDrawLines);
			Assert.AreEqual(6, ssd.SecretSantaDrawLines.Count);

			Assert.AreEqual("josé", ssd.SecretSantaDrawLines[0].From.Firstname);
			Assert.AreEqual("michel", ssd.SecretSantaDrawLines[0].To.Firstname);

			Assert.AreEqual("michel", ssd.SecretSantaDrawLines[1].From.Firstname);
			Assert.AreEqual("patrick", ssd.SecretSantaDrawLines[1].To.Firstname);

			Assert.AreEqual("patrick", ssd.SecretSantaDrawLines[2].From.Firstname);
			Assert.AreEqual("nicolas", ssd.SecretSantaDrawLines[2].To.Firstname);

			Assert.AreEqual("nicolas", ssd.SecretSantaDrawLines[3].From.Firstname);
			Assert.AreEqual("juju", ssd.SecretSantaDrawLines[3].To.Firstname);

			Assert.AreEqual("juju", ssd.SecretSantaDrawLines[4].From.Firstname);
			Assert.AreEqual("fab", ssd.SecretSantaDrawLines[4].To.Firstname);

			Assert.AreEqual("fab", ssd.SecretSantaDrawLines[5].From.Firstname);
			Assert.AreEqual("josé", ssd.SecretSantaDrawLines[5].To.Firstname);
		}

		[TestMethod]
		public void Draw_PassSixUsersWithShuffle_ShouldShuffleListAndDrawSixLines()
		{
			var randomizer = new ListRandomizer(new ThreadSafeRandom());
			var ssd = new SecretSantaDraw(Guid.NewGuid(), "test");
			var users = new List<User>
			{
				new User("josé", "galliani", "jose@gmail.com"),
				new User("michel", "galliani", "michel@gmail.com"),
				new User("patrick", "galliani", "patrick@gmail.com"),
				new User("nicolas", "galliani", "nico@gmail.com"),
				new User("juju", "galliani", "juju@gmail.com"),
				new User("fab", "galliani", "fab@gmail.com"),
			};

			ssd.Draw(users.AsReadOnly(), true, randomizer);

			// assert
			Assert.IsNotNull(ssd.SecretSantaDrawLines);
			Assert.AreEqual(6, ssd.SecretSantaDrawLines.Count);


		}
	}
}
