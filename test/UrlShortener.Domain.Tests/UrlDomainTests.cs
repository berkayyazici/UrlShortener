using System;
using UrlShortener.Domain.Url;
using Xunit;

public class UrlDomainTests
{
    [Fact]
    public void IsValidUrl_StartsWithHttps_ShouldReturnTrue_WhenUrlIsValid()
    {
        var url = new Url
        {
            LongUrl = "https://demoUrl1.com"
        };

        var result = url.IsValidUrl();

        Assert.True(result);
    }

    [Fact]
    public void IsValidUrl_StartsWithHttp_ShouldReturnTrue_WhenUrlIsValid()
    {
        var url = new Url
        {
            LongUrl = "http://demoUrl1.com"
        };

        var result = url.IsValidUrl();

        Assert.True(result);
    }

    [Fact]
    public void IsValidUrl_DoesNotStartWithHttpOrHttps_ShouldReturnFalse_WhenUrlIsNotValid()
    {
        var url = new Url
        {
            LongUrl = "demoUrl://demoUrl1.com"
        };

        var result = url.IsValidUrl();

        Assert.False(result);
    }
}
