using System.Collections.ObjectModel;
using WpfLabApp.Common;
using WpfLabApp.Models;
using WpfLabApp.Services.Implementations;

namespace WpfLabApp.ViewModels;

/// <summary>
/// Модель представления вкладки «1.2. Цветовая палитра» (ТЗ 1.2).
/// Предоставляет коллекции базовых цветов и 50 математически выверенных оттенков.
/// </summary>
public class ColorPaletteViewModel : ObservableObject
{
    private ColorItem? _selectedShade;
    private string _notificationBanner = "Нажмите на любой образец оттенка для просмотра детальных характеристик или копирования кода";

    public ColorGroup PrimaryGroup { get; } = ColorPaletteData.GetPrimaryGroup();
    public ColorGroup AccentGroup { get; } = ColorPaletteData.GetAccentGroup();
    public ColorGroup SuccessGroup { get; } = ColorPaletteData.GetSuccessGroup();
    public ColorGroup ErrorGroup { get; } = ColorPaletteData.GetErrorGroup();
    public ColorGroup InfoGroup { get; } = ColorPaletteData.GetInfoGroup();

    public ObservableCollection<ColorGroup> AllGroups { get; }

    public ColorItem? SelectedShade
    {
        get => _selectedShade;
        set => SetProperty(ref _selectedShade, value);
    }

    public string NotificationBanner
    {
        get => _notificationBanner;
        set => SetProperty(ref _notificationBanner, value);
    }

    public RelayCommand<string> CopyHexCommand { get; }
    public RelayCommand<string> CopyRgbCommand { get; }
    public RelayCommand<ColorItem> SelectShadeCommand { get; }

    public ColorPaletteViewModel()
    {
        AllGroups = new ObservableCollection<ColorGroup>
        {
            PrimaryGroup,
            AccentGroup,
            SuccessGroup,
            ErrorGroup,
            InfoGroup
        };

        SelectedShade = PrimaryGroup.Shades.Count > 5 ? PrimaryGroup.Shades[5] : PrimaryGroup.Shades[0];

        CopyHexCommand = new RelayCommand<string>(hex =>
        {
            if (string.IsNullOrEmpty(hex)) return;
            NotificationService.Instance.CopyToClipboard(hex, "HEX-код");
            NotificationBanner = $"Скопирован HEX-код: {hex}";
        });

        CopyRgbCommand = new RelayCommand<string>(rgb =>
        {
            if (string.IsNullOrEmpty(rgb)) return;
            NotificationService.Instance.CopyToClipboard(rgb, "RGB-код");
            NotificationBanner = $"Скопирован RGB-код: {rgb}";
        });

        SelectShadeCommand = new RelayCommand<ColorItem>(shade =>
        {
            if (shade != null)
            {
                SelectedShade = shade;
            }
        });
    }
}
