namespace MandarinExpressionsAPI.Domain;

public class Expression
{
    public Guid Id { get; private set; }

    public string Hanzi { get; set; } = null!;
    public string Pinyin { get; set; } = null!;
    public string MeaningPt { get; set; } = null!;
    public string MeaningEn { get; set; } = null!;
    public string UsageContext { get; set; } = null!;
    public string ExampleSentence { get; set; } = null!;
    public Level Level { get; set; }
}