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
        Assert.That(properties.GetProperty("key1"), Is.Null);

        properties.SetProperty("key1", "value1");
        propertiesList = properties.GetProperties();
        Assert.That(propertiesList, Has.Count.EqualTo(1));
        Assert.That(properties.GetProperty("key1"), Is.Not.Null);

        properties.SaveProperties();
        properties = new Properties(".", "test.properties");
        propertiesList = properties.GetProperties();
        Assert.That(propertiesList, Has.Count.EqualTo(1));
        Assert.That(propertiesList["key1"], Is.EqualTo("value1"));
    }

    [Test]
    public void Ctor2Test()
    {
        var properties = new Properties("test.properties");
    }
}
