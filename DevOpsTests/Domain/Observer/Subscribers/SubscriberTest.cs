using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Observer.Subscribers;

namespace DevOpsTests.Domain.Observer.Subscribers;

public class SubscriberTest
{
    [Fact]
    public void WhatsappSubscriberTest()
    {
        // Arrange
        ISubscriber subscriber = new WhatsappSubscriber();
        string message = "Hello, World!";
        string userName = "John Doe";

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            string slack = "WhatsappSubscriber:";
            subscriber.Notify(message, userName);

            // Assert
            string expectedOutput = slack;

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void SlackSubscriberTest()
    {
        // Arrange
        ISubscriber subscriber = new SlackSubscriber();
        string message = "Hello, World!";
        string userName = "John Doe";

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            string slack = "SlackSubscriber:";
            subscriber.Notify(message, userName);

            // Assert
            string expectedOutput = slack;

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }

    [Fact]
    public void GMailSubscriberTest()
    {
        // Arrange
        ISubscriber subscriber = new GMailSubscriber();
        string message = "Hello, World!";
        string userName = "John Doe";

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            string slack = "GMailSubscriber:";
            subscriber.Notify(message, userName);

            // Assert
            string expectedOutput = slack;

            Assert.Contains(expectedOutput, sw.ToString());
        }
    }
}
