using System;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.SfSkinManager;

namespace BugWithThemes;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ThemeMenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        // BUG some packages such as Syncfusion.GridCommon.WPF must be installed or some themes will throw
        var theme = (sender as MenuItem)?.DataContext as ApplicationTheme ?? throw new ArgumentOutOfRangeException(nameof(sender));
        SfSkinManager.SetVisualStyle(this, theme.Styles);
    }
}