using YSCommon;

namespace common_test;

public class PropertiesTest
{
    [SetUp]
    public void Setup()
    {
        try
        {
            File.Delete(@"./test.properties");
        }
        catch (Exception)
        {
        }
    }

    [Test]
    public void CtorTest()
    {
        var properties = new Properties(".", "test.properties");
        var propertiesList = properties.GetProperties();
        Assert.That(propertiesList, Has.Count.EqualTo(0));

        properties.SetProperty("key1", "value1");
        propertiesList = properties.GetProperties();
        Assert.That(propertiesList, Has.Count.EqualTo(1));

        properties.SaveProperties();
        properties = new Properties(".", "test.properties");
        propertiesList = properties.GetProperties();
        Assert.That(propertiesList, Has.Count.EqualTo(1));
        Assert.That(propertiesList["key1"], Is.EqualTo("value1"));
    }
}
