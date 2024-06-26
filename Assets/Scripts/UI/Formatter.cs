using System;
public static class Formatter
{
    public static string FormatNumberToString(float value)
    {
        if (value >= Math.Pow(10, 12))
            return (value / Math.Pow(10, 12)).ToString("0.#") + "T+";
        if (value >= Math.Pow(10, 9))
            return (value / Math.Pow(10, 9)).ToString("0.#") + "B+";
        if (value >= Math.Pow(10, 6))
            return (value / Math.Pow(10, 6)).ToString("0.#") + "M+";
        if (value >= Math.Pow(10, 5))
            return (value / 1000f).ToString("0.#") + "K+";
        return value.ToString("#,0");
    }
    public static string FormatNumberToString(double value)
    {
        if (value >= Math.Pow(10, 12))
            return (value / Math.Pow(10, 12)).ToString("0.#") + "T+";
        if (value >= Math.Pow(10, 9))
            return (value / Math.Pow(10, 9)).ToString("0.#") + "B+";
        if (value >= Math.Pow(10, 6))
            return (value / Math.Pow(10, 6)).ToString("0.#") + "M+";
        if (value >= Math.Pow(10, 5))
            return (value / 1000f).ToString("0.#") + "K+";
        return value.ToString("#,0");
    }
    public static string FormatNumberToString(int value)
    {
        if (value >= Math.Pow(10, 12))
            return (value / Math.Pow(10, 12)).ToString("0.#") + "T+";
        if (value >= Math.Pow(10, 9))
            return (value / Math.Pow(10, 9)).ToString("0.#") + "B+";
        if (value >= Math.Pow(10, 6))
            return (value / Math.Pow(10, 6)).ToString("0.#") + "M+";
        if (value >= Math.Pow(10, 5))
            return (value / 1000f).ToString("0.#") + "K+";
        return value.ToString("#,0");
    }
}
