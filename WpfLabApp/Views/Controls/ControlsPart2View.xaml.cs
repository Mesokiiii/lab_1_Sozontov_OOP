using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using WpfLabApp.Models;

namespace WpfLabApp.Views
{
    public partial class ControlsPart2View : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<ProjectTreeNode> _projectNodes = new();
        private ObservableCollection<DataGridSampleItem> _dataItems = new();
        private string _lastActionText = "Готово к взаимодействию";
        private string _selectedTreeItemText = "WpfLabApp (Решение) — Корневой проект .NET 8";
        private string _selectedDataGridItemText = "Выберите строку в таблице выше для просмотра подробной информации";
        private double _progressValue = 75.0;
        private bool _isIndeterminateRunning = true;

        public ObservableCollection<ProjectTreeNode> ProjectNodes
        {
            get => _projectNodes;
            set
            {
                _projectNodes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DataGridSampleItem> DataItems
        {
            get => _dataItems;
            set
            {
                _dataItems = value;
                OnPropertyChanged();
            }
        }

        public string LastActionText
        {
            get => _lastActionText;
            set
            {
                _lastActionText = value;
                OnPropertyChanged();
            }
        }

        public string SelectedTreeItemText
        {
            get => _selectedTreeItemText;
            set
            {
                _selectedTreeItemText = value;
                OnPropertyChanged();
            }
        }

        public string SelectedDataGridItemText
        {
            get => _selectedDataGridItemText;
            set
            {
                _selectedDataGridItemText = value;
                OnPropertyChanged();
            }
        }

        public double ProgressValue
        {
            get => _progressValue;
            set
            {
                _progressValue = Math.Clamp(value, 0, 100);
                OnPropertyChanged();
            }
        }

        public bool IsIndeterminateRunning
        {
            get => _isIndeterminateRunning;
            set
            {
                _isIndeterminateRunning = value;
                OnPropertyChanged();
            }
        }

        public ControlsPart2View()
        {
            InitializeComponent();
            DataContext = this;

            LoadData();
        }

        private void LoadData()
        {
            ProjectNodes = ProjectTreeNode.GetSampleProjectStructure();
            DataItems = DataGridSampleItem.GetSampleItems();
        }

        #region TreeView Handlers

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is ProjectTreeNode node)
            {
                SelectedTreeItemText = $"{node.Icon} {node.Name} — {node.Info} ({node.NodeType})";
                LastActionText = $"Выбран узел дерева: '{node.Name}' ({DateTime.Now:HH:mm:ss})";
            }
        }

        private void ExpandAllNodes_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectNodes != null)
            {
                SetExpansionRecursively(ProjectNodes, true);
            }
            LastActionText = $"Развернуты все ветки дерева проекта ({DateTime.Now:HH:mm:ss})";
        }

        private void CollapseAllNodes_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectNodes != null)
            {
                SetExpansionRecursively(ProjectNodes, false);
                // Оставляем корень развернутым для удобства
                if (ProjectNodes.Count > 0 && ProjectNodes[0] != null)
                {
                    ProjectNodes[0].IsExpanded = true;
                }
            }
            LastActionText = $"Свернуты ветки дерева проекта ({DateTime.Now:HH:mm:ss})";
        }

        private void SetExpansionRecursively(ObservableCollection<ProjectTreeNode>? nodes, bool isExpanded)
        {
            if (nodes == null) return;
            foreach (var node in nodes)
            {
                if (node == null) continue;
                node.IsExpanded = isExpanded;
                if (node.Children != null && node.Children.Count > 0)
                {
                    SetExpansionRecursively(node.Children, isExpanded);
                }
            }
        }

        private void TreeNodeExpand_Click(object sender, RoutedEventArgs e)
        {
            var node = (sender as FrameworkElement)?.DataContext as ProjectTreeNode ?? MainTreeView?.SelectedItem as ProjectTreeNode;
            if (node != null)
            {
                node.IsExpanded = true;
                LastActionText = $"Развернут узел: '{node.Name}' ({DateTime.Now:HH:mm:ss})";
            }
        }

        private void TreeNodeCollapse_Click(object sender, RoutedEventArgs e)
        {
            var node = (sender as FrameworkElement)?.DataContext as ProjectTreeNode ?? MainTreeView?.SelectedItem as ProjectTreeNode;
            if (node != null)
            {
                node.IsExpanded = false;
                LastActionText = $"Свернут узел: '{node.Name}' ({DateTime.Now:HH:mm:ss})";
            }
        }

        private void TreeNodeCopyName_Click(object sender, RoutedEventArgs e)
        {
            var node = (sender as FrameworkElement)?.DataContext as ProjectTreeNode ?? MainTreeView?.SelectedItem as ProjectTreeNode;
            if (node != null)
            {
                try
                {
                    Clipboard.SetText(node.Name);
                    LastActionText = $"Скопировано имя узла: '{node.Name}' ({DateTime.Now:HH:mm:ss})";
                }
                catch
                {
                    LastActionText = $"Имя узла: '{node.Name}' ({DateTime.Now:HH:mm:ss})";
                }
            }
        }

        #endregion

        #region DataGrid Handlers

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DataGrid dg && dg.SelectedItem is DataGridSampleItem item)
            {
                SelectedDataGridItemText = $"[#{item.Id}] {item.Name} | Категория: {item.Category} | Статус: {item.Status} | Активен: {(item.IsActive ? "Да" : "Нет")}";
                LastActionText = $"Выбрана строка DataGrid: ID {item.Id} - {item.Name} ({DateTime.Now:HH:mm:ss})";
            }
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            if (DataItems == null)
            {
                DataItems = new ObservableCollection<DataGridSampleItem>();
            }

            int nextId = DataItems.Count > 0 ? DataItems.Max(i => i.Id) + 1 : 101;
            var newItem = new DataGridSampleItem
            {
                Id = nextId,
                Name = $"Новая задача службы аналитики #{nextId}",
                Category = "Очередь обработки",
                Status = "В обработке",
                StatusType = StatusCategory.Info,
                Date = DateTime.Now,
                IsActive = true
            };
            DataItems.Add(newItem);
            LastActionText = $"Добавлена новая запись в DataGrid: ID {nextId} ({DateTime.Now:HH:mm:ss})";
        }

        private void ResetRows_Click(object sender, RoutedEventArgs e)
        {
            DataItems = DataGridSampleItem.GetSampleItems();
            SelectedDataGridItemText = "Таблица сброшена к начальным 8 демонстрационным строкам";
            LastActionText = $"Таблица DataGrid сброшена к исходным данным ({DateTime.Now:HH:mm:ss})";
        }

        private void DataGridRowCopy_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement)?.DataContext as DataGridSampleItem ?? DemoDataGrid?.SelectedItem as DataGridSampleItem;
            if (item != null)
            {
                try
                {
                    Clipboard.SetText($"#{item.Id} {item.Name} [{item.Category}] - {item.Status}");
                    LastActionText = $"Скопированы данные записи #{item.Id} ({DateTime.Now:HH:mm:ss})";
                }
                catch
                {
                    LastActionText = $"Выбрана запись #{item.Id}: '{item.Name}' ({DateTime.Now:HH:mm:ss})";
                }
            }
        }

        private void DataGridRowToggleActive_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement)?.DataContext as DataGridSampleItem ?? DemoDataGrid?.SelectedItem as DataGridSampleItem;
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                LastActionText = $"Изменен статус активности записи #{item.Id} на: {(item.IsActive ? "Активен" : "Неактивен")} ({DateTime.Now:HH:mm:ss})";
            }
        }

        private void DataGridRowDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement)?.DataContext as DataGridSampleItem ?? DemoDataGrid?.SelectedItem as DataGridSampleItem;
            if (item != null)
            {
                DataItems.Remove(item);
                SelectedDataGridItemText = $"Запись #{item.Id} успешно удалена из таблицы";
                LastActionText = $"Удалена запись ID {item.Id} - '{item.Name}' ({DateTime.Now:HH:mm:ss})";
            }
        }

        #endregion

        #region ProgressBar Handlers

        private void SetProgress_0_Click(object sender, RoutedEventArgs e) => ProgressValue = 0;
        private void SetProgress_Minus10_Click(object sender, RoutedEventArgs e) => ProgressValue = Math.Max(0, ProgressValue - 10);
        private void SetProgress_Plus10_Click(object sender, RoutedEventArgs e) => ProgressValue = Math.Min(100, ProgressValue + 10);
        private void SetProgress_100_Click(object sender, RoutedEventArgs e) => ProgressValue = 100;

        #endregion

        #region Menu & ContextMenu Handlers

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                string header = menuItem.Header?.ToString() ?? "Элемент меню";
                string gesture = string.IsNullOrEmpty(menuItem.InputGestureText) ? "" : $" [{menuItem.InputGestureText}]";
                LastActionText = $"Выполнен пункт меню: '{header}'{gesture} в {DateTime.Now:HH:mm:ss}";
            }
        }

        private void ContextMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem menuItem)
            {
                string action = menuItem.Header?.ToString() ?? "Действие";
                LastActionText = $"Вызвано действие ContextMenu: '{action}' в {DateTime.Now:HH:mm:ss}";
            }
        }

        private void Card_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            LastActionText = $"Открыто контекстное меню на демонстрационной карточке ({DateTime.Now:HH:mm:ss})";
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
