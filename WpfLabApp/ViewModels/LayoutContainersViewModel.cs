using System.Windows.Controls;
using WpfLabApp.Common;

namespace WpfLabApp.ViewModels;

/// <summary>
/// Модель представления вкладки «1.4. Контейнеры компоновки» (ТЗ 1.4).
/// Инкапсулирует параметры интерактивных полигонов компоновки (StackPanel, Grid, WrapPanel, Canvas, UniformGrid).
/// </summary>
public class LayoutContainersViewModel : ObservableObject
{
    private Orientation _stackOrientation = Orientation.Vertical;
    private double _wrapPanelWidth = 480;
    private Orientation _wrapOrientation = Orientation.Horizontal;
    private bool _lastChildFill = true;
    private double _canvasX = 40;
    private double _canvasY = 40;
    private int _uniformGridColumns = 3;

    public Orientation StackOrientation
    {
        get => _stackOrientation;
        set => SetProperty(ref _stackOrientation, value);
    }

    public double WrapPanelWidth
    {
        get => _wrapPanelWidth;
        set => SetProperty(ref _wrapPanelWidth, value);
    }

    public Orientation WrapOrientation
    {
        get => _wrapOrientation;
        set => SetProperty(ref _wrapOrientation, value);
    }

    public bool LastChildFill
    {
        get => _lastChildFill;
        set => SetProperty(ref _lastChildFill, value);
    }

    public double CanvasX
    {
        get => _canvasX;
        set => SetProperty(ref _canvasX, value);
    }

    public double CanvasY
    {
        get => _canvasY;
        set => SetProperty(ref _canvasY, value);
    }

    public int UniformGridColumns
    {
        get => _uniformGridColumns;
        set => SetProperty(ref _uniformGridColumns, value);
    }
}
