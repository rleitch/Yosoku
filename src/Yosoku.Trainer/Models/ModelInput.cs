namespace Yosoku.Trainer.Models;

public class ModelInput
{
    // Features (The "X")
    public float Sma50 { get; set; }
    public float Sma200 { get; set; }
    public float PeRatio { get; set; }

    // You might want to add "Momentum" features here as well:
    // e.g., (CurrentPrice - Price3MonthsAgo) / Price3MonthsAgo

    // Label (The "y" - What you want to predict)
    public float Label { get; set; }
}
