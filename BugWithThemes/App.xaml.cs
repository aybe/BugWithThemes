using System.Windows;
using Syncfusion.SfSkinManager;

namespace BugWithThemes;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        SfSkinManager.ApplyStylesOnApplication = true;
    }
}