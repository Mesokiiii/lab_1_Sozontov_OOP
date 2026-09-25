using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace WpfLabApp.Models
{
    /// <summary>
    /// Модель элемента цветовой палитры (оттенка)
    /// </summary>
    public class ColorItem
    {
        public string Name { get; set; } = string.Empty;
        public string Shade { get; set; } = string.Empty;
        public string HexCode { get; set; } = string.Empty;
        public string RgbCode { get; set; } = string.Empty;
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsBaseColor { get; set; }
        public string TextColorHex { get; set; } = "#FFFFFF";

        private SolidColorBrush? _brush;
        public SolidColorBrush Brush
        {
            get
            {
                if (_brush == null)
                {
                    var color = (Color)ColorConverter.ConvertFromString(HexCode);
                    _brush = new SolidColorBrush(color);
                    _brush.Freeze();
                }
                return _brush;
            }
        }

        private SolidColorBrush? _textBrush;
        public SolidColorBrush TextBrush
        {
            get
            {
                if (_textBrush == null)
                {
                    var color = (Color)ColorConverter.ConvertFromString(TextColorHex);
                    _textBrush = new SolidColorBrush(color);
                    _textBrush.Freeze();
                }
                return _textBrush;
            }
        }
    }

    /// <summary>
    /// Модель группы цветов палитры (например, Primary, Accent и т.д.)
    /// </summary>
    public class ColorGroup
    {
        public string GroupName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string BaseHex { get; set; } = string.Empty;
        public string BaseRgb { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string AccentBorderHex { get; set; } = "#3B82F6";
        public List<ColorItem> Shades { get; set; } = new();

        private SolidColorBrush? _baseBrush;
        public SolidColorBrush BaseBrush
        {
            get
            {
                if (_baseBrush == null)
                {
                    var color = (Color)ColorConverter.ConvertFromString(BaseHex);
                    _baseBrush = new SolidColorBrush(color);
                    _baseBrush.Freeze();
                }
                return _baseBrush;
            }
        }
    }
}
