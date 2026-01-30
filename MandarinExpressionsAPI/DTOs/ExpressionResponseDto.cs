

namespace MandarinExpressionsAPI.DTOs;

public record ExpressionResponseDto(
    Guid Id,
    string Hanzi,
    string Pinyin,
    string MeaningPt,
    string MeaningEn,
    string UsageContext,
    string ExampleSentence,
    string Level);