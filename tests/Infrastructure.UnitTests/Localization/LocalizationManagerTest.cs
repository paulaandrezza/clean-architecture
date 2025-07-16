using FluentAssertions;
using Infrastructure.Services;
using System.Globalization;

namespace Infrastructure.UnitTests.Localization
{
    public class LocalizationManagerTest
    {
        [Test]
        [TestCase("save", "pt-BR", "Salvar")]
        [TestCase("save", "es-MX", "Guardar")]
        [TestCase("save", "en-US", "Save")]
        [TestCase("invalid.key", "pt-BR", "invalid.key")]
        public void GetString_Terms(string key, string culture, string expected)
        {
            // Arrange
            var manager = new LocalizationService();

            // Act
            var result = manager.GetString(key, new CultureInfo(culture));

            // Assert
            result.Should().Be(expected);
        }
    }
}
