using FluentAssertions;
using System.Security.Cryptography;
using System.Text;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Tests.Build;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class UserAggregateTests
	{
		[Fact]
		public void UserAggregate_CreateTest()
		{
			//Arrange
			var pass = new SHA1CryptoServiceProvider();			 
		    var request = Builder.CreateTestUserCreate();
			var password = pass.ComputeHash(Encoding.Unicode.GetBytes(request.Password));

			//Act
			var user = UserAgg.CreateRequest(request);

			// Assert
			user.Username.Should().Be(request.Username);
			user.RefreshToken.Should().Be(string.Empty);
			user.IsDeleted.Should().BeFalse();

			Builder.PasswordTrue(user.PasswordHash, password).Should().BeTrue();
		}

		[Fact]
		public void UserAggregate_UpdateTest()
		{
			//Arrange
			var pass = new SHA1CryptoServiceProvider();
			var request = Builder.CreateTestUserCreate();
			var user = UserAgg.CreateRequest(request);
			var updateRequest = Builder.CreateTestUserUpdate();
			var passwor = pass.ComputeHash(Encoding.Unicode.GetBytes(request.Password));

			//Act
			user.UpdateRequest(updateRequest);

			// Assert
			user.Username.Should().Be(updateRequest.Username);
			user.RefreshToken.Should().Be(string.Empty);
			user.IsDeleted.Should().BeFalse();

			Builder.PasswordTrue(user.PasswordHash, passwor).Should().BeTrue();
		}


		[Fact]
		public void UserAggregate_DeletedTest()
		{
			//Arrange
			var request = Builder.CreateTestUserCreate();
			var user = UserAgg.CreateRequest(request);

			//Act
			user.FlagDeleted();

			//Assert
			user.IsDeleted.Should().BeTrue();
		}

		[Fact]
		public void UserAggregate_RefreshTokenUpdatedTest()
		{
			//Arrange
			var request = Builder.CreateTestUserCreate();
			var user = UserAgg.CreateRequest(request);
			var newRefreshToken = "New Refresh Token";

			//Act
			user.UpdateRefreshToken(newRefreshToken);

			//Assert
			user.RefreshToken.Should().Be(newRefreshToken);
		}
	}
}

