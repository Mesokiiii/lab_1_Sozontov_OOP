using WpfLabApp.Common;
using WpfLabApp.Services.Implementations;

namespace WpfLabApp.ViewModels;

/// <summary>
/// Главная модель представления окна приложения (MainWindow).
/// Инкапсулирует статусную строку, выбранную вкладку и системные команды.
/// </summary>
public class MainWindowViewModel : ObservableObject
{
    private string _statusMessage = "Готово • Выберите вкладку для перехода к элементам лабораторной работы";
    private int _selectedTabIndex = 0;

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public int SelectedTabIndex
    {
        get => _selectedTabIndex;
        set => SetProperty(ref _selectedTabIndex, value);
    }

    public MainWindowViewModel()
    {
        NotificationService.Instance.NotificationReceived += message =>
        {
            StatusMessage = message;
        };
    }
}
