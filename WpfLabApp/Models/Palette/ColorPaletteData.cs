using System.Collections.Generic;

namespace WpfLabApp.Models
{
    public static class ColorPaletteData
    {
        public const string CurrentThemeName = "Современная тёмная палитра (Modern Slate & Violet Accent)";
        public const string ThemeDescription = "Сбалансированная высококонтрастная тёмная дизайн-система на базе палитр Slate и Material/Tailwind с 10 градуированными оттенками на каждую цветовую категорию.";

        public static ColorGroup GetPrimaryGroup() => new ColorGroup
        {
            GroupName = "Основной цвет (Primary)",
            EnglishName = "Primary Blue",
            BaseHex = "#3B82F6",
            BaseRgb = "rgb(59, 130, 246)",
            Subtitle = "Синий Royal",
            Role = "Основной цвет интерфейса: активные вкладки, главные кнопки (CTA), фокус ввода и выделения",
            AccentBorderHex = "#3B82F6",
            Shades = new List<ColorItem>
            {
                new ColorItem { Shade = "50", Name = "Primary 50", HexCode = "#EFF6FF", RgbCode = "rgb(239, 246, 255)", R = 239, G = 246, B = 255, TextColorHex = "#0F172A", Category = "Primary", Description = "Сверхсветлый фон, подсветка строк таблицы при наведении" },
                new ColorItem { Shade = "100", Name = "Primary 100", HexCode = "#DBEAFE", RgbCode = "rgb(219, 234, 254)", R = 219, G = 234, B = 254, TextColorHex = "#0F172A", Category = "Primary", Description = "Фон выделенных элементов в светлых контейнерах, мягкие бейджи" },
                new ColorItem { Shade = "200", Name = "Primary 200", HexCode = "#BFDBFE", RgbCode = "rgb(191, 219, 254)", R = 191, G = 219, B = 254, TextColorHex = "#0F172A", Category = "Primary", Description = "Вспомогательные границы и разделители активных секций" },
                new ColorItem { Shade = "300", Name = "Primary 300", HexCode = "#93C5FD", RgbCode = "rgb(147, 197, 253)", R = 147, G = 197, B = 253, TextColorHex = "#0F172A", Category = "Primary", Description = "Светлые синие иконки, индикаторы состояния hover" },
                new ColorItem { Shade = "400", Name = "Primary 400", HexCode = "#60A5FA", RgbCode = "rgb(96, 165, 250)", R = 96, G = 165, B = 250, TextColorHex = "#0F172A", Category = "Primary", Description = "Рамка фокуса ввода в тёмной теме, вторичные кнопки" },
                new ColorItem { Shade = "500", Name = "Primary 500 (Базовый)", HexCode = "#3B82F6", RgbCode = "rgb(59, 130, 246)", R = 59, G = 130, B = 246, TextColorHex = "#FFFFFF", Category = "Primary", IsBaseColor = true, Description = "Ключевой брендовый цвет приложения (активные кнопки, выделение)" },
                new ColorItem { Shade = "600", Name = "Primary 600", HexCode = "#2563EB", RgbCode = "rgb(37, 99, 235)", R = 37, G = 99, B = 235, TextColorHex = "#FFFFFF", Category = "Primary", Description = "Состояние наведения (hover) для основных кнопок и вкладок" },
                new ColorItem { Shade = "700", Name = "Primary 700", HexCode = "#1D4ED8", RgbCode = "rgb(29, 78, 216)", R = 29, G = 78, B = 216, TextColorHex = "#FFFFFF", Category = "Primary", Description = "Состояние нажатия (pressed / active) основных элементов" },
                new ColorItem { Shade = "800", Name = "Primary 800", HexCode = "#1E40AF", RgbCode = "rgb(30, 64, 175)", R = 30, G = 64, B = 175, TextColorHex = "#FFFFFF", Category = "Primary", Description = "Глубокие подложки контейнеров и карточек в тёмном режиме" },
                new ColorItem { Shade = "900", Name = "Primary 900", HexCode = "#1E3A8A", RgbCode = "rgb(30, 58, 138)", R = 30, G = 58, B = 138, TextColorHex = "#FFFFFF", Category = "Primary", Description = "Тёмно-синий фон панелей навигации и акцентных блоков" }
            }
        };

        public static ColorGroup GetAccentGroup() => new ColorGroup
        {
            GroupName = "Акцентный цвет (Accent)",
            EnglishName = "Accent Violet",
            BaseHex = "#8B5CF6",
            BaseRgb = "rgb(139, 92, 246)",
            Subtitle = "Фиолетовый Indigo/Violet",
            Role = "Акцентный цвет: второстепенные интерактивные элементы, бейджи, теги и декоративные градиенты",
            AccentBorderHex = "#8B5CF6",
            Shades = new List<ColorItem>
            {
                new ColorItem { Shade = "50", Name = "Accent 50", HexCode = "#F5F3FF", RgbCode = "rgb(245, 243, 255)", R = 245, G = 243, B = 255, TextColorHex = "#0F172A", Category = "Accent", Description = "Сверхсветлое фиолетовое свечение, фон подсказок" },
                new ColorItem { Shade = "100", Name = "Accent 100", HexCode = "#EDE9FE", RgbCode = "rgb(237, 233, 254)", R = 237, G = 233, B = 254, TextColorHex = "#0F172A", Category = "Accent", Description = "Подложка информационных тегов и чипов фиолетовой группы" },
                new ColorItem { Shade = "200", Name = "Accent 200", HexCode = "#DDD6FE", RgbCode = "rgb(221, 214, 254)", R = 221, G = 214, B = 254, TextColorHex = "#0F172A", Category = "Accent", Description = "Границы и разделители акцентных карточек" },
                new ColorItem { Shade = "300", Name = "Accent 300", HexCode = "#C4B5FD", RgbCode = "rgb(196, 181, 253)", R = 196, G = 181, B = 253, TextColorHex = "#0F172A", Category = "Accent", Description = "Вспомогательный акцентный текст, иконки в темной теме" },
                new ColorItem { Shade = "400", Name = "Accent 400", HexCode = "#A78BFA", RgbCode = "rgb(167, 139, 250)", R = 167, G = 139, B = 250, TextColorHex = "#0F172A", Category = "Accent", Description = "Иконки и переключатели в тёмной теме, легкие акценты" },
                new ColorItem { Shade = "500", Name = "Accent 500 (Базовый)", HexCode = "#8B5CF6", RgbCode = "rgb(139, 92, 246)", R = 139, G = 92, B = 246, TextColorHex = "#FFFFFF", Category = "Accent", IsBaseColor = true, Description = "Ключевой акцентный цвет (второстепенные кнопки, чипы)" },
                new ColorItem { Shade = "600", Name = "Accent 600", HexCode = "#7C3AED", RgbCode = "rgb(124, 58, 237)", R = 124, G = 58, B = 237, TextColorHex = "#FFFFFF", Category = "Accent", Description = "Состояние наведения (hover) для акцентных кнопок" },
                new ColorItem { Shade = "700", Name = "Accent 700", HexCode = "#6D28D9", RgbCode = "rgb(109, 40, 217)", R = 109, G = 40, B = 217, TextColorHex = "#FFFFFF", Category = "Accent", Description = "Состояние нажатия (pressed) акцентных элементов" },
                new ColorItem { Shade = "800", Name = "Accent 800", HexCode = "#5B21B6", RgbCode = "rgb(91, 33, 182)", R = 91, G = 33, B = 182, TextColorHex = "#FFFFFF", Category = "Accent", Description = "Тёмный акцентный фон баннеров и карточек" },
                new ColorItem { Shade = "900", Name = "Accent 900", HexCode = "#4C1D95", RgbCode = "rgb(76, 29, 149)", R = 76, G = 29, B = 149, TextColorHex = "#FFFFFF", Category = "Accent", Description = "Глубокая фиолетовая подложка с максимальным контрастом" }
            }
        };

        public static ColorGroup GetSuccessGroup() => new ColorGroup
        {
            GroupName = "Успех (Success)",
            EnglishName = "Indicator Success",
            BaseHex = "#10B981",
            BaseRgb = "rgb(16, 185, 129)",
            Subtitle = "Изумрудный Green",
            Role = "Индикатор успешных действий: подтверждение операций, валидный ввод, успешный статус",
            AccentBorderHex = "#10B981",
            Shades = new List<ColorItem>
            {
                new ColorItem { Shade = "50", Name = "Success 50", HexCode = "#ECFDF5", RgbCode = "rgb(236, 253, 245)", R = 236, G = 253, B = 245, TextColorHex = "#0F172A", Category = "Success", Description = "Фон оповещений об успешном завершении операции" },
                new ColorItem { Shade = "100", Name = "Success 100", HexCode = "#D1FAE5", RgbCode = "rgb(209, 250, 229)", R = 209, G = 250, B = 229, TextColorHex = "#0F172A", Category = "Success", Description = "Подложка бейджей 'Готово / Успешно' в интерфейсе" },
                new ColorItem { Shade = "200", Name = "Success 200", HexCode = "#A7F3D0", RgbCode = "rgb(167, 243, 208)", R = 167, G = 243, B = 208, TextColorHex = "#0F172A", Category = "Success", Description = "Граница карточек успешного завершения" },
                new ColorItem { Shade = "300", Name = "Success 300", HexCode = "#6EE7B7", RgbCode = "rgb(110, 231, 183)", R = 110, G = 231, B = 183, TextColorHex = "#0F172A", Category = "Success", Description = "Индикатор заполнения полосы прогресса (светлая фаза)" },
                new ColorItem { Shade = "400", Name = "Success 400", HexCode = "#34D399", RgbCode = "rgb(52, 211, 153)", R = 52, G = 211, B = 153, TextColorHex = "#0F172A", Category = "Success", Description = "Иконки валидности и успеха на тёмном фоне" },
                new ColorItem { Shade = "500", Name = "Success 500 (Базовый)", HexCode = "#10B981", RgbCode = "rgb(16, 185, 129)", R = 16, G = 185, B = 129, TextColorHex = "#FFFFFF", Category = "Success", IsBaseColor = true, Description = "Ключевой индикатор успеха и валидности в приложении" },
                new ColorItem { Shade = "600", Name = "Success 600", HexCode = "#059669", RgbCode = "rgb(5, 150, 105)", R = 5, G = 150, B = 105, TextColorHex = "#FFFFFF", Category = "Success", Description = "Наведение (hover) на кнопки подтверждения и согласия" },
                new ColorItem { Shade = "700", Name = "Success 700", HexCode = "#047857", RgbCode = "rgb(4, 120, 87)", R = 4, G = 120, B = 87, TextColorHex = "#FFFFFF", Category = "Success", Description = "Нажатие (pressed) на кнопки подтверждения" },
                new ColorItem { Shade = "800", Name = "Success 800", HexCode = "#065F46", RgbCode = "rgb(6, 95, 70)", R = 6, G = 95, B = 70, TextColorHex = "#FFFFFF", Category = "Success", Description = "Тёмный фон плашек успешного выполнения" },
                new ColorItem { Shade = "900", Name = "Success 900", HexCode = "#064E3B", RgbCode = "rgb(6, 78, 59)", R = 6, G = 78, B = 59, TextColorHex = "#FFFFFF", Category = "Success", Description = "Глубокая изумрудная рамка для карточек статуса" }
            }
        };

        public static ColorGroup GetErrorGroup() => new ColorGroup
        {
            GroupName = "Ошибка (Error)",
            EnglishName = "Indicator Error",
            BaseHex = "#EF4444",
            BaseRgb = "rgb(239, 68, 68)",
            Subtitle = "Красный Rose",
            Role = "Индикатор ошибок: некорректный ввод данных, сбои, деструктивные действия (удаление/отмена)",
            AccentBorderHex = "#EF4444",
            Shades = new List<ColorItem>
            {
                new ColorItem { Shade = "50", Name = "Error 50", HexCode = "#FEF2F2", RgbCode = "rgb(254, 242, 242)", R = 254, G = 242, B = 242, TextColorHex = "#0F172A", Category = "Error", Description = "Фон критических алертов и сообщений об ошибках" },
                new ColorItem { Shade = "100", Name = "Error 100", HexCode = "#FEE2E2", RgbCode = "rgb(254, 226, 226)", R = 254, G = 226, B = 226, TextColorHex = "#0F172A", Category = "Error", Description = "Подложка бейджей ошибок валидации формы" },
                new ColorItem { Shade = "200", Name = "Error 200", HexCode = "#FECACA", RgbCode = "rgb(254, 202, 202)", R = 254, G = 202, B = 202, TextColorHex = "#0F172A", Category = "Error", Description = "Рамка некорректно заполненных текстовых полей" },
                new ColorItem { Shade = "300", Name = "Error 300", HexCode = "#FCA5A5", RgbCode = "rgb(252, 165, 165)", R = 252, G = 165, B = 165, TextColorHex = "#0F172A", Category = "Error", Description = "Текст ошибок в светлой теме, вторичные иконки" },
                new ColorItem { Shade = "400", Name = "Error 400", HexCode = "#F87171", RgbCode = "rgb(248, 113, 113)", R = 248, G = 113, B = 113, TextColorHex = "#0F172A", Category = "Error", Description = "Текст ошибок валидации на тёмном фоне интерфейса" },
                new ColorItem { Shade = "500", Name = "Error 500 (Базовый)", HexCode = "#EF4444", RgbCode = "rgb(239, 68, 68)", R = 239, G = 68, B = 68, TextColorHex = "#FFFFFF", Category = "Error", IsBaseColor = true, Description = "Ключевой индикатор ошибок и опасных действий (кнопка 'Удалить')" },
                new ColorItem { Shade = "600", Name = "Error 600", HexCode = "#DC2626", RgbCode = "rgb(220, 38, 38)", R = 220, G = 38, B = 38, TextColorHex = "#FFFFFF", Category = "Error", Description = "Наведение (hover) на деструктивные кнопки" },
                new ColorItem { Shade = "700", Name = "Error 700", HexCode = "#B91C1C", RgbCode = "rgb(185, 28, 28)", R = 185, G = 28, B = 28, TextColorHex = "#FFFFFF", Category = "Error", Description = "Нажатие (pressed) деструктивных кнопок" },
                new ColorItem { Shade = "800", Name = "Error 800", HexCode = "#991B1B", RgbCode = "rgb(153, 27, 27)", R = 153, G = 27, B = 27, TextColorHex = "#FFFFFF", Category = "Error", Description = "Тёмный фон диалогов подтверждения удаления" },
                new ColorItem { Shade = "900", Name = "Error 900", HexCode = "#7F1D1D", RgbCode = "rgb(127, 29, 29)", R = 127, G = 29, B = 29, TextColorHex = "#FFFFFF", Category = "Error", Description = "Глубокая красная подложка аварийных предупреждений" }
            }
        };

        public static ColorGroup GetInfoGroup() => new ColorGroup
        {
            GroupName = "Информация (Info)",
            EnglishName = "Indicator Info",
            BaseHex = "#06B6D4",
            BaseRgb = "rgb(6, 182, 212)",
            Subtitle = "Голубой Cyan",
            Role = "Информационный индикатор: подсказки, справочная информация, системные уведомления",
            AccentBorderHex = "#06B6D4",
            Shades = new List<ColorItem>
            {
                new ColorItem { Shade = "50", Name = "Info 50", HexCode = "#ECFEFF", RgbCode = "rgb(236, 254, 255)", R = 236, G = 254, B = 255, TextColorHex = "#0F172A", Category = "Info", Description = "Фон справочных баннеров и обучающих карточек" },
                new ColorItem { Shade = "100", Name = "Info 100", HexCode = "#CFFAFE", RgbCode = "rgb(207, 250, 254)", R = 207, G = 250, B = 254, TextColorHex = "#0F172A", Category = "Info", Description = "Подложка информационных бейджей и тегов версии" },
                new ColorItem { Shade = "200", Name = "Info 200", HexCode = "#A5F3FC", RgbCode = "rgb(165, 243, 252)", R = 165, G = 243, B = 252, TextColorHex = "#0F172A", Category = "Info", Description = "Граница информационных диалоговых панелей" },
                new ColorItem { Shade = "300", Name = "Info 300", HexCode = "#67E8F9", RgbCode = "rgb(103, 232, 249)", R = 103, G = 232, B = 249, TextColorHex = "#0F172A", Category = "Info", Description = "Светлые бирюзовые иконки справки и помощи" },
                new ColorItem { Shade = "400", Name = "Info 400", HexCode = "#22D3EE", RgbCode = "rgb(34, 211, 238)", R = 34, G = 211, B = 238, TextColorHex = "#0F172A", Category = "Info", Description = "Информационный текст ссылок и сносок в тёмной теме" },
                new ColorItem { Shade = "500", Name = "Info 500 (Базовый)", HexCode = "#06B6D4", RgbCode = "rgb(6, 182, 212)", R = 6, G = 182, B = 212, TextColorHex = "#FFFFFF", Category = "Info", IsBaseColor = true, Description = "Ключевой информационный цвет в системе уведомлений" },
                new ColorItem { Shade = "600", Name = "Info 600", HexCode = "#0891B2", RgbCode = "rgb(8, 145, 178)", R = 8, G = 145, B = 178, TextColorHex = "#FFFFFF", Category = "Info", Description = "Наведение (hover) на информационные кнопки и ссылки" },
                new ColorItem { Shade = "700", Name = "Info 700", HexCode = "#0E7490", RgbCode = "rgb(14, 116, 144)", R = 14, G = 116, B = 144, TextColorHex = "#FFFFFF", Category = "Info", Description = "Нажатие (pressed) на информационные элементы" },
                new ColorItem { Shade = "800", Name = "Info 800", HexCode = "#155E75", RgbCode = "rgb(21, 94, 117)", R = 21, G = 94, B = 117, TextColorHex = "#FFFFFF", Category = "Info", Description = "Тёмный фон тултипов и всплывающих подсказок" },
                new ColorItem { Shade = "900", Name = "Info 900", HexCode = "#164E63", RgbCode = "rgb(22, 78, 99)", R = 22, G = 78, B = 99, TextColorHex = "#FFFFFF", Category = "Info", Description = "Глубокая бирюзовая подложка статусных панелей" }
            }
        };

        public static List<ColorGroup> GetAllGroups() => new List<ColorGroup>
        {
            GetPrimaryGroup(),
            GetAccentGroup(),
            GetSuccessGroup(),
            GetErrorGroup(),
            GetInfoGroup()
        };
    }
}
