using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfLabApp.Common;

/// <summary>
/// Базовый класс для всех моделей и моделей представления (MVVM),
/// обеспечивающий реализацию <see cref="INotifyPropertyChanged"/>
/// с типобезопасной проверкой изменения значений.
/// Соответствует стандартам Enterprise Clean Architecture.
/// </summary>
public abstract class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Уведомляет подписчиков об изменении свойства.
    /// </summary>
    /// <param name="propertyName">Имя свойства (определяется автоматически).</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Устанавливает новое значение поля и инициирует событие <see cref="PropertyChanged"/>, если значение изменилось.
    /// </summary>
    /// <typeparam name="T">Тип поля.</typeparam>
    /// <param name="field">Ссылка на поле.</param>
    /// <param name="value">Новое значение.</param>
    /// <param name="propertyName">Имя свойства.</param>
    /// <returns>True, если значение было изменено; иначе False.</returns>
    protected virtual bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
