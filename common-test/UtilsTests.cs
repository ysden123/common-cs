using YSCommon;

namespace common_test;

public class UtilsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var folder = Utils.GetAssemblyFolderInLocalData();
        Assert.That(folder, Does.EndWith(@"\AppData\Local\common-test"));
    }
}
