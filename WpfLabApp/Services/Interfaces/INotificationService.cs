namespace WpfLabApp.Services.Interfaces;

/// <summary>
/// Сервис уведомлений и работы с буфером обмена (Enterprise Services Layer).
/// </summary>
public interface INotificationService
{
    void CopyToClipboard(string text, string label);
    event Action<string>? NotificationReceived;
}
