using System.Windows;
using WpfLabApp.Services.Interfaces;

namespace WpfLabApp.Services.Implementations;

/// <summary>
/// Реализация сервиса уведомлений и взаимодействия с системным буфером обмена.
/// </summary>
public class NotificationService : INotificationService
{
    private static NotificationService? _instance;
    public static NotificationService Instance => _instance ??= new NotificationService();

    public event Action<string>? NotificationReceived;

    public void CopyToClipboard(string text, string label)
    {
        try
        {
            Clipboard.SetText(text);
            NotificationReceived?.Invoke($"Скопировано в буфер: {label} ({text})");
        }
        catch (Exception ex)
        {
            NotificationReceived?.Invoke($"Не удалось скопировать {label}: {ex.Message}");
        }
    }
}
