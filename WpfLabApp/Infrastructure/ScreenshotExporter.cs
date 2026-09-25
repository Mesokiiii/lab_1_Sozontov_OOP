using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfLabApp.Views;

namespace WpfLabApp;

public static class ScreenshotExporter
{
    public static void ExportAll()
    {
        string outDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "screenshots");
        outDir = Path.GetFullPath(outDir);
        if (!Directory.Exists(outDir))
        {
            Directory.CreateDirectory(outDir);
        }

        Console.WriteLine($"Exporting screenshots to: {outDir}");

        try
        {
            RenderControl(new MainTabView(), 1180, 750, Path.Combine(outDir, "tab1_main.png"));
            Console.WriteLine("Rendered tab1_main.png");

            RenderControl(new ColorPaletteTabView(), 1180, 800, Path.Combine(outDir, "tab2_palette.png"));
            Console.WriteLine("Rendered tab2_palette.png");

            RenderControl(new ControlsTabView(), 1180, 850, Path.Combine(outDir, "tab3_controls.png"));
            Console.WriteLine("Rendered tab3_controls.png");

            RenderControl(new LayoutContainersTabView(), 1180, 950, Path.Combine(outDir, "tab4_layout.png"));
            Console.WriteLine("Rendered tab4_layout.png");

            var win = new MainWindow();
            if (win.Content is UIElement winContent)
            {
                win.Content = null;
                RenderElement(winContent, 1200, 850, Path.Combine(outDir, "main_window.png"));
                Console.WriteLine("Rendered main_window.png");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error exporting screenshots: {ex.Message}\n{ex.StackTrace}");
        }
    }

    private static void RenderControl(UserControl control, double width, double height, string filePath)
    {
        var container = new Border
        {
            Width = width,
            Height = height,
            Background = (Brush)Application.Current.Resources["BgBrush"] ?? new SolidColorBrush(Color.FromRgb(15, 23, 42)),
            Child = control
        };

        RenderElement(container, width, height, filePath);
    }

    private static void RenderElement(UIElement element, double width, double height, string filePath)
    {
        element.Measure(new Size(width, height));
        element.Arrange(new Rect(0, 0, width, height));
        element.UpdateLayout();

        int pixelWidth = (int)width;
        int pixelHeight = (int)height;
        var rtb = new RenderTargetBitmap(pixelWidth, pixelHeight, 96, 96, PixelFormats.Pbgra32);
        rtb.Render(element);

        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(rtb));
        using var stream = File.Create(filePath);
        encoder.Save(stream);
    }
}
