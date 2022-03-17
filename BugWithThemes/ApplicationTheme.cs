using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Syncfusion.SfSkinManager;

namespace BugWithThemes;

internal sealed class ApplicationTheme
{
    private ApplicationTheme(VisualStyles styles, string name)
    {
        Styles = styles;
        Name   = name;
    }

    public VisualStyles Styles { get; }

    public string Name { get; }

    public static IEnumerable<ApplicationTheme> Themes
    {
        get
        {
            var array = Enum.GetValues<VisualStyles>();

            Array.Sort(array,
                (x, y) => x is VisualStyles.Default ? int.MinValue : string.Compare(x.ToString(), y.ToString(), StringComparison.Ordinal));

            var themes = array.Select(s => new ApplicationTheme(s, Regex.Replace(s.ToString(), @"([A-Z]+|[0-9]+)", @" $1"))).ToList();

            return themes;
        }
    }
}