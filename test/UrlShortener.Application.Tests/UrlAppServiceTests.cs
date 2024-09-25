using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using UrlShortener.Application.Urls;
using UrlShortener.Data.EntityFrameworkCore;
using UrlShortener.Domain.Url;
using Xunit;

public class UrlAppServiceTests
{
    private readonly Mock<IUrlRepository> _mockUrlRepository;
    private readonly Mock<UrlManager> _mockUrlManager;

    private readonly UrlAppService _urlAppService;
    private readonly UrlManager _urlManager;

    private readonly EfContext _context;

    public UrlAppServiceTests()
    {
        var options = new DbContextOptionsBuilder<EfContext>()
            .UseSqlServer("Server=MSI,1433;Initial Catalog=LocalDb;User ID=testUser;Password=testUser;TrustServerCertificate=True")
            .Options;

        _context = new EfContext(options);

        _mockUrlRepository = new Mock<IUrlRepository>();
        _mockUrlManager = new Mock<UrlManager>(_mockUrlRepository.Object);

        _urlAppService = new UrlAppService(_mockUrlRepository.Object, _mockUrlManager.Object);
    }

    [Fact]
    public void GetUrlById_ShouldReturnUrl_WhenUrlExists()
    {
        // Arrange
        Guid urlId = new Guid("08298D19-8F46-4BBC-A536-96EE8C519BDE");

        var expectedUrl = new Url { ID = urlId };

        var result = _context.Urls.FirstOrDefault(p => p.ID == urlId);

        _mockUrlRepository.Setup(x => x.GetAsync(urlId)).ReturnsAsync(expectedUrl);

        // Assert
        Assert.Equal("https://github.com/berkayyazici/UrlShortener", result.LongUrl);
    }

    [Fact]
    public void GetUrlById_ShouldReturnNotFound_WhenUrlDoesNotExist()
    {
        Guid urlId = Guid.NewGuid();

        var result = _context.Urls.FirstOrDefault(p => p.ID == urlId);

        // Assert
        Assert.Equal("URL not found", result == null ? "URL not found" : result.LongUrl);
    }
}
