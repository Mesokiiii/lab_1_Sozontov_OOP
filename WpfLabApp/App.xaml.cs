using System;
using System.IO;
using System.Windows;

namespace WpfLabApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_run.log");
        File.WriteAllText(logPath, $"[OnStartup] App started at {DateTime.Now}\n");

        AppDomain.CurrentDomain.UnhandledException += (s, args) =>
        {
            File.AppendAllText(logPath, $"[AppDomain UnhandledException] {args.ExceptionObject}\n");
        };

        DispatcherUnhandledException += (s, args) =>
        {
            File.AppendAllText(logPath, $"[DispatcherUnhandledException] {args.Exception}\n");
        };

        if (System.Linq.Enumerable.Contains(e.Args, "--export-screenshots"))
        {
            ScreenshotExporter.ExportAll();
            Shutdown();
            return;
        }

        base.OnStartup(e);

        try
        {
            File.AppendAllText(logPath, "[OnStartup] Instantiating MainWindow...\n");
            var mainWindow = new MainWindow();
            MainWindow = mainWindow;
            File.AppendAllText(logPath, "[OnStartup] MainWindow instantiated. Calling Show()...\n");
            mainWindow.Show();
            File.AppendAllText(logPath, "[OnStartup] MainWindow.Show() executed successfully.\n");
        }
        catch (Exception ex)
        {
            File.AppendAllText(logPath, $"[Exception in OnStartup] {ex.Message}\n{ex.StackTrace}\n");
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app_run.log");
        File.AppendAllText(logPath, $"[OnExit] Exiting with code {e.ApplicationExitCode}\nCallStack:\n{Environment.StackTrace}\n");
        base.OnExit(e);
    }
}
