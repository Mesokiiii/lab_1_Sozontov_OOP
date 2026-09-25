# Лабораторная работа №1 • Элементы подсистемы WPF и контейнеры компоновки

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0%20LTS-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![WPF](https://img.shields.io/badge/UI-WPF%20XAML-0078D7)](https://learn.microsoft.com/dotnet/desktop/wpf/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20MVVM-success)](docs/ARCHITECTURE.md)
[![Status](https://img.shields.io/badge/Build-Passing-brightgreen)](#)

Лабораторная работа по исследованию базовых элементов подсистемы Windows Presentation Foundation (WPF), принципов декларативного описания интерфейса на языке XAML, механизмов стилизации, системы ресурсов, архитектуры привязки данных (Data Binding) и двухпроходной модели компоновки элементов управления (Measure/Arrange).

---

## 📸 Скриншоты приложения

| 1.1. Основное (Персонализация и шрифты) | 1.2. Цветовая палитра (50 оттенков) |
| :---: | :---: |
| ![Основное](screenshots/tab1_main.png) | ![Цветовая палитра](screenshots/tab2_palette.png) |

| 1.3. Элементы управления (Expanders) | 1.4. Контейнеры компоновки |
| :---: | :---: |
| ![Элементы управления](screenshots/tab3_controls.png) | ![Контейнеры компоновки](screenshots/tab4_layout.png) |

---

## 🎯 Реализованные разделы согласно ТЗ

### 1.1. Основное
- **Сгруппированные настройки персонализации:**
  - Выбор темы оформления приложения из выпадающего списка (`ComboBox`: Тёмная, Светлая, Киберпанк, Системная).
  - Выбор языка приложения из выпадающего списка (`ComboBox`: Русский, English, Deutsch, Español, Français).
- **Сгруппированные настройки шрифтов:**
  - Выбор гарнитуры шрифта из выпадающего списка (`ComboBox`: Segoe UI, Arial, Calibri, Consolas, Times New Roman, Trebuchet MS, Verdana) с предпросмотром гарнитуры каждого элемента в списке.
  - Выбор размера шрифта через слайдер (`Slider`: диапазон 10–28 pt, шаг 1, насечки с шагом 2 pt, индикация значения в реальном времени, пресеты 11, 14, 18, 24 pt, переключатели Bold/Italic).
- **Live Preview:** карточка динамического предпросмотра с мгновенным откликом на изменение шрифта, кегля и пользовательского ввода.

### 1.2. Цветовая палитра
- Информационный блок с наименованием текущей темы приложения: *«Современная тёмная палитра (Modern Slate & Violet Accent)»*.
- Сгруппированные карточки 5 ключевых цветов:
  - **Основной (Primary):** `#3B82F6` (Royal Blue)
  - **Акцентный (Accent):** `#8B5CF6` (Violet / Indigo)
  - **Успех (Success):** `#10B981` (Emerald Green)
  - **Ошибка (Error):** `#EF4444` (Rose Red)
  - **Информация (Info):** `#06B6D4` (Cyan Blue)
- **5 специализированных таблиц DataGrid по 10 оттенков для каждого цвета (ровно 50 оттенков)**:
  - Образец цвета (`Border` со скруглением), наименование уровня (50–900), HEX-код, RGB-код, описание роли.
  - Интерактивная цветовая рампа для быстрого клика, единый режим обзора всех 50 оттенков и нижний **Инспектор оттенка** со стресс-тестом контрастности и копированием кодов в буфер обмена.

### 1.3. Элементы управления (сгруппированы по Expander)
- **Кнопки, пиктограммы и переключатели:**
  - Обычные кнопки во всех 5 цветах темы (Primary, Accent, Success, Error, Info) + Outlined + Disabled + Hover/Pressed.
  - Пиктограммы: векторные иконки `Path` (Сохранить, Удалить, Поиск, Настройки, Воспроизведение).
  - Переключатели: `ToggleSwitch` в 5 цветах темы, `CheckBox` во всех состояниях (Checked, Unchecked, Indeterminate, Disabled), `RadioButton` в связанной группе.
- **Поля ввода и списки:**
  - `TextBox` (обычный, с подсказкой Watermark, ReadOnly, Disabled, Validated).
  - `PasswordBox` с маскированием и стилизацией.
  - `ComboBox` со статусами и ролями.
  - `ListBox` со стилизованными элементами, иконками и подсветкой выбора.
  - `RichTextBox` с документом `FlowDocument` (жирный, курсив, маркеры, цветной текст).
- **Типографика (TextBlock и Label):**
  - Полная иерархия стилей для обоих элементов: Заголовок 1 (H1), Заголовок 2 (H2), Заголовок 3 (H3), Обычный текст, Подпись (Caption).
  - `Label` с поддержкой мнемоник `AccessKey` (`Alt+...`) и фокусом на `Target`.
- **Всплывающие подсказки (ToolTip):**
  - Обычные строковые, кастомные карточные (Rich ToolTip с иконкой и хоткеем) и статусные (Success, Info, Warning, Error).
- **TreeView:**
  - 4-уровневое иерархическое дерево проекта (`HierarchicalDataTemplate`), цветные бейджи типов узлов, контекстное меню, кнопки разворачивания/сворачивания всех веток.
- **DataGrid:**
  - Таблица с колонками ID, Наименование, Категория, Статус (с цветными точками-бейджами), Дата и активность (`CheckBox`). Чередование строк, добавление строк, контекстное меню.
- **ProgressBar:**
  - Детерминированный прогресс-бар с наложением процентов и интерактивным слайдером.
  - Недетерминированный анимированный прогресс-бар (`IsIndeterminate="True"`).
  - Линейка индикаторов во всех 5 цветах темы.
- **Главное меню и контекстное меню:**
  - Главное меню (`Menu`): Файл, Правка, Вид, Справка с хоткеями, иконками и разделителями.
  - Контекстные меню (`ContextMenu`) на карточках, строках таблицы и узлах дерева.
  - Верхний интерактивный журнал событий (Event Log), фиксирующий все действия пользователя в реальном времени.

### 1.4. Контейнеры компоновки
- Интерактивная демонстрация 6 ключевых панелей компоновки WPF на цветных фигурах палитры темы:
  1. `StackPanel` (переключатель ориентации Vertical / Horizontal).
  2. `Grid` (строки, колонки, RowSpan, ColumnSpan, ShowGridLines).
  3. `WrapPanel` (динамический перенос элементов, слайдер сжатия ширины рамки от 200 до 620 px).
  4. `DockPanel` (причаливание по сторонам света и переключатель `LastChildFill`).
  5. `Canvas` (абсолютные координаты, слайдеры X и Y для интерактивного перемещения блока).
  6. `UniformGrid` (равномерная сетка одинаковых ячеек, переключатель на 2, 3, 4, 6 колонок).
- Подробные теоретические карточки с описанием двухпроходной модели `Measure` / `Arrange`.

---

## 🏛️ Архитектура проекта

Кодовая база спроектирована по стандартам **Enterprise Clean Architecture** (уровень команд на 1000+ человек) с изоляцией по фичам:

```
WpfLabApp/
├── Common/                  # MVVM Core: ObservableObject (INPC), RelayCommand
├── Converters/              # Value Converters (BooleanToVisibility и др.)
├── Models/                  # Доменные модели по подсистемам:
│   ├── Personalization/     # ThemeOption, LanguageOption, FontOption
│   ├── Palette/             # ColorItem, ColorGroup, ColorPaletteData
│   └── Controls/            # ProjectTreeNode, DataGridSampleItem, StatusCategory
├── Services/                # Слой сервисов (INotificationService)
├── ViewModels/              # Модели представления (Clean MVVM)
├── Views/                   # Представления, разбитые по подпапкам:
│   ├── Main/                # MainTabView
│   ├── Palette/             # ColorPaletteTabView
│   ├── Controls/            # ControlsTabView, Part1, Part2
│   └── Layout/              # LayoutContainersTabView
├── Resources/               # Декомпозированные словари ресурсов:
│   ├── Theme/Colors.xaml    # Цветовые токены и кисти
│   └── Icons/VectorIcons.xaml # Векторные пиктограммы StreamGeometry
└── Styles/AppStyles.xaml    # Главный агрегатор стилей (MergedDictionaries)
```

Подробное руководство: [docs/ARCHITECTURE.md](docs/ARCHITECTURE.md).

---

## 🚀 Запуск проекта

### Требования
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) или новее.
* ОС Windows 10 / 11.

### Запуск через консоль
```powershell
# Клонирование репозитория
git clone https://github.com/Mesokiiii/lab_1_Sozontov_OOP.git
cd lab_1_Sozontov_OOP

# Сборка решения
dotnet build WpfLab1.sln

# Запуск приложения
dotnet run --project WpfLabApp\WpfLabApp.csproj
```

Или дважды кликните по скрипту `run.bat` в корне проекта.

---

## 📄 Отчёт по лабораторной работе
Полный академический отчёт с описанием целей, используемых элементов, трудностей и листингов XAML доступен в файле:
* [REPORT.md](REPORT.md) (дубликат в [docs/REPORT.md](docs/REPORT.md)).
