namespace Application.UnitTests.UseCases.Users
{
    public class CreateUserTest
    {
        //[Test]
        //public async Task CreateUser_ShouldSave()
        //{
        //    // Arrange
        //    var command = new CreateProfessorUserCommand() { Name = "User Name", Email = "user@email.com", UserProfileType = UserProfileType.Admin };
        //    var repository = new Mock<IUserRepository>();
        //    var validator = new Mock<IValidator<CreateProfessorUserCommand>>();
        //    validator.Setup(v => v.ValidateAndThrow(It.IsAny<CreateProfessorUserCommand>()));
        //    var passwordHasher = new Mock<IPasswordHasher>();
        //    passwordHasher.Setup(ph => ph.HashPassword(It.IsAny<string>())).Returns("hashed_password");
        //    var handler = new CreateProfessorUserrHandler(repository.Object, validator.Object, passwordHasher.Object);

        //    // Act
        //    await handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    repository.Verify(v => v.AddAsync(It.Is<User>(d =>
        //        d.Name.Equals("User Name") &&
        //        d.Email.Equals("user@email.com") &&
        //        d.UserProfileType.Equals(UserProfileType.Admin)
        //    ), CancellationToken.None), Times.Once);
        //}
    }
}
