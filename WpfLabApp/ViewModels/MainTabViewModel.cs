using System.Collections.ObjectModel;
using WpfLabApp.Common;
using WpfLabApp.Models.Personalization;

namespace WpfLabApp.ViewModels;

/// <summary>
/// Модель представления вкладки «1.1. Основное» (ТЗ 1.1).
/// Управляет списками персонализации (темы, языки, шрифты, кегль) и логикой Live Preview.
/// </summary>
public class MainTabViewModel : ObservableObject
{
    private ThemeOption? _selectedTheme;
    private LanguageOption? _selectedLanguage;
    private FontOption? _selectedFont;
    private double _fontSize = 14;
    private bool _isBold;
    private bool _isItalic;
    private string _customPreviewText = "Съешь же ещё этих мягких французских булок, да выпей чаю. 1234567890!@#$%^&*()";

    public ObservableCollection<ThemeOption> AvailableThemes { get; } = new();
    public ObservableCollection<LanguageOption> AvailableLanguages { get; } = new();
    public ObservableCollection<FontOption> AvailableFonts { get; } = new();

    public ThemeOption? SelectedTheme
    {
        get => _selectedTheme;
        set => SetProperty(ref _selectedTheme, value);
    }

    public LanguageOption? SelectedLanguage
    {
        get => _selectedLanguage;
        set => SetProperty(ref _selectedLanguage, value);
    }

    public FontOption? SelectedFont
    {
        get => _selectedFont;
        set => SetProperty(ref _selectedFont, value);
    }

    public double FontSize
    {
        get => _fontSize;
        set => SetProperty(ref _fontSize, value);
    }

    public bool IsBold
    {
        get => _isBold;
        set => SetProperty(ref _isBold, value);
    }

    public bool IsItalic
    {
        get => _isItalic;
        set => SetProperty(ref _isItalic, value);
    }

    public string CustomPreviewText
    {
        get => _customPreviewText;
        set => SetProperty(ref _customPreviewText, value);
    }

    public RelayCommand<double> SetPresetSizeCommand { get; }

    public MainTabViewModel()
    {
        SetPresetSizeCommand = new RelayCommand<double>(size => FontSize = size);

        // Инициализация тем
        AvailableThemes.Add(new ThemeOption("Тёмная (Dark Slate)", "Современная глубокая тёмная палитра Slate", "#3B82F6", "DarkSlate"));
        AvailableThemes.Add(new ThemeOption("Светлая (Modern Light)", "Чистая светлая корпоративная тема", "#2563EB", "Light"));
        AvailableThemes.Add(new ThemeOption("Киберпанк (Neon)", "Высококонтрастная неоновая палитра", "#8B5CF6", "Cyberpunk"));
        AvailableThemes.Add(new ThemeOption("Системная", "Автоматическое следование настройкам Windows", "#64748B", "System"));
        SelectedTheme = AvailableThemes[0];

        // Инициализация языков
        AvailableLanguages.Add(new LanguageOption("Русский (ru-RU)", "Русский", "ru-RU", "🇷🇺"));
        AvailableLanguages.Add(new LanguageOption("English (en-US)", "English", "en-US", "🇺🇸"));
        AvailableLanguages.Add(new LanguageOption("Deutsch (de-DE)", "Deutsch", "de-DE", "🇩🇪"));
        AvailableLanguages.Add(new LanguageOption("Español (es-ES)", "Español", "es-ES", "🇪🇸"));
        AvailableLanguages.Add(new LanguageOption("Français (fr-FR)", "Français", "fr-FR", "🇫🇷"));
        SelectedLanguage = AvailableLanguages[0];

        // Инициализация шрифтов
        AvailableFonts.Add(new FontOption("Segoe UI", "Sans-Serif", "Segoe UI — стандартный системный интерфейсный шрифт Windows"));
        AvailableFonts.Add(new FontOption("Arial", "Sans-Serif", "Arial — классический гротеск без засечек"));
        AvailableFonts.Add(new FontOption("Calibri", "Sans-Serif", "Calibri — современный скругленный гротеск"));
        AvailableFonts.Add(new FontOption("Consolas", "Monospace", "Consolas — моноширинный шрифт разработчиков"));
        AvailableFonts.Add(new FontOption("Times New Roman", "Serif", "Times New Roman — традиционная антиква с засечками"));
        AvailableFonts.Add(new FontOption("Trebuchet MS", "Sans-Serif", "Trebuchet MS — гуманистический гротеск"));
        AvailableFonts.Add(new FontOption("Verdana", "Sans-Serif", "Verdana — оптимизированный для экранов шрифт"));
        SelectedFont = AvailableFonts[0];
    }
}
