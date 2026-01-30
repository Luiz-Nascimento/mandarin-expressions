using System.ComponentModel.DataAnnotations;

namespace MandarinExpressionsAPI.DTOs;

public record ExpressionRequestDto(
    [Required(ErrorMessage = "Hanzi is required")]
    string Hanzi,
    [Required(ErrorMessage = "Pinyin is required")]
    [MinLength(1, ErrorMessage = "Pinyin cannot be empty")]
    string Pinyin,
    [Required(ErrorMessage = "Meaning in portuguese is required")]
    string MeaningPt,
    [Required(ErrorMessage = "Meaning in english is required")]
    string MeaningEn,
    [Required(ErrorMessage = "Usage context is required")]
    string UsageContext,
    [Required(ErrorMessage = "Example sentence is required")]
    string ExampleSentence,
    [Required(ErrorMessage = "Level is required")]
    string Level);