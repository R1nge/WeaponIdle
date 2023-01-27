using System;
using UnityEngine;

public static class Helper
{
    public static string FormatNumber(float num)
    {
        // Ensure number has max 3 significant digits (no rounding up can happen)
        float i = (float)Math.Pow(10, (int)Math.Max(0, Math.Log10(num) - 2));
        num = num / i * i;

        if (num >= 1000000000000000000)
            return (num / 1000000000000000000D).ToString("0.##") + "Quint";
        if (num >= 1000000000000000)
            return (num / 1000000000000000D).ToString("0.##") + "Quad";
        if (num >= 1000000000000)
            return (num / 1000000000000D).ToString("0.##") + "T";
        if (num >= 1000000000)
            return (num / 1000000000D).ToString("0.##") + "B";
        if (num >= 1000000)
            return (num / 1000000D).ToString("0.##") + "M";
        if (num >= 1000)
            return (num / 1000D).ToString("0.##") + "K";

        return num.ToString("#,0");
    }

    public static Color RedColor()
    {
        return ColorUtility.TryParseHtmlString("#F55050", out Color red) ? red : new Color();
    }

    public static Color GreenColor()
    {
        return ColorUtility.TryParseHtmlString("#59CE8F", out Color green) ? green : new Color();
    }
}