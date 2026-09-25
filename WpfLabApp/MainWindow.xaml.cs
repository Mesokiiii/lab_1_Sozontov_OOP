using System;
using System.IO;
using System.Windows;

namespace WpfLabApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_run.log");
        File.AppendAllText(logPath, "[MainWindow.ctor] Starting InitializeComponent()...\n");
        try
        {
            InitializeComponent();
            File.AppendAllText(logPath, "[MainWindow.ctor] InitializeComponent() completed.\n");
        }
        catch (Exception ex)
        {
            File.AppendAllText(logPath, $"[MainWindow.ctor Exception] {ex.Message}\n{ex.StackTrace}\n");
            throw;
        }

        Loaded += (s, e) =>
        {
            var helper = new System.Windows.Interop.WindowInteropHelper(this);
            File.AppendAllText(logPath, $"[MainWindow] Loaded! HWND=0x{helper.Handle:X}, State={WindowState}, Vis={Visibility}, Bounds={Left},{Top},{Width},{Height}\n");
            try
            {
                Topmost = true;
                Activate();
                Focus();
                Topmost = false;
            }
            catch { }
        };

        Closed += (s, e) =>
        {
            File.AppendAllText(logPath, "[MainWindow] Closed event fired.\n");
        };
    }
}