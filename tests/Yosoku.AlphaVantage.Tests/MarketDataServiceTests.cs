//using AutoFixture;
//using Moq;
//using Yosoku.AlphaVantage.Models;
//using Yosoku.AlphaVantage.Services;

//namespace Yosoku.AlphaVantage.Tests;

//[TestClass]
//public class MarketDataServiceSmaTests : TestBase
//{
//    [TestMethod]
//    public async Task GetMarketDataAsync_ReturnsPopulatedMarketData()
//    {
//        // Arrange
//        var mockClient = new Mock<IAlphaVantageClient>();
//        var symbol = "AAPL";
//        var token = CancellationToken.None;

//        mockClient.Setup(x => x.TimeSeriesDailyAsync(symbol, token))
//            .ReturnsAsync(_fixture.Create<TimeSeriesResponse>());

//        mockClient.Setup(x => x.TimeSeriesMonthlyAsync(symbol, token))
//            .ReturnsAsync(_fixture.Create<TimeSeriesResponse>());

//        mockClient.Setup(x => x.GetIncomeStatements(symbol, token))
//            .ReturnsAsync(_fixture.Create<CompanyStatements<IncomeStatement>>());

//        mockClient.Setup(x => x.GetBalanceSheets(symbol, token))
//            .ReturnsAsync(_fixture.Create<CompanyStatements<BalanceSheet>>());

//        var service = new MarketDataService(mockClient.Object);

//        // Act
//        var result = await service.GetMarketDataAsync(symbol, token);

//        // Assert
//        Assert.IsNotNull(result);
//        Assert.AreEqual(symbol, result.Symbol);
//    }

//    [TestMethod]
//    public void CalculateMonthlySma_ConstantPrices_ReturnsExactAverage()
//    {
//        // Arrange
//        var dailyDict = new Dictionary<DateOnly, Quote>();
//        for (int i = 0; i < 60; i++)
//        {
//            var date = new DateOnly(2023, 1, 1).AddDays(i);
//            dailyDict[date] = new Quote { AdjustedClose = 100.0f };
//        }

//        var latestDate = dailyDict.Keys.Max();

//        var monthlyDict = new Dictionary<DateOnly, Quote>
//        {
//            { latestDate, new Quote() }
//        };

//        // Fix: Select the tuple (Date, Price) for the dailyList
//        var dailyList = dailyDict.OrderBy(x => x.Key)
//            .Select(x => (Date: x.Key, Price: x.Value.AdjustedClose))
//            .ToList();

//        var monthlyList = monthlyDict.OrderBy(x => x.Key).ToList();

//        // Act
//        var result = MarketDataService.CalculateMonthlySma(monthlyList, dailyList, 50);

//        // Assert
//        Assert.IsTrue(result.ContainsKey(latestDate));
//        Assert.AreEqual(100.0f, result[latestDate]);
//    }

//    [TestMethod]
//    public void CalculateMonthlySma_LinearGrowth_ReturnsCorrectMidpoint()
//    {
//        // Arrange
//        var dailyDict = new Dictionary<DateOnly, Quote>();
//        for (int i = 0; i < 50; i++)
//        {
//            var date = new DateOnly(2023, 1, 1).AddDays(i);
//            dailyDict[date] = new Quote { AdjustedClose = (float)(i + 1) };
//        }

//        var latestDate = dailyDict.Keys.Max();

//        var monthlyDict = new Dictionary<DateOnly, Quote>
//        {
//            { latestDate, new Quote() }
//        };

//        // Fix: Select the tuple (Date, Price) for the dailyList
//        var dailyList = dailyDict.OrderBy(x => x.Key)
//            .Select(x => (Date: x.Key, Price: x.Value.AdjustedClose))
//            .ToList();

//        var monthlyList = monthlyDict.OrderBy(x => x.Key).ToList();

//        // Act
//        var result = MarketDataService.CalculateMonthlySma(monthlyList, dailyList, 50);

//        // Assert
//        Assert.IsTrue(result.ContainsKey(latestDate));
//        Assert.AreEqual(25.5f, result[latestDate]);
//    }

//    [TestMethod]
//    public void CalculateMonthlySma_InsufficientDays_ReturnsEmpty()
//    {
//        // Arrange
//        var dailyDict = new Dictionary<DateOnly, Quote>();
//        for (int i = 0; i < 40; i++)
//        {
//            var date = new DateOnly(2023, 1, 1).AddDays(i);
//            dailyDict[date] = new Quote { AdjustedClose = 100.0f };
//        }

//        var latestDate = dailyDict.Keys.Max();

//        var monthlyDict = new Dictionary<DateOnly, Quote>
//        {
//            { latestDate, new Quote() }
//        };

//        // Fix: Select the tuple (Date, Price) for the dailyList
//        var dailyList = dailyDict.OrderBy(x => x.Key)
//            .Select(x => (Date: x.Key, Price: x.Value.AdjustedClose))
//            .ToList();

//        var monthlyList = monthlyDict.OrderBy(x => x.Key).ToList();

//        // Act
//        var result = MarketDataService.CalculateMonthlySma(monthlyList, dailyList, 50);

//        // Assert
//        Assert.IsEmpty(result);
//    }

//    [TestMethod]
//    public void CalculateMonthlySma_ExplicitSmallDataSet_ReturnsCorrectAverage()
//    {
//        // Arrange
//        var dailyDict = new Dictionary<DateOnly, Quote>
//        {
//            { new DateOnly(2023, 1, 1), new Quote { AdjustedClose = 10f } },
//            { new DateOnly(2023, 1, 2), new Quote { AdjustedClose = 20f } },
//            { new DateOnly(2023, 1, 3), new Quote { AdjustedClose = 30f } },
//            { new DateOnly(2023, 1, 4), new Quote { AdjustedClose = 40f } }
//        };

//        var targetDate = new DateOnly(2023, 1, 4);
//        var monthlyDict = new Dictionary<DateOnly, Quote>
//        {
//            { targetDate, new Quote() }
//        };

//        // Fix: Select the tuple (Date, Price) for the dailyList
//        var dailyList = dailyDict.OrderBy(x => x.Key)
//            .Select(x => (Date: x.Key, Price: x.Value.AdjustedClose))
//            .ToList();

//        var monthlyList = monthlyDict.OrderBy(x => x.Key).ToList();

//        // Act
//        var result = MarketDataService.CalculateMonthlySma(monthlyList, dailyList, 3);

//        // Assert
//        Assert.IsTrue(result.ContainsKey(targetDate));
//        Assert.AreEqual(30.0f, result[targetDate]);
//    }
//}