using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfLabApp.Views
{
    public partial class LayoutContainersTabView : UserControl
    {
        public LayoutContainersTabView()
        {
            InitializeComponent();
        }

        #region Quick Navigation
        private void NavStackPanel_Click(object sender, RoutedEventArgs e)
        {
            CardStackPanel?.BringIntoView();
        }

        private void NavGrid_Click(object sender, RoutedEventArgs e)
        {
            CardGrid?.BringIntoView();
        }

        private void NavWrapPanel_Click(object sender, RoutedEventArgs e)
        {
            CardWrapPanel?.BringIntoView();
        }

        private void NavDockPanel_Click(object sender, RoutedEventArgs e)
        {
            CardDockPanel?.BringIntoView();
        }

        private void NavCanvas_Click(object sender, RoutedEventArgs e)
        {
            CardCanvas?.BringIntoView();
        }

        private void NavUniformGrid_Click(object sender, RoutedEventArgs e)
        {
            CardUniformGrid?.BringIntoView();
        }
        #endregion

        #region StackPanel Events
        private void StackOrientation_Checked(object sender, RoutedEventArgs e)
        {
            if (DemoStackPanel == null) return;

            if (RbStackVertical != null && RbStackVertical.IsChecked == true)
            {
                DemoStackPanel.Orientation = Orientation.Vertical;
                ResetStackBlocksForOrientation(Orientation.Vertical);
            }
            else if (RbStackHorizontal != null && RbStackHorizontal.IsChecked == true)
            {
                DemoStackPanel.Orientation = Orientation.Horizontal;
                ResetStackBlocksForOrientation(Orientation.Horizontal);
            }
        }

        private void StackFixedSizes_Toggle(object sender, RoutedEventArgs e)
        {
            if (DemoStackPanel == null) return;
            bool isFixed = CbStackFixedSizes?.IsChecked == true;

            Border[] blocks = { StackBlock1, StackBlock2, StackBlock3, StackBlock4, StackBlock5 };
            foreach (var b in blocks)
            {
                if (b == null) continue;
                if (isFixed)
                {
                    b.Width = 140;
                    b.Height = 50;
                }
                else
                {
                    ResetStackBlocksForOrientation(DemoStackPanel.Orientation);
                }
            }
        }

        private void ResetStackBlocksForOrientation(Orientation orientation)
        {
            bool isFixed = CbStackFixedSizes?.IsChecked == true;
            if (isFixed) return;

            Border[] blocks = { StackBlock1, StackBlock2, StackBlock3, StackBlock4, StackBlock5 };
            foreach (var b in blocks)
            {
                if (b == null) continue;
                if (orientation == Orientation.Vertical)
                {
                    b.ClearValue(FrameworkElement.WidthProperty);
                    b.Height = 44;
                }
                else
                {
                    b.Width = 140;
                    b.Height = 85;
                }
            }
        }
        #endregion

        #region Grid Events
        private void GridLines_Toggle(object sender, RoutedEventArgs e)
        {
            if (DemoGrid != null && CbShowGridLines != null)
            {
                DemoGrid.ShowGridLines = CbShowGridLines.IsChecked == true;
            }
        }
        #endregion

        #region WrapPanel Events
        private void WrapOrientation_Checked(object sender, RoutedEventArgs e)
        {
            if (DemoWrapPanel == null) return;

            if (RbWrapHorizontal != null && RbWrapHorizontal.IsChecked == true)
            {
                DemoWrapPanel.Orientation = Orientation.Horizontal;
                if (WrapContainerBorder != null)
                {
                    WrapContainerBorder.ClearValue(FrameworkElement.HeightProperty);
                    WrapContainerBorder.MinHeight = 180;
                }
            }
            else if (RbWrapVertical != null && RbWrapVertical.IsChecked == true)
            {
                DemoWrapPanel.Orientation = Orientation.Vertical;
                if (WrapContainerBorder != null)
                {
                    WrapContainerBorder.Height = 180;
                }
            }
        }
        #endregion

        #region DockPanel Events
        private void LastChildFill_Toggle(object sender, RoutedEventArgs e)
        {
            if (DemoDockPanel != null && CbLastChildFill != null)
            {
                DemoDockPanel.LastChildFill = CbLastChildFill.IsChecked == true;
            }
        }
        #endregion

        #region Canvas Events
        private void CanvasSliders_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (InteractiveCanvasBlock == null || CanvasXSlider == null || CanvasYSlider == null) return;

            Canvas.SetLeft(InteractiveCanvasBlock, CanvasXSlider.Value);
            Canvas.SetTop(InteractiveCanvasBlock, CanvasYSlider.Value);
        }
        #endregion

        #region UniformGrid Events
        private void UniformGridCols_Checked(object sender, RoutedEventArgs e)
        {
            if (DemoUniformGrid == null) return;

            if (RbUniCols2?.IsChecked == true)
            {
                DemoUniformGrid.Columns = 2;
            }
            else if (RbUniCols3?.IsChecked == true)
            {
                DemoUniformGrid.Columns = 3;
            }
            else if (RbUniCols4?.IsChecked == true)
            {
                DemoUniformGrid.Columns = 4;
            }
            else if (RbUniCols6?.IsChecked == true)
            {
                DemoUniformGrid.Columns = 6;
            }
        }
        #endregion
    }
}
