using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WpfLabApp.Models;

namespace WpfLabApp.Views
{
    /// <summary>
    /// Логика взаимодействия для ColorPaletteTabView.xaml
    /// Реализует подраздел 1.2: Цветовая палитра приложения
    /// </summary>
    public partial class ColorPaletteTabView : UserControl, INotifyPropertyChanged
    {
        private ColorItem? _selectedColor;
        private string _statusNotification = "Нажмите на любой оттенок в таблице или карточке для инспекции и копирования";
        private bool _isNotificationActive;
        private DispatcherTimer? _notificationTimer;

        public string CurrentThemeName => ColorPaletteData.CurrentThemeName;
        public string ThemeDescription => ColorPaletteData.ThemeDescription;

        public ColorGroup PrimaryGroup { get; } = ColorPaletteData.GetPrimaryGroup();
        public ColorGroup AccentGroup { get; } = ColorPaletteData.GetAccentGroup();
        public ColorGroup SuccessGroup { get; } = ColorPaletteData.GetSuccessGroup();
        public ColorGroup ErrorGroup { get; } = ColorPaletteData.GetErrorGroup();
        public ColorGroup InfoGroup { get; } = ColorPaletteData.GetInfoGroup();

        public List<ColorGroup> AllGroups { get; }

        public ColorItem? SelectedColor
        {
            get => _selectedColor;
            set
            {
                if (_selectedColor != value)
                {
                    _selectedColor = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(HasSelectedColor));
                }
            }
        }

        public bool HasSelectedColor => _selectedColor != null;

        public string StatusNotification
        {
            get => _statusNotification;
            set
            {
                _statusNotification = value;
                OnPropertyChanged();
            }
        }

        public bool IsNotificationActive
        {
            get => _isNotificationActive;
            set
            {
                _isNotificationActive = value;
                OnPropertyChanged();
            }
        }

        public ColorPaletteTabView()
        {
            AllGroups = new List<ColorGroup>
            {
                PrimaryGroup,
                AccentGroup,
                SuccessGroup,
                ErrorGroup,
                InfoGroup
            };

            InitializeComponent();
            DataContext = this;

            // Выбираем по умолчанию базовый цвет Primary 500
            SelectedColor = PrimaryGroup.Shades.Find(s => s.Shade == "500") ?? PrimaryGroup.Shades[0];
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid grid && grid.SelectedItem is ColorItem item)
            {
                SelectedColor = item;
                ShowNotification($"Выбран оттенок: {item.Name} ({item.HexCode})");
            }
        }

        private void SwatchButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is ColorItem item)
            {
                SelectedColor = item;
                ShowNotification($"Выбран оттенок: {item.Name} ({item.HexCode})");
            }
        }

        private void CopyHex_Click(object sender, RoutedEventArgs e)
        {
            string hex = string.Empty;
            if (sender is Button btn && btn.CommandParameter is string paramHex && !string.IsNullOrEmpty(paramHex))
            {
                hex = paramHex;
            }
            else if (SelectedColor != null)
            {
                hex = SelectedColor.HexCode;
            }

            if (!string.IsNullOrEmpty(hex))
            {
                CopyToClipboard(hex, $"HEX-код {hex} скопирован в буфер обмена!");
            }
        }

        private void CopyRgb_Click(object sender, RoutedEventArgs e)
        {
            string rgb = string.Empty;
            if (sender is Button btn && btn.CommandParameter is string paramRgb && !string.IsNullOrEmpty(paramRgb))
            {
                rgb = paramRgb;
            }
            else if (SelectedColor != null)
            {
                rgb = SelectedColor.RgbCode;
            }

            if (!string.IsNullOrEmpty(rgb))
            {
                CopyToClipboard(rgb, $"RGB-код {rgb} скопирован в буфер обмена!");
            }
        }

        private void CopyToClipboard(string text, string successMessage)
        {
            try
            {
                Clipboard.SetText(text);
                ShowNotification(successMessage);
            }
            catch (Exception ex)
            {
                ShowNotification($"Не удалось скопировать: {ex.Message}");
            }
        }

        private void ShowNotification(string message)
        {
            StatusNotification = message;
            IsNotificationActive = true;

            _notificationTimer?.Stop();
            _notificationTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3)
            };
            _notificationTimer.Tick += (s, e) =>
            {
                IsNotificationActive = false;
                _notificationTimer?.Stop();
            };
            _notificationTimer.Start();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
