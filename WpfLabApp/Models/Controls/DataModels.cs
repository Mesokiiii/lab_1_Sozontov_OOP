using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace WpfLabApp.Models
{
    /// <summary>
    /// Модель узла иерархического дерева (TreeView)
    /// </summary>
    public class ProjectTreeNode : INotifyPropertyChanged
    {
        private bool _isExpanded;
        private bool _isSelected;

        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = "📁";
        public string NodeType { get; set; } = "Folder";
        public string Info { get; set; } = string.Empty;
        public string BadgeColor { get; set; } = "#3B82F6";
        public ObservableCollection<ProjectTreeNode> Children { get; set; } = new ObservableCollection<ProjectTreeNode>();

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Создает демонстрационную структуру файлов и каталогов проекта
        /// </summary>
        public static ObservableCollection<ProjectTreeNode> GetSampleProjectStructure()
        {
            var root = new ProjectTreeNode
            {
                Name = "WpfLabApp (Решение)",
                Icon = "📦",
                NodeType = "Solution",
                Info = "Корневой проект .NET 8",
                BadgeColor = "#3B82F6",
                IsExpanded = true
            };

            // Ветка "Исходный код (.cs)"
            var srcNode = new ProjectTreeNode
            {
                Name = "Исходный код (.cs)",
                Icon = "📁",
                NodeType = "Folder",
                Info = "5 файлов C#",
                BadgeColor = "#3B82F6",
                IsExpanded = true
            };
            srcNode.Children.Add(new ProjectTreeNode { Name = "App.xaml.cs", Icon = "⚡", NodeType = "Source", Info = "Точка входа и инициализация", BadgeColor = "#10B981" });
            srcNode.Children.Add(new ProjectTreeNode { Name = "MainWindow.xaml.cs", Icon = "💻", NodeType = "Source", Info = "Логика навигации", BadgeColor = "#10B981" });

            var modelsFolder = new ProjectTreeNode { Name = "Models", Icon = "📁", NodeType = "Folder", Info = "Модели данных", BadgeColor = "#3B82F6", IsExpanded = true };
            modelsFolder.Children.Add(new ProjectTreeNode { Name = "DataModels.cs", Icon = "📄", NodeType = "Source", Info = "Классы узлов и записей", BadgeColor = "#10B981" });
            srcNode.Children.Add(modelsFolder);

            var viewsFolder = new ProjectTreeNode { Name = "Views", Icon = "📁", NodeType = "Folder", Info = "Код представлений", BadgeColor = "#3B82F6", IsExpanded = true };
            viewsFolder.Children.Add(new ProjectTreeNode { Name = "ControlsPart1View.xaml.cs", Icon = "📄", NodeType = "Source", Info = "События Part 1", BadgeColor = "#10B981" });
            viewsFolder.Children.Add(new ProjectTreeNode { Name = "ControlsPart2View.xaml.cs", Icon = "📄", NodeType = "Source", Info = "События Part 2", BadgeColor = "#10B981" });
            srcNode.Children.Add(viewsFolder);

            // Ветка "Разметка (.xaml)"
            var xamlNode = new ProjectTreeNode
            {
                Name = "Разметка (.xaml)",
                Icon = "📁",
                NodeType = "Folder",
                Info = "Интерфейс WPF",
                BadgeColor = "#8B5CF6",
                IsExpanded = true
            };
            xamlNode.Children.Add(new ProjectTreeNode { Name = "App.xaml", Icon = "💠", NodeType = "Markup", Info = "Словарь стилей приложения", BadgeColor = "#8B5CF6" });
            xamlNode.Children.Add(new ProjectTreeNode { Name = "MainWindow.xaml", Icon = "💠", NodeType = "Markup", Info = "Оболочка окна и вкладки", BadgeColor = "#8B5CF6" });
            xamlNode.Children.Add(new ProjectTreeNode { Name = "ControlsPart1View.xaml", Icon = "💠", NodeType = "Markup", Info = "Базовые элементы управления", BadgeColor = "#8B5CF6" });
            xamlNode.Children.Add(new ProjectTreeNode { Name = "ControlsPart2View.xaml", Icon = "💠", NodeType = "Markup", Info = "Дерево, таблица, прогресс, меню", BadgeColor = "#8B5CF6" });

            // Ветка "Стили и темы"
            var stylesNode = new ProjectTreeNode
            {
                Name = "Стили и темы",
                Icon = "📁",
                NodeType = "Folder",
                Info = "ResourceDictionary",
                BadgeColor = "#06B6D4",
                IsExpanded = false
            };
            stylesNode.Children.Add(new ProjectTreeNode { Name = "AppStyles.xaml", Icon = "🎨", NodeType = "Style", Info = "Цветовая схема и стили", BadgeColor = "#06B6D4" });

            // Ветка "Ресурсы (.png, .ico)"
            var resNode = new ProjectTreeNode
            {
                Name = "Ресурсы (.png, .ico)",
                Icon = "📁",
                NodeType = "Folder",
                Info = "Медиа и ассеты",
                BadgeColor = "#10B981",
                IsExpanded = false
            };
            resNode.Children.Add(new ProjectTreeNode { Name = "logo.png", Icon = "🖼️", NodeType = "Image", Info = "Логотип приложения (48 КБ)", BadgeColor = "#10B981" });
            resNode.Children.Add(new ProjectTreeNode { Name = "favicon.ico", Icon = "🖼️", NodeType = "Icon", Info = "Иконка окна (16 КБ)", BadgeColor = "#10B981" });
            resNode.Children.Add(new ProjectTreeNode { Name = "SegoeUI-Variable.ttf", Icon = "🔤", NodeType = "Font", Info = "Шрифт интерфейса", BadgeColor = "#10B981" });

            // Ветка "Конфигурация"
            var configNode = new ProjectTreeNode
            {
                Name = "Конфигурация",
                Icon = "📁",
                NodeType = "Folder",
                Info = "Параметры сборки",
                BadgeColor = "#EF4444",
                IsExpanded = false
            };
            configNode.Children.Add(new ProjectTreeNode { Name = "WpfLabApp.csproj", Icon = "⚙️", NodeType = "Config", Info = "MSBuild конфигурация проекта", BadgeColor = "#EF4444" });
            configNode.Children.Add(new ProjectTreeNode { Name = "appsettings.json", Icon = "⚙️", NodeType = "Config", Info = "Настройки окружения", BadgeColor = "#EF4444" });

            root.Children.Add(srcNode);
            root.Children.Add(xamlNode);
            root.Children.Add(stylesNode);
            root.Children.Add(resNode);
            root.Children.Add(configNode);

            return new ObservableCollection<ProjectTreeNode> { root };
        }
    }

    /// <summary>
    /// Тип статуса для цветного бейджа (включает цвета палитры п. 1.2.2)
    /// </summary>
    public enum StatusCategory
    {
        Primary,
        Accent,
        Success,
        Error,
        Info,
        Warning
    }

    /// <summary>
    /// Элемент данных для демонстрационной таблицы (DataGrid)
    /// </summary>
    public class DataGridSampleItem : INotifyPropertyChanged
    {
        private bool _isActive;
        private string _status = string.Empty;
        private StatusCategory _statusType;

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string FormattedDate => Date.ToString("dd.MM.yyyy HH:mm");

        public StatusCategory StatusType
        {
            get => _statusType;
            set
            {
                if (_statusType != value)
                {
                    _statusType = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(BadgeBackground));
                    OnPropertyChanged(nameof(BadgeForeground));
                    OnPropertyChanged(nameof(BadgeBorder));
                }
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged();
                }
            }
        }

        // Цвета бейджа статуса (соответствуют палитре приложения п. 1.2.2)
        public string BadgeBackground => StatusType switch
        {
            StatusCategory.Primary => "#1E1B4B",
            StatusCategory.Accent => "#2E1065",
            StatusCategory.Success => "#064E3B",
            StatusCategory.Error => "#450A0A",
            StatusCategory.Info => "#083344",
            StatusCategory.Warning => "#451A03",
            _ => "#1E293B"
        };

        public string BadgeForeground => StatusType switch
        {
            StatusCategory.Primary => "#93C5FD",
            StatusCategory.Accent => "#C4B5FD",
            StatusCategory.Success => "#34D399",
            StatusCategory.Error => "#F87171",
            StatusCategory.Info => "#22D3EE",
            StatusCategory.Warning => "#FBBF24",
            _ => "#94A3B8"
        };

        public string BadgeBorder => StatusType switch
        {
            StatusCategory.Primary => "#3B82F6",
            StatusCategory.Accent => "#8B5CF6",
            StatusCategory.Success => "#10B981",
            StatusCategory.Error => "#EF4444",
            StatusCategory.Info => "#06B6D4",
            StatusCategory.Warning => "#F59E0B",
            _ => "#475569"
        };

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Создает набор демонстрационных строк таблицы, демонстрирующих все цвета палитры
        /// </summary>
        public static ObservableCollection<DataGridSampleItem> GetSampleItems()
        {
            return new ObservableCollection<DataGridSampleItem>
            {
                new DataGridSampleItem
                {
                    Id = 101,
                    Name = "Модуль авторизации OAuth 2.0",
                    Category = "Безопасность",
                    Status = "Успешно",
                    StatusType = StatusCategory.Success,
                    Date = DateTime.Now.AddDays(-6).AddHours(2),
                    IsActive = true
                },
                new DataGridSampleItem
                {
                    Id = 102,
                    Name = "Парсер сетевых пакетов TCP/IP",
                    Category = "Сетевой стек",
                    Status = "Сбой синхронизации",
                    StatusType = StatusCategory.Error,
                    Date = DateTime.Now.AddDays(-5).AddHours(5),
                    IsActive = false
                },
                new DataGridSampleItem
                {
                    Id = 103,
                    Name = "Интеграция API GraphQL Gateway",
                    Category = "Интеграция",
                    Status = "Акцентная задача",
                    StatusType = StatusCategory.Accent,
                    Date = DateTime.Now.AddDays(-4).AddHours(3),
                    IsActive = true
                },
                new DataGridSampleItem
                {
                    Id = 104,
                    Name = "Компилятор шейдеров DirectX 12",
                    Category = "Рендеринг",
                    Status = "В обработке",
                    StatusType = StatusCategory.Info,
                    Date = DateTime.Now.AddDays(-3).AddHours(1),
                    IsActive = true
                },
                new DataGridSampleItem
                {
                    Id = 105,
                    Name = "Ядро сервиса очередей сообщений",
                    Category = "Инфраструктура",
                    Status = "Основной поток",
                    StatusType = StatusCategory.Primary,
                    Date = DateTime.Now.AddDays(-2).AddHours(4),
                    IsActive = true
                },
                new DataGridSampleItem
                {
                    Id = 106,
                    Name = "Кэш-провайдер Redis Cluster",
                    Category = "База данных",
                    Status = "Ожидание подтверждения",
                    StatusType = StatusCategory.Warning,
                    Date = DateTime.Now.AddDays(-1).AddHours(7),
                    IsActive = true
                },
                new DataGridSampleItem
                {
                    Id = 107,
                    Name = "Генератор PDF-отчетов аналитики",
                    Category = "Документооборот",
                    Status = "Успешно",
                    StatusType = StatusCategory.Success,
                    Date = DateTime.Now.AddHours(-6),
                    IsActive = true
                },
                new DataGridSampleItem
                {
                    Id = 108,
                    Name = "Служба фонового бэкапа хранилища",
                    Category = "Резервное копирование",
                    Status = "Сбой контрольной суммы",
                    StatusType = StatusCategory.Error,
                    Date = DateTime.Now.AddHours(-2),
                    IsActive = false
                }
            };
        }
    }
}
