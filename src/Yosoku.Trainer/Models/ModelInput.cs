namespace Yosoku.Trainer.Models;

public class ModelInput
{
    // Features (The "X")
    public double Sma50 { get; set; }
    public double Sma200 { get; set; }
    public double PeRatio { get; set; }

    // You might want to add "Momentum" features here as well:
    // e.g., (CurrentPrice - Price3MonthsAgo) / Price3MonthsAgo

    // Label (The "y" - What you want to predict)
    public double Label { get; set; }
}
