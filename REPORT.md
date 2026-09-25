# Отчет по лабораторной работе №1
## «Исследование базовых элементов подсистемы WPF и контейнеров компоновки для построения графического интерфейса пользователя»

---

### **Сведения о работе**
- **Дисциплина:** разработка графических интерфейсов пользователя / Технологии программирования на платформе .NET
- **Тема:** элементы подсистемы WPF (Windows Presentation Foundation) и контейнеры компоновки
- **Среда разработки:** Visual Studio / Visual Studio Code / JetBrains Rider
- **Платформа и стек:** .NET 8.0, C# 12, WPF, XAML, MVVM-паттерн
- **Операционная система:** Microsoft Windows 11 / 10

---

## 1. Цели и задачи лабораторной работы

### 1.1. Цель работы
Изучить базовые элементы подсистемы Windows Presentation Foundation (WPF), принципы декларативного описания интерфейса на языке XAML, механизмы стилизации, систему ресурсов, архитектуру привязки данных (Data Binding) и двухпроходную модель компоновки элементов управления (Measure/Arrange) для создания адаптивных, высокопроизводительных настольных графических интерфейсов.

### 1.2. Задачи работы
1. **Проектирование архитектуры приложения:**
   - Разработать масштабируемую модульную структуру проекта с разделением представлений (`Views`), моделей данных (`Models`) и централизованной библиотеки стилей (`Styles`).
   - Реализовать многостраничную навигацию на базе элемента `TabControl` с кастомизацией визуальных шаблонов (`ControlTemplate`).
2. **Разработка вкладки 1.1 («Основное»):**
   - Создать сгруппированные элементы персонализации: выбор темы оформления и языка локализации через раскрывающиеся списки (`ComboBox`).
   - Создать сгруппированные настройки типографики: выбор гарнитуры шрифта (`ComboBox`) и размера шрифта с помощью ползунка (`Slider`) с двусторонней синхронизацией и блоком динамического предпросмотра (Live Preview).
3. **Разработка вкладки 1.2 («Цветовая палитра»):**
   - Спроектировать дизайн-систему на базе 5 ключевых цветов: основной (`Primary`), акцентный (`Accent`) и индикаторные (`Success`, `Error`, `Info`).
   - Разработать математически выверенную шкалу из 10 оттенков (от 50 до 900) для каждого базового цвета.
   - Реализовать табличное и картографическое отображение оттенков с выводом наименования, HEX-кода, RGB-компонентов и контрастного текста.
4. **Разработка вкладки 1.3 («Элементы управления»):**
   - Реализовать и визуально сгруппировать по распахиваемым контейнерам (`Expander`) компоненты подсистемы WPF для каждого фирменного цветового исполнения:
     - Кнопки: стандартные (`Button`), векторные пиктограммы (`Path`/`StreamGeometry`), переключатели (`ToggleButton`, `RadioButton`).
     - Элементы текстового ввода и редактирования: `TextBox`, `PasswordBox`, `RichTextBox` (на базе `FlowDocument`).
     - Элементы вывода текста: `TextBlock` и `Label` (с многоуровневой иерархией заголовков H1–H3, основного текста и подписей).
     - Иерархические списки: `TreeView` с `HierarchicalDataTemplate` для визуализации дерева каталогов проекта.
     - Таблицы данных: `DataGrid` со специализированными колонками (Text, Template с цветными бейджами, CheckBox).
     - Индикаторы выполнения: `ProgressBar` в детерминированном и пульсирующем (`IsIndeterminate`) режимах.
     - Информационные подсказки: простые и расширенные `ToolTip` с заголовком и иконкой.
     - Навигационные меню: строка меню `Menu`, пункты `MenuItem` с клавиатурными акселераторами (`InputGestureText`) и контекстное всплывающее меню `ContextMenu`.
5. **Разработка вкладки 1.4 («Контейнеры компоновки»):**
   - Наглядно продемонстрировать различия в поведении, алгоритмах измерения и размещения 6 ключевых панелей компоновки: `StackPanel`, `Grid`, `WrapPanel`, `DockPanel`, `Canvas`, `UniformGrid`.
   - Использовать стилизованные цветные блоки фирменной темы приложения (`Primary`, `Accent`, `Success`, `Error`, `Info`).
   - Оснастить каждый контейнер интерактивными элементами управления (переключатели ориентации, ползунки ширины, слайдеры координат, счетчики колонок, чекбоксы прикрепления) и теоретическим академическим описанием фаз `Measure` и `Arrange`.
6. **Тестирование и верификация:**
   - Провести полную проверку работоспособности и компиляции решения командой `dotnet build`.
   - Составить подробный отчет с листингами кода, пояснениями и анализом трудностей разработки.

---

## 2. Описание приложения и используемых элементов подсистемы WPF

### 2.1. Общая архитектура и структура решения

Решение `WpfLab1.sln` построено на базе современного SDK-проекта .NET 8.0 (`net8.0-windows`) с включенной поддержкой подсистемы WPF (`<UseWPF>true</UseWPF>`). Архитектура проекта организована по модульному принципу:

```
C:\Users\1\Desktop\sozontov\
│
├── WpfLab1.sln                              # Файл решения Visual Studio / .NET CLI
│
└── WpfLabApp/                               # Основной исполняемый проект WPF
    ├── App.xaml                             # Декларация приложения и глобальных ресурсов
    ├── App.xaml.cs                          # Точка входа и инициализация жизненного цикла
    ├── MainWindow.xaml                      # Главное окно: Header, TabControl, StatusBar
    ├── MainWindow.xaml.cs                   # Логика главного окна
    │
    ├── Styles/                              # Дизайн-система и словари ресурсов
    │   └── AppStyles.xaml                   # Цветовая палитра, кисти SolidColorBrush, стили
    │
    ├── Models/                              # Модели данных предметной области
    │   ├── ColorItem.cs                     # Модели ColorItem, ColorGroup (для палитры)
    │   ├── ColorPaletteData.cs              # Статический репозиторий 50 оттенков палитры
    │   └── DataModels.cs                    # Модели ProjectTreeNode (TreeView), DataGridSampleItem
    │
    └── Views/                               # Модульные представления (UserControl)
        ├── MainTabView.xaml (.cs)           # 1.1 Вкладка «Основное» (персонализация, шрифты)
        ├── ColorPaletteTabView.xaml (.cs)   # 1.2 Вкладка «Цветовая палитра» (5 групп, 50 оттенков)
        ├── ControlsTabView.xaml (.cs)       # 1.3 Главная вкладка «Элементы управления»
        ├── ControlsPart1View.xaml (.cs)     # 1.3.1 Кнопки, поля ввода, типографика
        ├── ControlsPart2View.xaml (.cs)     # 1.3.2 TreeView, DataGrid, ProgressBar, ToolTip, Menu
        └── LayoutContainersTabView.xaml (.cs)# 1.4 Вкладка «Контейнеры компоновки»
```

#### Глобальный словарь ресурсов (`AppStyles.xaml`)
В приложении реализована единая темная тема оформления (`Dark Modern Slate UI`), опирающаяся на цвета `BgDark` (`#0F172A`), `BgCardDark` (`#1E293B`) и систему акцентных/индикаторных кистей:
- `PrimaryColor` = `#3B82F6` (Синий — основной цвет действий и фокуса)
- `AccentColor` = `#8B5CF6` (Фиолетовый — вспомогательный акцент)
- `SuccessColor` = `#10B981` (Изумрудно-зеленый — успешные операции, валидность)
- `ErrorColor` = `#EF4444` (Красный — ошибки, критические предупреждения, удаление)
- `InfoColor` = `#06B6D4` (Голубой/Циан — информационные маркеры, подсказки)

Фрагмент `AppStyles.xaml`:
```xml
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <!-- Базовые цвета фона и текста -->
    <Color x:Key="BgDark">#0F172A</Color>
    <Color x:Key="BgCardDark">#1E293B</Color>
    <Color x:Key="TextPrimaryDark">#F8FAFC</Color>
    <Color x:Key="TextSecondaryDark">#94A3B8</Color>

    <!-- Фирменные цвета палитры -->
    <Color x:Key="PrimaryColor">#3B82F6</Color>
    <Color x:Key="AccentColor">#8B5CF6</Color>
    <Color x:Key="SuccessColor">#10B981</Color>
    <Color x:Key="ErrorColor">#EF4444</Color>
    <Color x:Key="InfoColor">#06B6D4</Color>

    <!-- Кисти SolidColorBrush -->
    <SolidColorBrush x:Key="BgBrush" Color="{StaticResource BgDark}"/>
    <SolidColorBrush x:Key="BgCardBrush" Color="{StaticResource BgCardDark}"/>
    <SolidColorBrush x:Key="PrimaryBrush" Color="{StaticResource PrimaryColor}"/>
    <SolidColorBrush x:Key="AccentBrush" Color="{StaticResource AccentColor}"/>
    <SolidColorBrush x:Key="SuccessBrush" Color="{StaticResource SuccessColor}"/>
    <SolidColorBrush x:Key="ErrorBrush" Color="{StaticResource ErrorColor}"/>
    <SolidColorBrush x:Key="InfoBrush" Color="{StaticResource InfoColor}"/>
</ResourceDictionary>
```

---

### 2.2. Главное окно приложения (`MainWindow.xaml`)

Главное окно разделено на три горизонтальные секции при помощи корневого контейнера `Grid`:
1. **Верхний колонтитул (Header Banner):** отображает название работы, описание и бейдж технологического стека (`WPF • .NET 8 • C#`).
2. **Основная рабочая область (`TabControl`):** четыре полнофункциональные вкладки.
3. **Строка состояния (Status Bar):** нижняя панель с индикацией статуса загрузки модулей.

#### Стилизация `TabControl` и `TabItem`
Стандартный вид `TabItem` в Windows не соответствует современной темной теме. Поэтому в ресурсах `TabControl` был полностью переопределен шаблон элемента управления (`ControlTemplate`):

```xml
<TabControl Grid.Row="1" Margin="16" Background="Transparent" BorderThickness="0">
    <TabControl.Resources>
        <Style TargetType="TabItem">
            <Setter Property="FontSize" Value="14"/>
            <Setter Property="FontWeight" Value="SemiBold"/>
            <Setter Property="Padding" Value="18,10"/>
            <Setter Property="Foreground" Value="{StaticResource TextSecondaryBrush}"/>
            <Setter Property="Background" Value="{StaticResource BgCardBrush}"/>
            <Setter Property="BorderBrush" Value="{StaticResource BorderBrushDefault}"/>
            <Setter Property="Margin" Value="0,0,4,0"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="TabItem">
                        <Border Name="Border" Background="{TemplateBinding Background}" 
                                BorderBrush="{TemplateBinding BorderBrush}" 
                                BorderThickness="1,1,1,0" CornerRadius="8,8,0,0" 
                                Padding="{TemplateBinding Padding}">
                            <ContentPresenter ContentSource="Header" 
                                              HorizontalAlignment="Center" 
                                              VerticalAlignment="Center"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsSelected" Value="True">
                                <Setter TargetName="Border" Property="Background" Value="{StaticResource PrimaryBrush}"/>
                                <Setter Property="Foreground" Value="White"/>
                            </Trigger>
                            <Trigger Property="IsMouseOver" Value="True">
                                <Setter Property="Foreground" Value="White"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </TabControl.Resources>
    
    <TabItem Header="1. Основное"> ... </TabItem>
    <TabItem Header="2. Цветовая палитра"> ... </TabItem>
    <TabItem Header="3. Элементы управления"> ... </TabItem>
    <TabItem Header="4. Контейнеры компоновки"> ... </TabItem>
</TabControl>
```

---

### 2.3. Вкладка 1.1 «Основное» (Персонализация и шрифты)

Вкладка демонстрирует элементы управления конфигурацией пользовательского интерфейса. Согласно техническому заданию, на ней размещены две сгруппированные панели:
1. **Настройки персонализации:**
   - Распахиваемый список выбора темы приложения (`ComboBox`): «тёмная (Dark Slate)», «Светлая (Modern Light)», «Высококонтрастная (High Contrast)», «Киберпанк (Neon Dark)».
   - Распахиваемый список выбора языка интерфейса (`ComboBox`): русский (RU), english (US), deutsch (DE), français (FR), 中文 (CN).
2. **Настройки шрифтов:**
   - Распахиваемый список выбора гарнитуры шрифта (`ComboBox`): Segoe UI, Roboto, Open Sans, Montserrat, Consolas, Fira Code.
   - Ползунок плавного выбора кегля шрифта (`Slider`): диапазон от 10 pt до 28 pt с шагом 1 pt, отображением числового значения в реальном времени и набором кнопок быстрых пресетов (12px, 14px, 16px, 18px).
   - Интерактивная карточка «Живой предпросмотр» (`Live Preview Card`), текстовое содержимое которой мгновенно изменяет размер и начертание через механизм привязки данных (`Binding ElementName=FontSizeSlider, Path=Value`).

```xml
<!-- Слайдер выбора размера шрифта с двусторонним связыванием -->
<Slider x:Name="FontSizeSlider" 
        Minimum="10" Maximum="28" Value="14" 
        TickFrequency="1" IsSnapToTickEnabled="True"
        VerticalAlignment="Center"/>

<TextBlock Text="{Binding ElementName=FontSizeSlider, Path=Value, StringFormat={}{0:0} pt}" 
           Foreground="{StaticResource PrimaryBrush}" 
           FontWeight="Bold" FontSize="15"/>

<!-- Блок предварительного просмотра -->
<TextBlock Text="Съешь же ещё этих мягких французских булок, да выпей чаю. The quick brown fox jumps over the lazy dog."
           FontFamily="{Binding ElementName=FontFamilyCombo, Path=SelectedItem.Tag}"
           FontSize="{Binding ElementName=FontSizeSlider, Path=Value}"
           Foreground="{StaticResource TextPrimaryBrush}"
           TextWrapping="Wrap"/>
```

---

### 2.4. Вкладка 1.2 «Цветовая палитра»

Вкладка реализует законченную палитру дизайн-системы приложения. 
В верхней части отображается наименование активной темы («Dark Slate / Modern Enterprise Palette») с описанием концепции. Ниже представлены карточки пяти ключевых категорий:
1. **Основной цвет (Primary):** `#3B82F6` (Blue-500) — фокусные действия, главные кнопки, вкладки.
2. **Акцентный цвет (Accent):** `#8B5CF6` (Violet-500) — второстепенные интерактивные элементы, бейджи, ползунки.
3. **Успех (Success):** `#10B981` (Emerald-500) — индикация успешного завершения, валидации, онлайна.
4. **Ошибка (Error):** `#EF4444` (Red-500) — деструктивные действия, предупреждения об ошибках.
5. **Информация (Info):** `#06B6D4` (Cyan-500) — справочные сообщения, уведомления, вспомогательные теги.

#### 10 оттенков для каждого цвета
Для каждого из 5 цветов сформирована таблица из 10 градаций яркости (шкала 50, 100, 200, 300, 400, 500, 600, 700, 800, 900). Каждая строка таблицы отображает:
- Цветовой образец (плашка с плавным скруглением);
- Наименование оттенка (например, `Primary-500 (Base)`);
- HEX-код цвета (например, `#3B82F6`);
- RGB-компоненты (например, `RGB(59, 130, 246)`);
- Назначение оттенка в интерфейсе (фоны, границы, градиенты, активные состояния).

```xml
<!-- Пример шаблона строки в таблице палитры оттенков -->
<DataTemplate DataType="{x:Type models:ColorItem}">
    <Border Background="{StaticResource BgCardHoverBrush}" CornerRadius="6" Margin="0,2" Padding="8,6">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="40"/>
                <ColumnDefinition Width="140"/>
                <ColumnDefinition Width="90"/>
                <ColumnDefinition Width="130"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <!-- Цветовая плашка -->
            <Border Grid.Column="0" Background="{Binding Brush}" Height="24" Width="32" CornerRadius="4" BorderBrush="#33FFFFFF" BorderThickness="1"/>
            <!-- Наименование -->
            <TextBlock Grid.Column="1" Text="{Binding Name}" Foreground="White" FontWeight="SemiBold" VerticalAlignment="Center" Margin="8,0,0,0"/>
            <!-- HEX-код -->
            <TextBlock Grid.Column="2" Text="{Binding HexCode}" Foreground="{StaticResource PrimaryBrush}" FontFamily="Consolas" VerticalAlignment="Center"/>
            <!-- RGB-код -->
            <TextBlock Grid.Column="3" Text="{Binding RgbCode}" Foreground="{StaticResource TextSecondaryBrush}" FontFamily="Consolas" VerticalAlignment="Center"/>
            <!-- Описание -->
            <TextBlock Grid.Column="4" Text="{Binding Description}" Foreground="{StaticResource TextMutedBrush}" VerticalAlignment="Center"/>
        </Grid>
    </Border>
</DataTemplate>
```

---

### 2.5. Вкладка 1.3 «Элементы управления»

Вкладка организована в виде набора раскрываемых контейнеров (`Expander`) с аккордеонной структурой. Каждая секция демонстрирует поведение компонентов для всех цветов палитры (Primary, Accent, Success, Error, Info):

#### 2.5.1. Кнопки (Buttons)
- **Стандартные кнопки (`Button`):** обычное состояние, наведение курсора (`IsMouseOver`), нажатие (`IsPressed`), отключенное состояние (`IsEnabled="False"`).
- **Кнопки с пиктограммами (Icon Buttons):** векторная отрисовка векторных путей через элемент `Path` с геометрией `StreamGeometry` (сохранение, удаление, поиск, настройки, воспроизведение).
- **Кнопки-переключатели (`ToggleButton`):** кнопки с фиксацией двух состояний («Включено / Выключено»), с изменением цвета фона и текста.
- **Радиокнопки (`RadioButton`):** взаимоисключающий выбор опций в рамках единой группы `GroupName`.

#### 2.5.2. Списки и поля ввода
- **`ListBox`:** список с возможностью единичного и множественного выделения (`SelectionMode`), кастомной отрисовкой элементов через `ItemTemplate`.
- **`ComboBox`:** распахивающийся список с текстовыми элементами, иконками и цветными маркерами.
- **`TextBox`:** однострочные и многострочные текстовые поля с поддержкой `TextWrapping="Wrap"`, `AcceptsReturn="True"`, плейсхолдерами и валидационной подсветкой.
- **`PasswordBox`:** специализированный компонент ввода секретных данных с автоматическим маскированием символов точками и хранением пароля в безопасном объекте памяти `SecureString`.
- **`RichTextBox`:** полнофункциональный редактор форматированного текста на основе документов `FlowDocument`, поддерживающий параграфы (`Paragraph`), полужирный (`Bold`), курсив (`Italic`), подчеркивание (`Underline`) и списки (`List`/`ListItem`).

#### 2.5.3. Текстовые элементы вывода
- **`TextBlock` и `Label`:** демонстрация семантической типографической иерархии:
  - Заголовок H1 (24 pt, Bold)
  - Заголовок H2 (18 pt, SemiBold)
  - Заголовок H3 (14 pt, Medium)
  - Основной текст Body (12 pt, Regular)
  - Вспомогательная подпись Caption / Muted (10 pt, Light)

#### 2.5.4. Иерархические деревья (`TreeView`)
Элемент `TreeView` заполнен данными модели `ProjectTreeNode` и визуализирует файловую структуру современного проекта .NET:
- Ветви папок: `исходный код (C#)`, `Разметка (XAML)`, `Стили и темы`, `Ресурсы`, `Конфигурация`.
- Использование `HierarchicalDataTemplate` для рекурсивного разворачивания дочерних узлов (`ItemsSource="{Binding Children}"`).
- Отображение иконки файла, имени, информационного бейджа размера файла и цветного индикатора типа узла.

```xml
<TreeView ItemsSource="{Binding ProjectNodes}" Background="#0F172A" BorderBrush="#334155">
    <TreeView.ItemTemplate>
        <HierarchicalDataTemplate ItemsSource="{Binding Children}">
            <StackPanel Orientation="Horizontal" Margin="2,3">
                <TextBlock Text="{Binding Icon}" Margin="0,0,6,0" FontSize="13"/>
                <TextBlock Text="{Binding Name}" Foreground="{StaticResource TextPrimaryBrush}" FontWeight="SemiBold"/>
                <Border Background="{Binding BadgeColor}" CornerRadius="3" Padding="4,1" Margin="8,0,0,0">
                    <TextBlock Text="{Binding Info}" Foreground="White" FontSize="9"/>
                </Border>
            </StackPanel>
        </HierarchicalDataTemplate>
    </TreeView.ItemTemplate>
</TreeView>
```

#### 2.5.5. Таблица данных (`DataGrid`)
Элемент `DataGrid` демонстрирует табличное отображение структурированных данных коллекции `ObservableCollection<DataGridSampleItem>`:
- Автогенерация колонок отключена (`AutoGenerateColumns="False"`).
- `DataGridTextColumn`: текстовые колонки ID, наименование, категория, дата.
- `DataGridTemplateColumn`: кастомная колонка со стилизованными цветными бейджами статусов (Active, Pending, Completed, Failed, Warning).
- `DataGridCheckBoxColumn`: интерактивный флажок переключения активности записи.
- Включены стили чередования строк (`AlternatingRowBackground="#162032"`), подсветка строки при наведении и выделении, сортировка по клику на заголовки.

#### 2.5.6. Индикаторы выполнения (`ProgressBar`)
- **Детерминированный режим:** отображает точный процент выполнения (от 0% до 100%) со связанным ползунком и числовым счетчиком.
- **Недетерминированный режим (`IsIndeterminate="True"`):** анимированная бегущая волна для операций с неизвестной длительностью.

#### 2.5.7. Всплывающие подсказки (`ToolTip`)
- Простые текстовые подсказки: `ToolTip="Краткая информация об элементе"`.
- Расширенные подсказки (`Rich ToolTip`): содержат заголовок, разделительную линию, цветную иконку предупреждения/успеха и расширенное текстовое описание, стилизованное через свойства `ToolTipService.InitialShowDelay` и `ToolTipService.ShowDuration`.

#### 2.5.8. Меню и контекстные меню (`Menu`, `ContextMenu`)
- **Строка меню (`Menu`):** горизонтальная панель с выпадающими пунктами `Файл`, `Правка`, `Вид`, `Справка`, разделителями (`Separator`), иконками и текстом горячих клавиш (`InputGestureText="Ctrl+S"`, `InputGestureText="Ctrl+Z"`).
- **Контекстное меню (`ContextMenu`):** всплывающее меню, вызываемое по правому клику мыши на интерактивной карточке, предоставляющее быстрые операции копирования, экспорта и сброса настроек.

---

### 2.6. Вкладка 1.4 «Контейнеры компоновки» (Layout Containers)

Вкладка посвящена детальному сравнительному анализу и интерактивной демонстрации шести базовых панелей компоновки подсистемы WPF. 

#### Двухпроходная модель компоновки WPF (Measure & Arrange)
Любой контейнер компоновки, наследующийся от `System.Windows.Controls.Panel`, участвует в двухэтапном процессе расчета геометрии:
1. **Фаза измерения (`Measure`):** 
   - Родительский контейнер вызывает метод `child.Measure(availableSize)` для каждого дочернего элемента, передавая ему доступный размер.
   - Элемент рассчитывает свой желаемый размер на основе содержимого, свойств `Width`, `Height`, `Margin`, `Padding` и сохраняет его в свойстве `DesiredSize`.
2. **Фаза размещения (`Arrange`):**
   - Контейнер вызывает `child.Arrange(finalRect)`, где `finalRect` определяет точную прямоугольную область (координаты X, Y и размеры Width, Height), выделенную элементу.
   - Внутри `finalRect` элемент позиционируется с учетом свойств `HorizontalAlignment` и `VerticalAlignment`.

---

#### 1. `StackPanel` (Линейная компоновка)
- **Принцип работы:** последовательно размещает дочерние элементы в стек вдоль одной линии — вертикально (`Orientation="Vertical"`, по умолчанию) или горизонтально (`Orientation="Horizontal"`).
- **Особенности Measure:** контейнер передает дочерним элементам бесконечность (`double.PositiveInfinity`) вдоль главной оси и фиксированное доступное пространство по поперечной оси. Элементы могут запросить любой размер по главной оси.
- **Особенности Arrange:** элементы позиционируются встык друг за другом. По поперечной оси элемент растягивается (`Stretch`), если не заданы явные ограничения ширины/высоты.
- **Интерактивные элементы в приложении:** переключатели «Вертикальная» / «Горизонтальная» ориентация и чекбокс фиксации размеров.
- **Рекомендации:** идеален для списков кнопок, тулбаров, простых диалоговых форм. Для длинных списков данных следует использовать `VirtualizingStackPanel`.

```xml
<StackPanel Orientation="Vertical">
    <Border Background="{StaticResource PrimaryBrush}" Height="42" Margin="4"/>
    <Border Background="{StaticResource AccentBrush}" Height="42" Margin="4"/>
    <Border Background="{StaticResource SuccessBrush}" Height="42" Margin="4"/>
    <Border Background="{StaticResource InfoBrush}" Height="42" Margin="4"/>
    <Border Background="{StaticResource ErrorBrush}" Height="42" Margin="4"/>
</StackPanel>
```

---

#### 2. `Grid` (Табличная компоновка)
- **Принцип работы:** разбивает доступную область на строки (`RowDefinitions`) и столбцы (`ColumnDefinitions`). Самый мощный и гибкий контейнер WPF.
- **Типы размеров ячеек:**
  1. *Абсолютные (Fixed):* жестко фиксированные размеры в пикселях (например, `Height="65"`, `Width="110"`).
  2. *По содержимому (`Auto`):* размер ячейки вычисляется исходя из максимального требуемого размера помещенных в нее элементов.
  3. *Пропорциональные / Звездные (`Star`, `*`):* делят между собой оставшееся после Fixed и Auto пространство в соответствии с числовыми коэффициентами (например, колонка `2*` получает ровно в два раза больше пикселей, чем колонка `1*`).
- **Объединение ячеек:** 
  - `Grid.RowSpan="N"` — растягивает элемент по вертикали на N смежных строк.
  - `Grid.ColumnSpan="M"` — растягивает элемент по горизонтали на M смежных столбцов.
- **Интерактивные элементы в приложении:** чекбокс включения линий сетки (`ShowGridLines="True"`), демонстрация объединения ячеек сайдбара (`RowSpan="2"`), заголовка и футера (`ColumnSpan="2"`).

```xml
<Grid ShowGridLines="False">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="1*"/>
        <RowDefinition Height="65"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="110"/>
        <ColumnDefinition Width="2*"/>
        <ColumnDefinition Width="1*"/>
    </Grid.ColumnDefinitions>

    <!-- Заголовок на 2 колонки -->
    <Border Grid.Row="0" Grid.Column="1" Grid.ColumnSpan="2" Background="{StaticResource PrimaryBrush}"/>
    <!-- Боковая панель на 2 строки -->
    <Border Grid.Row="1" Grid.RowSpan="2" Grid.Column="0" Background="{StaticResource AccentBrush}"/>
    <!-- Основное содержимое -->
    <Border Grid.Row="1" Grid.Column="1" Background="{StaticResource SuccessBrush}"/>
</Grid>
```

---

#### 3. `WrapPanel` (Компоновка с автоматическим переносом)
- **Принцип работы:** последовательно выстраивает элементы в строку. Когда очередному элементу не хватает ширины родительского контейнера, он автоматически переносится на следующую строку.
- **Особенности Measure:** контейнер суммирует ширину элементов в строке. При превышении доступной ширины строка закрывается, ее максимальная высота фиксируется, и начинается измерение новой строки.
- **Свойства `ItemWidth` и `ItemHeight`:** позволяют принудительно задать одинаковый размер ячейки для всех детей (удобно для фотогалерей).
- **Интерактивные элементы в приложении:** ползунок изменения ширины рамки контейнера (`Slider` от 200 до 620 px), позволяющий наблюдать перенос разноцветных блоков в реальном времени, а также переключатель ориентации переноса (`Horizontal` / `Vertical`).

```xml
<WrapPanel Orientation="Horizontal">
    <Border Width="110" Height="50" Background="{StaticResource PrimaryBrush}" Margin="4"/>
    <Border Width="120" Height="50" Background="{StaticResource AccentBrush}" Margin="4"/>
    <Border Width="95"  Height="50" Background="{StaticResource SuccessBrush}" Margin="4"/>
    <Border Width="115" Height="50" Background="{StaticResource InfoBrush}" Margin="4"/>
    <Border Width="105" Height="50" Background="{StaticResource ErrorBrush}" Margin="4"/>
</WrapPanel>
```

---

#### 4. `DockPanel` (Стыковочная панель)
- **Принцип работы:** прикрепляет дочерние элементы к сторонам света через прикрепленное свойство `DockPanel.Dock` (`Top`, `Bottom`, `Left`, `Right`).
- **Важность порядка объявления (Order Matters):** элементы стыкуются последовательно. Первый элемент с `Dock="Top"` занимает всю ширину окна сверху. Следующий элемент с `Dock="Left"` займет оставшуюся высоту между Top и нижним краем.
- **Свойство `LastChildFill`:** 
  - Если `LastChildFill="True"` (по умолчанию), последний дочерний элемент игнорирует значение своего свойства `Dock` и полностью заполняет всю оставшуюся центральную площадь.
  - Если `LastChildFill="False"`, последний элемент стыкуется к указанной стороне, оставляя центр пустым.
- **Интерактивные элементы в приложении:** чекбокс переключения `LastChildFill`, наглядное разделение на Top (Заголовок), Bottom (Статус-бар), Left (Навигация), Right (Свойства) и Center (Рабочая область).

```xml
<DockPanel LastChildFill="True">
    <Border DockPanel.Dock="Top" Height="44" Background="{StaticResource PrimaryBrush}"/>
    <Border DockPanel.Dock="Bottom" Height="38" Background="{StaticResource ErrorBrush}"/>
    <Border DockPanel.Dock="Left" Width="110" Background="{StaticResource AccentBrush}"/>
    <Border DockPanel.Dock="Right" Width="115" Background="{StaticResource InfoBrush}"/>
    <!-- Центральный элемент -->
    <Border Background="{StaticResource SuccessBrush}"/>
</DockPanel>
```

---

#### 5. `Canvas` (Абсолютное позиционирование)
- **Принцип работы:** позволяет явно задавать координаты элементов относительно левого верхнего или правого нижнего угла через прикрепленные свойства:
  - `Canvas.Left`, `Canvas.Top`, `Canvas.Right`, `Canvas.Bottom`.
- **Особенности Measure:** в отличие от других контейнеров, `Canvas` всегда возвращает `DesiredSize = (0, 0)` на этапе измерения (если явно не заданы `Width`/`Height`), так как он не подстраивается под размеры детей.
- **Порядок перекрытия (`Panel.ZIndex`):** задает порядок отрисовки слоев по оси Z. Элемент с большим значением `ZIndex` отрисовывается поверх элементов с меньшим значением.
- **Интерактивные элементы в приложении:** два ползунка (координата X от 10 до 320 px, координата Y от 10 до 160 px), перемещающие интерактивный акцентный блок с высоким `Panel.ZIndex="10"` над остальными статическими блоками по углам холста.
- **Сценарии применения:** векторные редакторы, игры, блок-схемы, рисование графиков, всплывающие подсказки поверх элементов. Не рекомендуется использовать для классических форм ввода из-за отсутствия адаптивности при изменении размера окна.

```xml
<Canvas ClipToBounds="True">
    <Border Canvas.Left="15" Canvas.Top="24" Width="130" Height="50" Background="{StaticResource PrimaryBrush}"/>
    <Border Canvas.Right="15" Canvas.Top="24" Width="130" Height="50" Background="{StaticResource InfoBrush}"/>
    <Border Canvas.Left="15" Canvas.Bottom="15" Width="130" Height="50" Background="{StaticResource SuccessBrush}"/>
    <!-- Интерактивный блок, перемещаемый ползунками -->
    <Border Canvas.Left="140" Canvas.Top="60" Panel.ZIndex="10" 
            Width="150" Height="65" Background="{StaticResource AccentBrush}"/>
</Canvas>
```

---

#### 6. `UniformGrid` (Равномерная сетка)
- **Принцип работы:** формирует регулярную матрицу ячеек, где абсолютно каждая ячейка имеет строго одинаковую ширину и высоту.
- **Отличие от `Grid`:** не требует ручного объявления коллекций `RowDefinitions` и `ColumnDefinitions`. Достаточно указать количество столбцов (`Columns`) и/или строк (`Rows`), и элементы будут автоматически последовательно распределены по ячейкам слева направо и сверху вниз.
- **Особенности Measure:** находит максимальный требуемый размер среди всех своих детей и резервирует ячейки под этот размер, умноженный на количество колонок и строк.
- **Интерактивные элементы в приложении:** радиокнопки динамического переключения числа колонок (2, 3, 4 или 6 столбцов), наглядно демонстрирующие мгновенную адаптацию и равное деление ширины между блоками.
- **Сценарии применения:** клавиатуры калькуляторов, шахматные доски, палитры плиток, панели инструментов с кнопками одинакового размера, календарные сетки.

```xml
<UniformGrid Columns="3">
    <Border Background="{StaticResource PrimaryBrush}" Margin="3"/>
    <Border Background="{StaticResource AccentBrush}" Margin="3"/>
    <Border Background="{StaticResource SuccessBrush}" Margin="3"/>
    <Border Background="{StaticResource InfoBrush}" Margin="3"/>
    <Border Background="{StaticResource ErrorBrush}" Margin="3"/>
    <Border Background="{StaticResource PrimaryHoverBrush}" Margin="3"/>
</UniformGrid>
```

---

#### Сводная сравнительная таблица контейнеров компоновки

| Контейнер | Назначение и поведение | Вычислительная сложность Measure/Arrange | Относительный / Абсолютный | Рекомендуемый сценарий |
| :--- | :--- | :--- | :--- | :--- |
| **`StackPanel`** | Линейное расположение элементов в стек вдоль вертикали или горизонтали | Низкая $O(N)$ | Относительный (поток) | Меню, панели кнопок, простые диалоговые формы |
| **`Grid`** | Гибкая сетка с произвольными строками и столбцами (Auto, *, px) | Средняя/Высокая $O(N \cdot M)$ | Относительный / Пропорциональный | Главная разметка окон, сложные формы ввода, дашборды |
| **`WrapPanel`** | Заполнение строки с автоматическим переносом на новую | Средняя $O(N)$ | Относительный (поток) | Галереи изображений, каталоги товаров, облако тегов |
| **`DockPanel`** | Причаливание элементов к границам окна с заполнением центра | Низкая/Средняя $O(N)$ | Относительный (периметр) | Каркас классического настольного приложения (меню, статус-бар, центр) |
| **`Canvas`** | Явное позиционирование элементов по координатам (X, Y) | Минимальная $O(1)$ | Абсолютный (координаты) | Векторные редакторы, игры, графы, диаграммы |
| **`UniformGrid`**| Регулярная матрица из ячеек строго одинакового размера | Низкая $O(N)$ | Относительный (равные доли) | Калькуляторы, календари, кнопочные панели одинакового размера |

---

## 3. Трудности, с которыми столкнулись в процессе работы

В ходе проектирования и реализации интерфейса на базе подсистемы WPF возник ряд нетривиальных инженерных и архитектурных задач:

### 3.1. Особенности двухпроходной модели компоновки (Measure/Arrange Cycle)
- **Проблема:** при размещении сложных динамических элементов внутри контейнеров, растягивающихся до бесконечности (`StackPanel` по главной оси передает дочерним элементам `availableSize.Height = PositiveInfinity`), некоторые вложенные компоненты (например, `ScrollViewer` или `DataGrid`) не могут корректно рассчитать свои размеры, что приводило к отключению виртуализации или попытке отрендерить миллионы пикселей в высоту.
- **Решение:** для таблиц и длинных списков было выполнено жесткое ограничение высоты (`MaxHeight`) либо перенос на внешний контейнер `Grid` со звездным размером строки `Height="1*"`, который передает строго ограниченный размер доступного прямоугольника.

### 3.2. Вложенные контейнеры прокрутки и обработка событий мыши
- **Проблема:** размещение элементов со встроенной прокруткой (`DataGrid`, `TreeView`, многострочные `TextBox`) внутри глобального `ScrollViewer` вкладки приводило к «перехвату» событий колеса мыши (`PreviewMouseWheel`), из-за чего прокрутка внешнего окна блокировалась, когда курсор находился над таблицей.
- **Решение:** в главном окне прокрутка была декомпозирована: глобальный `ScrollViewer` вынесен на уровень вкладок, а для элементов `DataGrid` и `TreeView` заданы фиксированные или ограниченные высоты с внутренней независимой прокруткой, исключающей застревание фокуса.

### 3.3. Разметка сложных табличных структур и объединение ячеек (`Span`)
- **Проблема:** в элементе `Grid` при использовании `ColumnSpan` и `RowSpan` в сочетании со строками размера `Auto` возникали визуальные артефакты: ячейка с объединением нескольких колонок могла неоправданно раздвигать первую попавшуюся колонку, искажая пропорции остальных.
- **Решение:** четкое разделение ответственности: для всех пропорциональных блоков использовались звездные веса (`1*`, `2*`), а фиксированные размеры задавались только базовым колонкам сайдбаров и футеров, что гарантировало стабильную геометрию при любом разрешении экрана.

### 3.4. Глубокая кастомизация стандартных элементов без сторонних библиотек
- **Проблема:** стандартные элементы Windows Presentation Foundation (кнопки, вкладки `TabItem`, экспандеры `Expander`) используют классический системный стиль Windows Vista/7 с градиентами, серыми рамками и синей подсветкой, что нарушало современный минималистичный темный стиль приложения.
- **Решение:** были написаны кастомные шаблоны управления (`ControlTemplate`) с использованием триггеров состояний (`IsMouseOver`, `IsPressed`, `IsSelected`, `IsEnabled`). В шаблоне экспандера стандартная системная стрелка была заменена на плавную векторную пиктограмму `Path`, реагирующую на свойство `IsExpanded`.

### 3.5. Специфика синтаксиса расширений разметки XAML (Markup Extensions)
- **Проблема:** при описании форматированного вывода координат через расширение разметки `{Binding ... StringFormat=...}` парсер XAML генерировал синтаксическую ошибку `MC3042: пары имен и значений в MarkupExtensions должны иметь формат "Имя = Значение", и каждая пара отделяется запятой`, так как запятая внутри формата строки воспринималась парсером как разделитель аргументов расширения.
- **Решение:** вместо сложной перегрузки строкового формата в едином выражении была применена декомпозиция на несколько компактных элементов `TextBlock` в горизонтальном `StackPanel`, либо использование экранирования `{}` (`StringFormat={}{0:0}`), что сделало разметку понятной, надежной и устойчивой к изменениям.

### 3.6. Архитектура обновления интерфейса (Data Binding и `INotifyPropertyChanged`)
- **Проблема:** при изменении свойств элементов (выбранный узел в `TreeView`, активная строка в `DataGrid`, положение интерактивных ползунков) требовалось мгновенное обновление сопутствующих информационных карточек без ручного обращения к контролам из кода.
- **Решение:** модели данных были спроектированы с поддержкой интерфейса `INotifyPropertyChanged` и использованием атрибута `[CallerMemberName]`. Для коллекций использован класс `ObservableCollection<T>`, автоматически уведомляющий подсистему WPF о добавлении, удалении и изменении элементов списка.

---

## 4. Вывод

В ходе выполнения лабораторной работы были всесторонне исследованы базовые элементы подсистемы Windows Presentation Foundation (WPF), принципы декларативного построения графического интерфейса на языке XAML, организация централизованных словарей ресурсов и механизмы двусторонней привязки данных (Data Binding).

**Основные практические результаты:**
1. Разработано архитектурно выверенное многооконное приложение на базе платформы .NET 8.0, удовлетворяющее всем требованиям технического задания.
2. Реализована современная темная дизайн-система с пятицветной фирменной палитрой (`Primary`, `Accent`, `Success`, `Error`, `Info`) и математической таблицей из 50 оттенков.
3. Полностью исследованы и практически представлены все основные элементы управления подсистемы WPF: кнопки всех типов, однострочные и многострочные текстовые поля, защищенный ввод паролей, форматированный документ `RichTextBox`, иерархическое дерево `TreeView` со сложным шаблоном данных, таблица `DataGrid`, детерминированные и пульсирующие прогресс-бары, расширенные подсказки `ToolTip`, главное меню и контекстное меню.
4. На специализированной вкладке наглядно продемонстрированы алгоритмические различия и поведение шести ключевых контейнеров компоновки (`StackPanel`, `Grid`, `WrapPanel`, `DockPanel`, `Canvas`, `UniformGrid`). На практических интерактивных примерах изучена двухпроходная модель расчета геометрии элементов `Measure` и `Arrange`.
5. Проект успешно собирается и функционирует без ошибок и предупреждений компилятора (`dotnet build`), подтверждая чистоту кодовой базы и строгое соответствие архитектурным стандартам разработки подсистемы WPF.
