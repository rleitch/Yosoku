using Yosoku.Core.Services;

namespace Yosoku.Core.Tests;

[TestClass]
public class FundamentalAnalysisServiceTests
{
    [TestMethod]
    public void CalculatePERatio_ValidInputs_ReturnsCorrectValue()
    {
        // Arrange: Price 150, Net Income 3000, Shares 1000 -> EPS 3, PE 50
        float price = 150f;
        float netIncome = 3000f;
        float shares = 1000f;
        float expected = 50f;

        // Act
        float result = FundamentalAnalysisService.CalculatePERatio(price, netIncome, shares);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void CalculatePERatio_ZeroNetIncome_ReturnsPositiveInfinity()
    {
        // Arrange
        float price = 100f;
        float netIncome = 0f;
        float shares = 1000f;

        // Act
        float result = FundamentalAnalysisService.CalculatePERatio(price, netIncome, shares);

        // Assert
        Assert.AreEqual(float.PositiveInfinity, result);
    }

    [TestMethod]
    public void CalculatePERatio_ZeroShares_ThrowsArgumentException()
    {
        // Arrange
        float price = 100f;
        float netIncome = 1000f;
        float shares = 0f;

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            FundamentalAnalysisService.CalculatePERatio(price, netIncome, shares));
    }

    [TestMethod]
    public void CalculatePERatio_NegativeNetIncome_ReturnsNegativeValue()
    {
        // Arrange: Price 150, Net Income -3000 (Loss), Shares 1000 -> EPS -3, PE -50
        float price = 150f;
        float netIncome = -3000f;
        float shares = 1000f;
        float expected = -50f;

        // Act
        float result = FundamentalAnalysisService.CalculatePERatio(price, netIncome, shares);

        // Assert
        Assert.AreEqual(expected, result);
    }
}