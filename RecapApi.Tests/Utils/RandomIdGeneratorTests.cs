using RecapApi.Utils;

namespace RecapApi.Tests.Utils;

public class RandomIdGeneratorTests
{
    [Test]
    public void GenerateIdWithGivenPrefix()
    {
        // Arrange & Act
        var id = RandomIdGenerator.Generate("todo");

        // Assert
        Assert.That(id, Has.Length.EqualTo(19));
    }
}