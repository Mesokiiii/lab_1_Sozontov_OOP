using System.Collections.ObjectModel;
using WpfLabApp.Common;
using WpfLabApp.Models;
using WpfLabApp.Services.Implementations;

namespace WpfLabApp.ViewModels;

/// <summary>
/// Модель представления вкладки «1.3. Элементы управления» (ТЗ 1.3).
/// Управляет данными TreeView, DataGrid, ProgressBar и журналом событий.
/// </summary>
public class ControlsViewModel : ObservableObject
{
    private string _eventLog = "Готово • Выполните действие в меню, таблице или дереве для фиксации события";
    private double _progressValue = 75;
    private bool _isIndeterminateActive = true;
    private ProjectTreeNode? _selectedNode;
    private DataGridSampleItem? _selectedItem;

    public ObservableCollection<ProjectTreeNode> ProjectNodes { get; }
    public ObservableCollection<DataGridSampleItem> DataItems { get; }

    public string EventLog
    {
        get => _eventLog;
        set => SetProperty(ref _eventLog, value);
    }

    public double ProgressValue
    {
        get => _progressValue;
        set => SetProperty(ref _progressValue, Math.Clamp(value, 0, 100));
    }

    public bool IsIndeterminateActive
    {
        get => _isIndeterminateActive;
        set => SetProperty(ref _isIndeterminateActive, value);
    }

    public ProjectTreeNode? SelectedNode
    {
        get => _selectedNode;
        set
        {
            if (SetProperty(ref _selectedNode, value) && value != null)
            {
                LogEvent($"Выбран узел дерева: {value.Name} ({value.NodeType})");
            }
        }
    }

    public DataGridSampleItem? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (SetProperty(ref _selectedItem, value) && value != null)
            {
                LogEvent($"Выбрана строка таблицы: #{value.Id} {value.Name} [{value.Status}]");
            }
        }
    }

    public RelayCommand AddRowCommand { get; }
    public RelayCommand ResetRowsCommand { get; }
    public RelayCommand ExpandAllTreeCommand { get; }
    public RelayCommand CollapseAllTreeCommand { get; }
    public RelayCommand<double> SetProgressCommand { get; }

    public ControlsViewModel()
    {
        ProjectNodes = ProjectTreeNode.GetSampleProjectStructure();
        DataItems = DataGridSampleItem.GetSampleItems();

        AddRowCommand = new RelayCommand(AddNewItem);
        ResetRowsCommand = new RelayCommand(ResetItems);
        ExpandAllTreeCommand = new RelayCommand(() => SetTreeExpansion(true));
        CollapseAllTreeCommand = new RelayCommand(() => SetTreeExpansion(false));
        SetProgressCommand = new RelayCommand<double>(val => ProgressValue = val);
    }

    public void LogEvent(string action)
    {
        EventLog = $"[{DateTime.Now:HH:mm:ss}] {action}";
    }

    private void AddNewItem()
    {
        int nextId = DataItems.Count > 0 ? DataItems.Max(i => i.Id) + 1 : 1;
        var newItem = new DataGridSampleItem
        {
            Id = nextId,
            Name = $"Новый сервис #{nextId}",
            Category = "Микросервисы",
            Date = DateTime.Now,
            StatusType = StatusCategory.Success,
            Status = "Активен",
            IsActive = true
        };
        DataItems.Add(newItem);
        SelectedItem = newItem;
        LogEvent($"Добавлена новая запись #{newItem.Id}: {newItem.Name}");
    }

    private void ResetItems()
    {
        DataItems.Clear();
        foreach (var item in DataGridSampleItem.GetSampleItems())
        {
            DataItems.Add(item);
        }
        SelectedItem = DataItems.FirstOrDefault();
        LogEvent("Таблица DataGrid сброшена к исходным демонстрационным записям");
    }

    private void SetTreeExpansion(bool expand)
    {
        void Recurse(IEnumerable<ProjectTreeNode> nodes)
        {
            foreach (var node in nodes)
            {
                node.IsExpanded = expand;
                if (node.Children != null && node.Children.Count > 0)
                {
                    Recurse(node.Children);
                }
            }
        }

        Recurse(ProjectNodes);
        if (!expand && ProjectNodes.Count > 0)
        {
            ProjectNodes[0].IsExpanded = true;
        }

        LogEvent(expand ? "Все узлы дерева развернуты" : "Все вложенные ветки дерева свернуты");
    }
}
