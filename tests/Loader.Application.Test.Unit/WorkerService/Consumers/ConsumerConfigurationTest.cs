using Loader.WorkerService.Consumers;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Loader.Test.Unit.WorkerService.Consumers;

public class ConsumerConfigurationTest
{
    [Fact(DisplayName = "Deve retornar a configuração quando ela existir")]
    [Trait("ConsumerConfiguration", "Properties")]
    public void ShouldReturnConfigurationValueWhenItExists()
    {
        var consumerConfiguration = MakeSut();

        var url = consumerConfiguration.URL;
        var header = consumerConfiguration.Header;
        var token = consumerConfiguration.Token;

        Assert.Equal("http://localhost:8080", url);
        Assert.Equal("header-test", header);
        Assert.Equal("123456", token);
    }

    [Fact(DisplayName = "Deve retornar a configuração quando ela existir")]
    [Trait("ConsumerConfiguration", "Properties")]
    public void ShouldNotReturnConfigurationValueWhenItDoesntExists()
    {
        var consumerConfiguration = MakeWithoutConfigurationSut();

        var url = consumerConfiguration.URL;
        var header = consumerConfiguration.Header;
        var token = consumerConfiguration.Token;

        Assert.True(string.IsNullOrWhiteSpace(url));
        Assert.True(string.IsNullOrWhiteSpace(header));
        Assert.True(string.IsNullOrWhiteSpace(token));
    }

    private ConsumerConfiguration MakeSut()
    {
        var configurationMock = new Mock<IConfiguration>();

        Mock<IConfigurationSection> baseUrlSectionMock = new();
        baseUrlSectionMock
            .Setup(s => s.Value)
            .Returns("http://localhost:8080");

        Mock<IConfigurationSection> headerSectionMock = new();
        headerSectionMock
            .Setup(s => s.Value)
            .Returns("header-test");

        Mock<IConfigurationSection> tokenSectionMock = new();
        tokenSectionMock
            .Setup(s => s.Value)
            .Returns("123456");

        configurationMock
                .Setup(s => s.GetSection("DataSource:BaseURL"))
                .Returns(baseUrlSectionMock.Object);

        configurationMock
                .Setup(s => s.GetSection("DataSource:Header"))
                .Returns(headerSectionMock.Object);

        configurationMock
                .Setup(s => s.GetSection("DataSource:Token"))
                .Returns(tokenSectionMock.Object);

        return new ConsumerConfiguration(configurationMock.Object);
    }

    private ConsumerConfiguration MakeWithoutConfigurationSut()
    {
        var configurationMock = new Mock<IConfiguration>();

        //Mock<IConfigurationSection> baseUrlSectionMock = new();
        //baseUrlSectionMock
        //    .Setup(s => s.Value)
        //    .Returns("");

        //Mock<IConfigurationSection> headerSectionMock = new();
        //headerSectionMock
        //    .Setup(s => s.Value)
        //    .Returns("");

        //Mock<IConfigurationSection> tokenSectionMock = new();
        //tokenSectionMock
        //    .Setup(s => s.Value)
        //    .Returns("");

        //configurationMock
        //        .Setup(s => s.GetSection("DataSource:BaseURL"))
        //        .Returns(baseUrlSectionMock.Object);

        //configurationMock
        //        .Setup(s => s.GetSection("DataSource:Header"))
        //        .Returns(headerSectionMock.Object);

        //configurationMock
        //        .Setup(s => s.GetSection("DataSource:Token"))
        //        .Returns(tokenSectionMock.Object);

        return new ConsumerConfiguration(configurationMock.Object);
    }
}
