using NUnit.Framework;
using BowlingApi;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;

namespace BowlingIntegrationTest
{
  public class Tests
  {
    IWebHostBuilder webHostBuilder;
    TestServer server;
    HttpClient client;

    [SetUp]
    public void Setup()
    {
        webHostBuilder =
            new WebHostBuilder()
            .UseEnvironment("Development") 
            .UseStartup<Startup>();
        server = new TestServer(webHostBuilder);
        client = server.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        client.Dispose();
        server.Dispose();
    }


    [Test]
    public void Get_empty_state_on_new_game()
    {
      // Arrange

      // Act
      var result = client.GetAsync("api/rendered-state").Result;
      var body = result.Content.ReadAsStringAsync().Result;

      // Assert
      Assert.True(result.IsSuccessStatusCode);
      Assert.AreEqual(@"|-------|-------|-------|-------|-------|-------|-------|-------|-------|-----------|
|     1 |     2 |     3 |     4 |     5 |     6 |     7 |     8 |     9 |        10 |
|-------|-------|-------|-------|-------|-------|-------|-------|-------|-----------|
| 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
|-------|-------|-------|-------|-------|-------|-------|-------|-------|-----------|
|     0 |     0 |     0 |     0 |     0 |     0 |     0 |     0 |     0 |         0 |
|-------|-------|-------|-------|-------|-------|-------|-------|-------|-----------|

Current frame: 1
Current throw: 1", body);
    }
  }
}