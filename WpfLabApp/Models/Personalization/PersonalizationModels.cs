namespace WpfLabApp.Models.Personalization;

/// <summary>
/// Опция темы приложения для выпадающего списка персонализации (ТЗ 1.1.1.1).
/// </summary>
public record ThemeOption(
    string Name,
    string Description,
    string PreviewColorHex,
    string Code
);

/// <summary>
/// Опция языка приложения для выпадающего списка персонализации (ТЗ 1.1.1.2).
/// </summary>
public record LanguageOption(
    string DisplayName,
    string NativeName,
    string CultureCode,
    string FlagEmoji
);

/// <summary>
/// Опция шрифтовой гарнитуры (ТЗ 1.1.2.1).
/// </summary>
public record FontOption(
    string FontFamilyName,
    string Category,
    string SampleText
);
