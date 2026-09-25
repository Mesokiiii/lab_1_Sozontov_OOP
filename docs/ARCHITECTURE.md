# Руководство по архитектуре и стандартам чистого кода (Enterprise Architecture Guide)

## Проект: WPF Lab 1 • Масштабируемая подсистема пользовательского интерфейса
**Целевой масштаб команды:** 1 000+ инженеров (Enterprise Scale)  
**Технологический стек:** .NET 8.0 LTS (`net8.0-windows`), C# 12, WPF, XAML, MVVM  
**Стандарты качества:** SOLID, Clean Architecture, Zero-Warning Policy, WCAG AA Accessibility  

---

## 1. Концепция и архитектурные принципы

При разработке крупных корпоративных десктопных приложений с распределенной командой ключевыми приоритетами являются:
1. **Изоляция ответственности (Single Responsibility & Feature Segregation):**
   Каждая функциональная область изолирована в собственном пространстве имен и поддиректории. Разработчик фичи «Палитра» не сталкивается с merge-конфликтами разработчика фичи «Компоновка».
2. **Чистый MVVM (Model-View-ViewModel):**
   - **Model:** чистые данные предметной области, DTO и доменная логика (`Models/`). Не содержат ссылок на визуальные элементы WPF.
   - **ViewModel:** состояние представления, команды (`RelayCommand`), валидация (`ViewModels/`). Наследуются от `ObservableObject` (`INotifyPropertyChanged`).
   - **View:** декларативная разметка XAML и минимальный code-behind (`Views/`). Представление пассивно и связывается с ViewModel через Data Binding.
3. **Модульность дизайн-системы (Decoupled Styling):**
   Ресурсы стилей, кисти и векторные иконки разделены по независимым словарям (`Resources/Theme/`, `Resources/Icons/`, `Styles/`).
4. **Слабая связанность сервисов (Inversion of Control & Services):**
   Взаимодействие с внешними подсистемами (буфер обмена, логирование, системные события) вынесено за контракты интерфейсов (`Services/Interfaces/`).

---

## 2. Карта каталогов и организация проекта

```
C:\Users\1\Desktop\sozontov\
│
├── docs/                                    # Техническая документация и регламенты
│   ├── ARCHITECTURE.md                      # Данный архитектурный стандарт
│   ├── task.txt                             # Исходное техническое задание
│   └── REPORT.md                            # Полный академический отчет по лабораторной работе
│
├── screenshots/                             # Артефакты верификации и визуального регрессионного тестирования
│   ├── main_window.png                      # Снимок главного окна
│   ├── tab1_main.png                        # Снимок вкладки 1.1
│   ├── tab2_palette.png                     # Снимок вкладки 1.2
│   ├── tab3_controls.png                    # Снимок вкладки 1.3
│   └── tab4_layout.png                      # Снимок вкладки 1.4
│
├── WpfLab1.sln                              # Общесистемный файл решения Visual Studio
│
└── WpfLabApp/                               # Основной исполняемый проект приложения
    │
    ├── Common/                              # Базовый фундамент MVVM и инфраструктуры
    │   ├── ObservableObject.cs              # Thread-safe CallerMemberName INotifyPropertyChanged
    │   └── RelayCommand.cs                  # Типобезопасная реализация ICommand и ICommand<T>
    │
    ├── Converters/                          # XAML Value Converters
    │   └── ValueConverters.cs               # BooleanToVisibilityConverter, InverseBooleanConverter
    │
    ├── Models/                              # Доменные сущности, разделенные по подсистемам
    │   ├── Personalization/                 # Подсистема персонализации (ТЗ 1.1)
    │   │   └── PersonalizationModels.cs     # ThemeOption, LanguageOption, FontOption
    │   ├── Palette/                         # Подсистема цветовых палитр (ТЗ 1.2)
    │   │   ├── ColorItem.cs                 # Модели отдельного оттенка ColorItem и группы ColorGroup
    │   │   └── ColorPaletteData.cs          # Статический репозиторий 50 градуированных оттенков
    │   └── Controls/                        # Подсистема элементов управления (ТЗ 1.3)
    │       └── DataModels.cs                # ProjectTreeNode (TreeView), DataGridSampleItem, StatusCategory
    │
    ├── Services/                            # Слой сервисов предметной области
    │   ├── Interfaces/
    │   │   └── INotificationService.cs      # Контракт уведомлений и системного буфера обмена
    │   └── Implementations/
    │       └── NotificationService.cs       # Реализация системных уведомлений
    │
    ├── ViewModels/                          # Модели представления (MVVM)
    │   ├── MainWindowViewModel.cs           # Координатор главного окна и строки состояния
    │   ├── MainTabViewModel.cs              # Логика вкладки 1.1 «Основное» и Live Preview
    │   ├── ColorPaletteViewModel.cs         # Логика вкладки 1.2 «Цветовая палитра» и инспектора
    │   ├── ControlsViewModel.cs             # Логика вкладки 1.3 «Элементы управления»
    │   └── LayoutContainersViewModel.cs     # Логика вкладки 1.4 «Контейнеры компоновки»
    │
    ├── Views/                               # Модульные представления (UserControls & Windows)
    │   ├── Main/                            # Вкладка 1.1 «Основное»
    │   │   ├── MainTabView.xaml
    │   │   └── MainTabView.xaml.cs
    │   ├── Palette/                         # Вкладка 1.2 «Цветовая палитра»
    │   │   ├── ColorPaletteTabView.xaml
    │   │   └── ColorPaletteTabView.xaml.cs
    │   ├── Controls/                        # Вкладка 1.3 «Элементы управления»
    │   │   ├── ControlsTabView.xaml (.cs)   # Контейнер агрегации
    │   │   ├── ControlsPart1View.xaml (.cs) # Кнопки, поля ввода, типографика, тултипы
    │   │   └── ControlsPart2View.xaml (.cs) # TreeView, DataGrid, ProgressBar, Menu
    │   └── Layout/                          # Вкладка 1.4 «Контейнеры компоновки»
    │       ├── LayoutContainersTabView.xaml
    │       └── LayoutContainersTabView.xaml.cs
    │
    ├── Resources/                           # Модульные словари ресурсов дизайн-системы
    │   ├── Theme/
    │   │   └── Colors.xaml                  # Цветовые токены и замороженные SolidColorBrush
    │   └── Icons/
    │       └── VectorIcons.xaml             # Векторная графика StreamGeometry (GeoSave, GeoSearch и др.)
    │
    ├── Styles/                              # Глобальные стили элементов управления
    │   └── AppStyles.xaml                   # Корневой агрегатор объединенных словарей (MergedDictionaries)
    │
    ├── Infrastructure/                      # Инструменты тестирования и экспорта
    │   └── ScreenshotExporter.cs            # Автоматический генератор скриншотов высокого разрешения
    │
    ├── App.xaml                             # Декларация приложения
    ├── App.xaml.cs                          # Жизненный цикл
    ├── MainWindow.xaml                      # Оболочка главного окна
    ├── MainWindow.xaml.cs                   # Логика главного окна
    └── WpfLabApp.csproj                     # MSBuild SDK Project файл
```

---

## 3. Регламент и стандарты написания кода (Clean Code Rules)

### 3.1. Именование и структура файлов
1. **1 класс = 1 файл:** каждый класс, интерфейс или перечисление размещается в отдельном файле с совпадающим именем.
2. **Namespace отражает путь:** пространство имен строго повторяет структуру папок проекта (например, `WpfLabApp.Models.Palette` соответствует папке `Models/Palette`).
3. **C# 12 Features:** активно используются `file-scoped namespaces`, `records`, `primary constructors` и `pattern matching`.

### 3.2. Стандарты XAML
1. **Запрет хардкода цветов:** все цвета, кисти и отступы задаются через статические ресурсы (`StaticResource`) дизайн-системы из `Colors.xaml`.
2. **Векторные пиктограммы:** иконки определяются в виде `StreamGeometry` в `VectorIcons.xaml` и отображаются через `<Path Data="{StaticResource ...}" />`. Никаких растровых иконок низкого разрешения.
3. **Кастомизация ControlTemplate:** каждый шаблон контрола обязан объявлять валидные триггеры без создания циклических выражений (устранена ошибка `TemplateBinding` в `Style.Setters`).

### 3.3. Тестируемость и сборка
1. **Zero-Warning Policy:** компиляция решения командой `dotnet build` обязана завершаться с `0 Warnings, 0 Errors`.
2. **Автоматический запуск тестов:** проект поддерживает выполнение без дополнительных зависимостей на любой машине с .NET 8.0 SDK.
