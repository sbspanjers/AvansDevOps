using AvansDevOps.Domain.Interfaces;
using AvansDevOps.Domain.Rules.NotifyRule;
using AvansDevOps.Domain.Users;

namespace DevOpsTests.Domain.Rules;

public class NotifyRuleTest
{
    [Fact]
    public void ScrumMasterRuleFilter()
    {
        // Arrange
        INotifyRule rule = new ScrummasterRule();
        User po = new ProductOwner();
        User dev = new Developer();
        User sm = new Scrummaster();

        List<User> users = new() { po, dev, sm};

        // Act
        var result = rule.Filter(users);

        // Assert
        Assert.Equal(Assert.Single(result), sm);
    }

    [Fact]
    public void ScrumMasterRuleFilterNoScrumMaster()
    {
        // Arrange
        INotifyRule rule = new ScrummasterRule();
        User po = new ProductOwner();
        User dev = new Developer();
        User test = new Tester();


        List<User> users = new() { po, dev };

        // Act
        var result = rule.Filter(users);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void TesterRuleFilter()
    {
        // Arrange
        INotifyRule rule = new TesterRule();
        User po = new ProductOwner();
        User dev = new Developer();
        User sm = new Scrummaster();
        User test = new Tester();

        List<User> users = new() { po, dev, sm, test };

        // Act
        var result = rule.Filter(users);

        // Assert
        Assert.Equal(Assert.Single(result), test);
    }

    [Fact]
    public void TesterRuleFilterNoTester()
    {
        // Arrange
        INotifyRule rule = new TesterRule();
        User po = new ProductOwner();
        User dev = new Developer();
        User sm = new Scrummaster();

        List<User> users = new() { po, dev, sm };

        // Act
        var result = rule.Filter(users);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GeneralRuleFilter()
    {
        // Arrange
        INotifyRule rule = new GeneralRule();
        User po = new ProductOwner();
        User dev = new Developer();
        User sm = new Scrummaster();
        User test = new Tester();

        List<User> users = new() { po, dev, sm, test };

        // Act
        var result = rule.Filter(users);

        // Assert
        Assert.Equal(result, users);
    }

    [Fact]
    public void GeneralRuleFilterNoUsers()
    {
        // Arrange
        INotifyRule rule = new GeneralRule();

        List<User> users = new();

        // Act
        var result = rule.Filter(users);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void POScrumerRuleFilter()
    {
        // Arrange
        INotifyRule rule = new POScrummasterRule();
        User po = new ProductOwner();
        User dev = new Developer();
        User sm = new Scrummaster();
        User test = new Tester();

        List<User> users = new() { po, dev, sm, test };

        // Act
        var result = rule.Filter(users);

        // Assert contains sm and po
        Assert.Contains(sm, result);
        Assert.Contains(po, result);
        Assert.DoesNotContain(dev, result);
        Assert.DoesNotContain(test, result);
    }
}
