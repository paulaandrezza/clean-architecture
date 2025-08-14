namespace Infrastructure.UnitTests.Migrations
{
    internal class SeedUsersMigrationTest
    {
        //[Test]
        //public async Task ShouldExecute()
        //{
        //    // Arrange
        //    var serviceScopeFactory = new Mock<IServiceScopeFactory>();
        //    var serviceScope = new Mock<IServiceScope>();
        //    var serviceProvider = new Mock<IServiceProvider>();
        //    var mediator = new Mock<IMediator>();

        //    serviceScopeFactory.Setup(service => service.CreateScope()).Returns(serviceScope.Object);
        //    serviceScope.Setup(scope => scope.ServiceProvider).Returns(serviceProvider.Object);
        //    serviceProvider.Setup(provider => provider.GetService(typeof(IMediator))).Returns(mediator.Object);

        //    var consumer = new SeedUsersMigration(serviceScopeFactory.Object);

        //    // Act
        //    await consumer.Execute(CancellationToken.None);

        //    // Assert
        //    mediator.Verify(
        //        m => m.Send(It.IsAny<CreateProfessorUserCommand>(), CancellationToken.None),
        //        Times.Exactly(2));
        //}
    }
}
